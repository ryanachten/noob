using Microsoft.EntityFrameworkCore;
using noob.IntegrationTests.Fixtures;

namespace noob.IntegrationTests.Exercises.CtCI;

public class Building
{
    public int BuildingId { get; set; }
    public string? BuildingName { get; set; }
    public string? BuildingAddress { get; set; }
}

public class Apartment
{
    public int ApartmentId { get; set; }
    public string? ApartmentAddress { get; set; }
    public Building? Building { get; set; }

}

public class Tenant
{
    public int TenantId { get; set; }
    public string? TenantName { get; set; }
    public string? TenantAddress { get; set; }
}

public class TenantApartment
{
    public int TenantApartmentId { get; set; }
    public Tenant Tenant { get; set; } = default!;
    public Apartment Apartment { get; set; } = default!;
}

public class ApartmentContext : DbContext
{
    public ApartmentContext(DbContextOptions<ApartmentContext> options) : base(options) { }
    public DbSet<Building> Buildings { get; set; } = default!;
    public DbSet<Apartment> Apartments { get; set; } = default!;
    public DbSet<Tenant> Tenants { get; set; } = default!;
    public DbSet<TenantApartment> TenantApartments { get; set; } = default!;
}

public abstract class BaseApartmentExercise : TestDatabaseFixture<ApartmentContext>
{
    public BaseApartmentExercise(ApplicationFactory<ApartmentContext> factory) : base(factory)
    {
    }
}
