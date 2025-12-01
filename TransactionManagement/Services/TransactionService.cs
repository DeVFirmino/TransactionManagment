using TransactionManagment.DbContext;
using TransactionManagment.DTOs;
using TransactionManagment.Enums;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;
using TransactionManagment.Repository;

namespace TransactionManagment.Services;

public class TransactionService : ITransactionService

{
    private readonly IFinancialGoalRepository _repository; //To pass the db here i have to put as readonly and give the signature,
                                            //then create the class name from the same name as the Class service, and put the parameter
                                            //from AppDbContext and give the signature then call the _context and tell that is context name.
    public TransactionService(IFinancialGoalRepository repository)
    {
        _repository = repository;
    }
    

    public async Task<TransactionModel> ProcessTransactionAsync(CreateTransactionDto request)
    {
        
            var goal = await _repository.GetGoalWithTransactionsAsync(request.FinancialId);

            if (goal == null)
            {
                throw new KeyNotFoundException("Id not found");
            }
            
            if(request.DepositOrWithdraw == TransactionDepositEnum.Withdraw)
            {
                if (goal.CurrentBalance < request.TargetAmount)
                {
                    throw new InvalidOperationException("Not enough funds to realise this function");
                }

                goal.CurrentBalance -= request.TargetAmount;

            } //If passes I will add on the db

            else
            {
                goal.CurrentBalance += request.TargetAmount;
            }

            var transaction = new TransactionModel
            {
                Id = Guid.NewGuid(),
                FinancialGoalsId = goal.Id,
                Quantity = request.TargetAmount,
                Type = request.DepositOrWithdraw,
                CreationDate = DateTime.UtcNow,
                IsDeleted = false

            };

            goal.Transactions.Add(transaction);

            await _repository.SaveChangesAsync();
            

            return transaction;

//i can implement race condiditon on ef here
    }
}
     
 