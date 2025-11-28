using TransactionManagment.DTOs;
using TransactionManagment.Models;
using TransactionManagment.Services;

namespace TransactionManagment.Interfaces;

public interface IFinancialGoalService 
{
    public Task<GoalSummaryDto> CreateGoalAsync (CreateGoalInputDto request);

    public Task<List<GoalSummaryDto>> GetAllGoalsAsync();

    public Task<GoalSummaryDto> UpdateAsync(UpdateGoalInputDto request);

    public Task<GoalSummaryDto> GetByIdAsync(Guid id);

    public Task DeleteAsync(Guid id);

}