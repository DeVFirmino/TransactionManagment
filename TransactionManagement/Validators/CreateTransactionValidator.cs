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

    private bool ValidAmountPrecision(decimal value)
    {
        decimal movedValue = value * 100m;

        decimal truncatedValue = Math.Truncate(movedValue);

        decimal remainder = movedValue - truncatedValue;

        return remainder == 0;
        
    }
}