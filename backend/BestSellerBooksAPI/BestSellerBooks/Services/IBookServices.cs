using BestSellerBooks.Contract.Books;
using BestSellerBooks.Models;
using ErrorOr;

namespace BestSellerBooks.Services;

public interface IBookServices
{
    Task<List<Book>> GetAllBooks();
    Task<ErrorOr<Created>> CreateBestSellerBook(Book book);
    Task<ErrorOr<Book>> GetBookById(Guid id);
    Task<ErrorOr<Updated>> UpdateBestSellerBook(Guid id, Book book);
    Task<ErrorOr<Deleted>> DeleteBestSellerBook(Guid id);
}