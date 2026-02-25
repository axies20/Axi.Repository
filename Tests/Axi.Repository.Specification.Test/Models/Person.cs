namespace Axi.Repository.Specification.Test;

public sealed class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool IsActive { get; set; }
    public Address Address { get; set; } = new();
    public List<Order> Orders { get; set; } = [];
}