using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace noob.IntegrationTests;

// Custom WebApplicationFactory as per:
// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0#customize-webapplicationfactory
public class ApplicationFactory<TDbContext> : WebApplicationFactory<Program> where TDbContext : DbContext
{
    private SqliteConnection? Connection;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Connection = new SqliteConnection("DataSource=:memory:");
        Connection.Open();

        builder.ConfigureServices(services =>
        {
            // Unregister existing database service
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<TDbContext>));

            if (descriptor != null) services.Remove(descriptor);

            services.AddDbContext<TDbContext>(options => options.UseSqlite(Connection));
        });
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        Connection?.Close();
    }
}
