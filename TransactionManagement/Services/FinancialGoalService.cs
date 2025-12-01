using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using TransactionManagment.DTOs;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;

namespace TransactionManagment.Services;

public class FinancialGoalService : IFinancialGoalService
{
    private readonly IFinancialGoalRepository _repository;

    public FinancialGoalService(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }

    public async Task<GoalSummaryDto> CreateGoalAsync(CreateGoalInputDto request)
    {
        //instanciar o mapeamento
        var goal = new GoalModel()
       
 {
            Title = request.Title,
            TargetQuantity = request.TargetAmount,

            Id = new Guid(),
            CurrentBalance = 0,
            CreationDate = DateTime.UtcNow,
            IsDeleted = false,

            Transactions = new List<TransactionModel>()
        }; //initialize the list to not give error in the future 
            
            // needs to persists - save on the db
            var createdGoal = await _repository.AddAsync(goal);
            
            //return 
            return new GoalSummaryDto
            {
                Id = createdGoal.Id,
                Title = createdGoal.Title,
                TargetAmount = createdGoal.TargetQuantity,
                CurrentBalance = createdGoal.CurrentBalance
            };
            //after that i have to make the connection to the program

    }

    public async Task<List<GoalSummaryDto>> GetAllGoalsAsync()
    {
        var goalsDb = await _repository.GetAllAsync();
        
        //Service to DTO
        return goalsDb.Select(x => new GoalSummaryDto
        {
            Id = x.Id,
            Title = x.Title,
            CurrentBalance = x.CurrentBalance,
            TargetAmount = x.TargetQuantity
        }).ToList();
         


    }

    public async Task<GoalSummaryDto> UpdateAsync(UpdateGoalInputDto request, Guid id)
    {
        var updateGoal = await _repository.GetByIdAsync(request.Id);
        if (updateGoal == null)
        {
            throw new KeyNotFoundException("Not found");
        }

        updateGoal.Title = request.Title;
        updateGoal.TargetQuantity = request.TargetAmount;
        //dO NOT ADD THE CURRENTBALANCE IF THE USER WNANTS TO SEND balance.
        //Balance can be changet via Transaction. Update is only for name or data.
         
        //Persistance
        await _repository.UpdateAsync(updateGoal);

        return new GoalSummaryDto
        {
            Id = updateGoal.Id,
            Title = updateGoal.Title,
            TargetAmount = updateGoal.TargetQuantity,
            CurrentBalance = updateGoal.CurrentBalance
        };
    }

    public async Task<GoalSummaryDto> GetByIdAsync(Guid id)
    {
        var getId = await _repository.GetByIdAsync(id);
        if (getId == null)
        {
            throw new KeyNotFoundException("Not found");
        }

        var dto = new GoalSummaryDto
        {
            Id = getId.Id,
            Title = getId.Title,
            TargetAmount = getId.TargetQuantity, 
            CurrentBalance = getId.CurrentBalance
        };

        return dto;

    }//refatorar essa merda im done 
    //Quem desiste o caminho acaba ai .

    public async Task DeleteAsync(Guid id)
    {
        var deleteId = await _repository.GetByIdAsync(id);
        if (deleteId == null)
        {
            throw new KeyNotFoundException("Not found");
        }

        deleteId.IsDeleted = true;

        await _repository.UpdateAsync(deleteId);
        
    }
}