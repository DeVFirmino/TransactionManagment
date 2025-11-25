namespace TransactionManagment.DTOs;

public class CreateGoalInputDto
{

    public string Title { get; set; }
    
    public decimal TargetAmount { get; set; }

    public decimal? IdealMonthlyContribution { get; set; }

     
    
}