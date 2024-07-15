namespace RazorView2PDF.Models;

public class DailySalesModel
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total => Quantity * Price;
}
