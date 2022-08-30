using noob.Patterns.Structural.Adapter;
using Xunit;

namespace noob.UnitTests.Patterns.Structural;

public class AdapterTests
{
    [Fact]
    public void WhenRetrievingEmployeesFromHR_ThenBillingHasTheCorrectEmployees()
    {
        // Arrange
        var adapter = new HREmployeeAdapter();
        var client = new BillingSystem(adapter);

        // Act
        client.GetEmployees();

        // Assert
        Assert.Equal(adapter.GetEmployees().Count, client.Employees.Count);
    }
}
