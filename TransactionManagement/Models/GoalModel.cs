using System.Transactions;

namespace TransactionManagment.Models;

public class GoalModel
{

    public Guid Id { get; set; }
    
    public Guid FinancialGoalsId { get; set; }

    public string Title { get; set; } 

    public decimal TargetQuantity { get; set; }

    public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>(); //Mapping one to many relationships

    public DateTime CreationDate { get; set; }

    public bool IsDeleted { get; set; }
    
}