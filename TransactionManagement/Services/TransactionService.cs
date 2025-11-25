using TransactionManagment.DbContext;
using TransactionManagment.DTOs;
using TransactionManagment.Enums;
using TransactionManagment.Interfaces;
using TransactionManagment.Models;
using TransactionManagment.Repository;

namespace TransactionManagment.Services;

public class TransactionService : ITransactionService

{
    private readonly FinancialGoalRepository _repository; //To pass the db here i have to put as readonly and give the signature,
                                            //then create the class name from the same name as the Class service, and put the parameter
                                            //from AppDbContext and give the signature then call the _context and tell that is context name.
    public TransactionService(FinancialGoalRepository repository)
    {
        repository = _repository;
    }
    

    public async Task<TransactionModel> ProcessTransactionAsync(CreateTransactionDto request)
    {
        try
        {
            var goal = await _repository.GetGoalWithTransactionsAsync(request.FinancialId);
            
            if(request.DepositOrWithdraw == TransactionDepositEnum.Withdraw)
            {
                if (goal.CurrentBalance < request.TargetAmount)
                {
                    throw new InvalidOperationException()
                }
            }
        }
    }
}
     
 