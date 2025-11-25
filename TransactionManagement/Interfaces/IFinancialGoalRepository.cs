using TransactionManagment.Models;

namespace TransactionManagment.Interfaces;

  
public interface IFinancialGoalRepository
{
    public Task<GoalModel> GetGoalWithTransactionsAsync(Guid goalId); 
    
}