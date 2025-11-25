using TransactionManagment.Enums;

namespace TransactionManagment.DTOs;

public class CreateTransactionDto
{
    public decimal TargetAmount { get; set; }

    public  Guid FinancialId { get; set; }

    public TransactionDepositEnum DepositOrWithdraw { get; set; }
    
}