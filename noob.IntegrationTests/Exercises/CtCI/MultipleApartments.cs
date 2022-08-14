using Xunit;
using Microsoft.EntityFrameworkCore;
using noob.IntegrationTests.Extensions;
using System.Linq;
using noob.IntegrationTests.Exercises.CtCI;
using System.Collections.Generic;

namespace noob.IntegrationTests.Exercises;

public class MultipleApartments : BaseApartmentExercise
{
    public MultipleApartments(ApplicationFactory<ApartmentContext> factory) : base(factory)
    {
        GivenTenantsWithApartments();
    }

    private void GivenTenantsWithApartments()
    {
        var tenantsWithApartments = new Dictionary<Tenant, List<Apartment>>()
        {
            {
                new Tenant()
                {
                    TenantName = "Tenant 1",
                },
                new List<Apartment>()
                {
                    new(),
                    new(),
                }
            },
            {
                new Tenant()
                {
                    TenantName = "Tenant 2",
                },
                new List<Apartment>()
                {
                    new(),
                }
            },
            {
                new Tenant()
                {
                    TenantName = "Tenant 3",
                },
                new List<Apartment>()
                {
                    new(),
                    new(),
                    new()
                }
            },
            {
                new Tenant()
                {
                    TenantName = "Tenant 4",
                },
                new List<Apartment>()
            },
        };

        foreach (var kvp in tenantsWithApartments)
        {
            _context.Tenants.Add(kvp.Key);
            foreach (var apartment in kvp.Value)
            {
                _context.Apartments.Add(apartment);
                _context.TenantApartments.Add(new()
                {
                    Apartment = apartment,
                    Tenant = kvp.Key,
                });
            }
        }
        _context.SaveChanges();
    }

    [Fact]
    public async void WhenGettingAListOfTenants_ThenThoseWithMoreThanOneApartmentAreReturned()
    {
        var tenants = await _context.Tenants.FromSqlFile().ToListAsync();
        Assert.NotNull(tenants);
        Assert.NotEmpty(tenants);
        Assert.Equal(3, tenants.Count);

        Assert.Equal("Tenant 1", tenants.First().TenantName);
        Assert.Equal("Tenant 2", tenants.ElementAt(1).TenantName);
        Assert.Equal("Tenant 3", tenants.Last().TenantName);
    }
}
