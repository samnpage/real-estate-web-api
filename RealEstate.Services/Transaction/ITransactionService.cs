using RealEstate.Data.Entities;
using RealEstate.Models.Buyer;
using RealEstate.Models.Responses;
using RealEstate.Models.Transaction;

namespace RealEstate.Services.Transaction;
public interface ITransactionService
{
    // CREATE
    Task<bool> CreateTransactionAsync(CreateTransaction model);

    // READ

    Task<TransactionDetail?> GetTransactionByIdAsync(int id);
    Task<List<TransactionEntity>> GetAllTransactionsAsync();

    // UPDATE
    Task<TextResponse> UpdateTransactionByIdAsync(int id, CreateTransaction updatedTransaction);
    
    // DELETE
    Task<TextResponse> DeleteTransactionByIdAsync(int id);
}