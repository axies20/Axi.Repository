namespace Axi.Repository.Specification.Test.Models;

public sealed class Address
{
    public string Street { get; set; } = string.Empty;
    public City City { get; set; } = new();
}