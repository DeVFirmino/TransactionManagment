namespace TransactionManagment.DTOs;

public class UpdateGoalInputDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    
    public decimal TargetAmount { get; set; }

    public decimal? IdealMonthlyContribution { get; set; }

}   