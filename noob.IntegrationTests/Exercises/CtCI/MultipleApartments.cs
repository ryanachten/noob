using Xunit;
using Microsoft.EntityFrameworkCore;
using noob.IntegrationTests.Fixtures;
using System.Collections.Generic;

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
        GivenApartments();
    }

    private void GivenApartments()
    {
        _context.Tenants.Add(new Tenant() { 
            Name = "Jeff", 
            Apartments = new List<Apartment>() { new(), new() }
        });
        _context.SaveChanges();
    }

    [Fact]
    // @TODO: load external SQL file and complete exercise
    public async void DoesItWork()
    {
        var tenant = await _context.Tenants.FirstOrDefaultAsync();

        Assert.NotNull(tenant);
        Assert.Equal("Jeff", tenant?.Name);
        Assert.Equal(2, tenant?.Apartments.Count);
    }
}
