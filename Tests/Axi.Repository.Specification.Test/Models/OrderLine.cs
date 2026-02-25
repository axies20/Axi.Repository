namespace Axi.Repository.Specification.Test;

public sealed class OrderLine
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int Quantity { get; set; }
}