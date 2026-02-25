namespace Axi.Repository.Specification.Test;

public sealed class Order
{
    public int Id { get; set; }
    public decimal Total { get; set; }
    public List<OrderLine> Lines { get; set; } = [];
}