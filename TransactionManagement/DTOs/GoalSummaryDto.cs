namespace TransactionManagment.DTOs;

public class GoalSummaryDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public decimal TargetAmount { get; set; }

    public decimal CurrentBalance { get; set; }
    
}