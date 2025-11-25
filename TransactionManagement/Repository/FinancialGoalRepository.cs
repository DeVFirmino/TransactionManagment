using Microsoft.EntityFrameworkCore;
using TransactionManagment.DbContext;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;

namespace TransactionManagment.Repository;

public class FinancialGoalRepository : IFinancialGoalRepository
{
    private readonly AppDbContext _context;

    public FinancialGoalRepository(AppDbContext context)
    {
        _context = context;
    }

    
    //do not use trycach on the repository
    public async Task<GoalModel> GetGoalWithTransactionsAsync(Guid goalId)
    {
        return await _context.Goals.Include(x => x.Transactions).
            FirstOrDefaultAsync(x => x.Id == goalId); 
        //eager loading here using firstordfaultasync, sql generates a join and brings the list 

    }
}