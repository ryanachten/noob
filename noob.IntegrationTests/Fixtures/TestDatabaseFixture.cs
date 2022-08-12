using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace noob.IntegrationTests.Fixtures;

public class TestDatabaseFixture<TDbContext> : IClassFixture<ApplicationFactory<TDbContext>> where TDbContext : DbContext
{
    protected TDbContext _context;

    public TestDatabaseFixture(ApplicationFactory<TDbContext> factory)
    {
        var scopeFactory = factory.Services.GetService<IServiceScopeFactory>();

        var scope = scopeFactory?.CreateScope();

        var context = scope?.ServiceProvider.GetService<TDbContext>();

        var databaseCreated = context?.Database.EnsureCreated() ?? false;
        if (!databaseCreated)
        {
            throw new Exception("Issue creating database");
        }

        _context = context!;
    }
}
