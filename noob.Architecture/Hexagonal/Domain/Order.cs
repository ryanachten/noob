namespace noob.Architecture.Hexagonal.Domain;

public record Order(int Id, string CustomerName, decimal Amount, DateTime CreatedAt);
