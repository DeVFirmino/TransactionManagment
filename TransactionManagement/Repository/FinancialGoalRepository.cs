using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    public async Task<GoalModel> AddAsync(GoalModel goal)
    {
         await _context.Goals.AddAsync(goal);
         await _context.SaveChangesAsync();
         return goal;

    }

    public async Task<List<GoalModel>> GetAllAsync()
    {
        
        var goals = await _context.Goals
            .Where(i => !i.IsDeleted)
            .ToListAsync();
            return goals; //o getall eu uso como se fosse o select mas antes tenho q declarar uma
            //variavel pra poder passar a lista de goals, uso o where pra puxar o que uqero e depois to list 
        

    } 

    public async Task<GoalModel> GetByIdAsync(Guid id)
    {
        var goal = await _context
            .Goals
            .FirstOrDefaultAsync(x => x.Id == id);
        if (goal == null)
            throw new KeyNotFoundException("Not found");
        
        return goal;
 //crio a variavel goal, vou no assincrono, entro no banco, entro no model, acho first or defaly
 // atribuo o id do banco pro id q eu dei o nome, se faco if se o o id for nulo eu mando exeption de nao achado,
 //  se nao achar eu mando trhwo new notfound

    }


    public async Task<GoalModel> UpdateAsync(GoalModel goal)
    {
        _context.Goals.Update(goal);
        await _context.SaveChangesAsync();

        return goal;
    }
}