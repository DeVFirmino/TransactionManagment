using Microsoft.VisualBasic;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;

namespace TransactionManagment.Services;

public class FinancialGoalService : IFinancialGoalRepository
{
    private readonly IFinancialGoalRepository _repository;

    public FinancialGoalService(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public Task<GoalModel> GetGoalWithTransactionsAsync(Guid goalId)
    {
        throw new NotImplementedException();
    }

    public Task<GoalModel> AddAsync(GoalModel goal)
    {
        throw new NotImplementedException();
    }

    public Task<List<GoalModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GoalModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<GoalModel> UpdateAsync(GoalModel goal)
    {
        throw new NotImplementedException();
    }
}