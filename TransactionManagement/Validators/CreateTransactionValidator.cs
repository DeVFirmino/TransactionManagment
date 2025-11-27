using FluentValidation;
using TransactionManagment.DTOs;
using TransactionManagment.Enums;

namespace TransactionManagment.Validation;

public class CreateTransactionValidator : AbstractValidator<CreateTransactionDto>

{
    public CreateTransactionValidator()
    {
        RuleFor(x => x.TargetAmount)
            .GreaterThan(0)
            .NotEmpty().WithMessage("Amount required");

        RuleFor(x => x.FinancialId)
            .NotEmpty()
            .WithMessage("The Id is required");

        RuleFor(x => x.DepositOrWithdraw)
            .IsInEnum()
            .WithMessage("You must select an option for withdraw or deposit");

        RuleFor(x => x.TargetAmount)
            .GreaterThan(0)
            .Must(ValidAmountPrecision)
            .WithMessage("Precision must be 2");
 
    }

    //Validates the amount precision from the Dto model transaction,
    //I used this logic for the RuleFor on the FluentValidation to
    //validate the amount precision when using decimal values, implemented
    //Math Truncate for it, first I create a decimal called moved value and got a decimal value * 100
    // to generate the value in decimals, to the right, then I declared another decimal called truncated value
    // and used the match.truncate to truncate the moved value
    // on the remainder i passed the moved value truncate - the truncatedvalue  and returned remainder == 0 which gives me the decimal amount
    private bool ValidAmountPrecision(decimal value) 
    {
        decimal movedValue = value * 100m;

        decimal truncatedValue = Math.Truncate(movedValue);

        decimal remainder = movedValue - truncatedValue;

        return remainder == 0;
        
    }
}