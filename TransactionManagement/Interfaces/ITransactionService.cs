using TransactionManagment.DbContext;
using TransactionManagment.DTOs;
using TransactionManagment.Models;
using TransactionManagment.Validation;

namespace TransactionManagment.Interfaces;

public interface ITransactionService

{
     public Task<TransactionModel> ProcessTransactionAsync(CreateTransactionDto request);
}