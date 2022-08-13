using Xunit;
using Microsoft.EntityFrameworkCore;
using noob.IntegrationTests.Fixtures;
using System.Collections.Generic;
using noob.IntegrationTests.Extensions;

namespace noob.IntegrationTests.Exercises;

public class Apartment
{
    public int ApartmentId { get; set; }
}

public class Tenant
{
    public int TenantId { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<Apartment> Apartments { get; set; } = default!;
}

public class ApartmentContext : DbContext
{
    public ApartmentContext(DbContextOptions<ApartmentContext> options) : base(options) { }
    public DbSet<Apartment> Apartments { get; set; } = default!;
    public DbSet<Tenant> Tenants { get; set; } = default!;
}

public class MultipleApartments : TestDatabaseFixture<ApartmentContext>
{
    public MultipleApartments(ApplicationFactory<ApartmentContext> factory) : base(factory)
    {
        GivenTenantsWithApartments();
    }

    private void GivenTenantsWithApartments()
    {
        _context.Tenants.Add(new Tenant()
        {
            Name = "Tenant 1",
            Apartments = new List<Apartment>() { new(), new(), new() }
        });
        _context.Tenants.Add(new Tenant()
        {
            Name = "Tenant 2",
            Apartments = new List<Apartment>() { new() }
        });
        _context.Tenants.Add(new Tenant()
        {
            Name = "Tenant 3"
        });
        _context.Tenants.Add(new Tenant() { 
            Name = "Tenant 4", 
            Apartments = new List<Apartment>() { new(), new() }
        });
        _context.SaveChanges();
    }

    [Fact]
    public async void WhenGettingAListOfTenants_ThenThoseWithMoreThanOneApartmentAreReturned()
    {
        var tenants = await _context.Tenants.FromSqlFile().ToListAsync();
        Assert.NotNull(tenants);
        Assert.NotEmpty(tenants);
    }
}
