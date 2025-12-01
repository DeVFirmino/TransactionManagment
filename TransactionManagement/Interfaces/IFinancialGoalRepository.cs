using TransactionManagment.Models;

namespace TransactionManagment.Interfaces;

  
public interface IFinancialGoalRepository
{
    public Task<GoalModel> GetGoalWithTransactionsAsync(Guid goalId);

    public Task<GoalModel> AddAsync(GoalModel goal);

    public Task<List<GoalModel>> GetAllAsync(); //if i want to get all from the model
                                                //i have to use the list to list all and
                                                //do not pass parameters as is already passing there 
    public Task<GoalModel> GetByIdAsync(Guid id);

    public Task<GoalModel> UpdateAsync(GoalModel goal);

    public Task SaveChangesAsync();


}