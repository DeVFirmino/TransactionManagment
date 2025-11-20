namespace TransactionManagment.Models;

public class Entities
{
    public Guid Id { get; set; } = new Guid();

    public string Title { get; set; } = string.Empty;

    public decimal TargetQuantity { get; set; }

}