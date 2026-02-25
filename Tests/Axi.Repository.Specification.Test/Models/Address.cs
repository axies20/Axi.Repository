namespace Axi.Repository.Specification.Test;

public sealed class Address
{
    public string Street { get; set; } = string.Empty;
    public City City { get; set; } = new();
}