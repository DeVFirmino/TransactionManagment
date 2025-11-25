namespace TransactionManagment.Models;

public class TransactionModel
{
    public Guid Id { get; set; }

    public Guid FinancialGoalsId { get; set; }
 
    public decimal Quantity { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime CreationDate { get; set; }

    public bool IsDeleted { get; set; }
    public GoalModel GoalModel { get; set; }
}
 