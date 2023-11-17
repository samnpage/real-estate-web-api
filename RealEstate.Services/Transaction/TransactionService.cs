using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Models.Transaction;
using RealEstate.Models.Responses;
using RealEstate.Services.Buyer;

namespace RealEstate.Services.Transaction;
public class BuyerService : ITransactionService
{
    private readonly ApplicationDbContext _dbContext;

    public BuyerService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // CREATE Method
    public async Task<bool> CreateTransactionAsync(CreateTransaction model)
    {
        TransactionEntity entity = new()
        {
            SalePrice = model.SalePrice,
            TransactionDate = DateTime.Now
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    // READ ALL Method
    public async Task<List<TransactionEntity>> GetAllTransactionsAsync()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    // READ By Id Method
    public async Task<TransactionDetail?> GetTransactionByIdAsync(int id)
    {
        TransactionEntity? entity = await _dbContext.Transactions.FindAsync(id);
        if (entity is null)
            return null;

        TransactionDetail detail = new()
        {
            Id = entity.Id,
            ListingId = entity.ListingId,
            BuyerId = entity.BuyerId,
            AskingPrice = entity.AskingPrice,
            TransactionDate = entity.TransactionDate
        };

        return detail;
    }

    // UPDATE Method
    public async Task<TextResponse> UpdateTransactionByIdAsync(int id, CreateTransaction updatedTransaction)
    {
        var currentTransaction = await _dbContext.Transactions.FirstOrDefaultAsync(e => e.Id == id);

        if (currentTransaction != null)
        {
            bool hasChanges = false;

            if (currentTransaction.SalePrice != updatedTransaction.SalePrice)
            {
                currentTransaction.SalePrice = updatedTransaction.SalePrice;
                hasChanges = true;
            }

            if (hasChanges)
            {
                await _dbContext.SaveChangesAsync();
                return new TextResponse("Transaciton updated successfully");
            }
            else
            {
                return new TextResponse("Update was unsuccessful. No changes were made.");
            }
        }

        return new TextResponse("Update was unsuccessful. Transaction not found.");
    }

    // DELETE Method
    public async Task<TextResponse> DeleteTransactionByIdAsync(int id)
    {
        var transactionToDelete = await _dbContext.Transactions.FirstOrDefaultAsync(e => e.Id == id);

        if (transactionToDelete != null)
        {
            _dbContext.Transactions.Remove(transactionToDelete);
            await _dbContext.SaveChangesAsync();
        }

        TextResponse response = new("Transaction removed successfully.");

        return response;
    }
}