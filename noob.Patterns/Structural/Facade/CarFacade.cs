namespace noob.Patterns.Structural.Facade;

/// <summary>
/// Facade providing client access to complex subsystem
/// </summary>
public class CarFacade
{
    /// <summary>
    /// Member provides client with high-level access
    /// by aggregating results from complex processes
    /// </summary>
    /// <returns></returns>
    public static async Task<Car> CreateCar()
    {
        var engine = await Engine.Create();
        var transmission = await Transmission.Create(engine);
        var steering = await Steering.Create(engine);

        return new Car()
        {
            Engine = engine,
            Transmission = transmission,
            Steering = steering
        };
    }
}
