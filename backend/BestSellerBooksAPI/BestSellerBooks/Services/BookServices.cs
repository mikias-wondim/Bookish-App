using BestSellerBooks.Contract.Books;
using BestSellerBooks.Data;
using BestSellerBooks.Models;
using BestSellerBooks.Services;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace BestSellerBooks.Services;

public class BookServices(ApplicationDbContext dbContext) : IBookServices
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<ErrorOr<Created>> CreateBestSellerBook(Book book)
    {
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        return Result.Created;
    }

    public async Task<ErrorOr<Deleted>> DeleteBestSellerBook(Guid id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is not null)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return Result.Deleted;
        }

        return Error.NotFound();
    }

    public async Task<List<Book>> GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();

        return books;
    }

    public async Task<ErrorOr<Book>> GetBookById(Guid id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book is not null)
        {
            return book;
        }

        return Error.NotFound();
    }

    public async Task<ErrorOr<Updated>> UpdateBestSellerBook(Guid id, Book book)
    {
        var existingBook = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (existingBook is not null)
        {
            _dbContext.Entry(existingBook).CurrentValues.SetValues(book);
            await _dbContext.SaveChangesAsync();
            return Result.Updated;
        }

        return Error.NotFound("Book is not found!");
    }
}