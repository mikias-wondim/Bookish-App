using BestSellerBooks.Contract.Books;
using BestSellerBooks.Models;
using BestSellerBooks.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BestSellerBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookServices bookServices) : ControllerBase
    {
        private readonly IBookServices _bookServices = bookServices;

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            List<Book> books = await _bookServices.GetAllBooks();

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBestSellerBookRequest request)
        {
            ErrorOr<Book> requestToBookResult = Book.From(request);

            if (requestToBookResult.IsError)
            {
                return BadRequest(requestToBookResult.Errors);
            }

            var book = requestToBookResult.Value;

            ErrorOr<Created> createdBookResult = await _bookServices.CreateBestSellerBook(book);

            return createdBookResult.Match(
                created => CreatedAtGetBook(book),
                error => Problem()
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            ErrorOr<Book> getBookResult = await _bookServices.GetBookById(id);

            return getBookResult.Match(
                book => Ok(MapBookResponse(book)),
                errors => Problem()
            );
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBestSellerBookRequest request)
        {
            ErrorOr<Book> requestToBookResult = Book.From(id, request);

            if (requestToBookResult.IsError)
            {
                return BadRequest(requestToBookResult.Errors);
            }

            var book = requestToBookResult.Value;

            ErrorOr<Updated> updatedBookResult = await _bookServices.UpdateBestSellerBook(id, book);

            return updatedBookResult.Match(
                updated => CreatedAtGetBook(book),
                errors => Problem()
            );
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            ErrorOr<Deleted> deleteResult = await _bookServices.DeleteBestSellerBook(id);

            if (deleteResult.IsError)
            {
                return Problem();
            }

            return NoContent();
        }


        // Action helper functions

        private CreatedAtActionResult CreatedAtGetBook(Book book)
        {
            return CreatedAtAction(
                actionName: nameof(GetBookById),
                routeValues: new { id = book.Id },
                value: MapBookResponse(book)
                );
        }
        private static Book MapBookResponse(Book book)
        {
            return new Book(
                            book.Id,
                            book.Title,
                            book.Author,
                            book.Genre,
                            book.Isbn,
                            book.Description,
                            book.ImageUrl,
                            book.Publisher,
                            book.PublishedDate,
                            book.OriginalLanguage,
                            book.Pages
                        );
        }
    }
}