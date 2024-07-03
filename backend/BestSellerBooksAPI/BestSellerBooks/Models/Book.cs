using BestSellerBooks.Contract.Books;
using ErrorOr;

namespace BestSellerBooks.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public List<string> Genre { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }
    public string ImageUrl { get; set; }
    public string Publisher { get; set; }
    public string PublishedDate { get; set; }
    public string OriginalLanguage { get; set; }
    public string Pages { get; set; }

    public Book(
        Guid Id,
        string Title,
        string Author,
        List<string> Genre,
        string Isbn,
        string Description,
        string ImageUrl,
        string Publisher,
        string PublishedDate,
        string OriginalLanguage,
        string Pages
    )
    {
        this.Id = Id;
        this.Title = Title;
        this.Author = Author;
        this.Genre = Genre;
        this.Isbn = Isbn;
        this.Description = Description;
        this.ImageUrl = ImageUrl;
        this.Publisher = Publisher;
        this.PublishedDate = PublishedDate;
        this.OriginalLanguage = OriginalLanguage;
        this.Pages = Pages;
    }

    public static ErrorOr<Book> Create(
        string Title,
        string Author,
        List<string> Genre,
        string Isbn,
        string Description,
        string ImageUrl,
        string Publisher,
        string PublishedDate,
        string OriginalLanguage,
        string Pages,
        Guid? Id = null
    )
    {
        var errors = new List<Error>();

        // Add and enforce invariants 

        return new Book(
            Id ?? Guid.NewGuid(),
            Title,
            Author,
            Genre,
            Isbn,
            Description,
            ImageUrl,
            Publisher,
            PublishedDate,
            OriginalLanguage,
            Pages
        );
    }

    public static ErrorOr<Book> From(CreateBestSellerBookRequest request)
    {
        return Create(
            request.Title,
            request.Author,
            request.Genre,
            request.Isbn,
            request.Description,
            request.ImageUrl,
            request.Publisher,
            request.PublishedDate,
            request.OriginalLanguage,
            request.Pages
        );
    }

    public static ErrorOr<Book> From(Guid id, UpdateBestSellerBookRequest request)
    {
        return Create(
            request.Title,
            request.Author,
            request.Genre,
            request.Isbn,
            request.Description,
            request.ImageUrl,
            request.Publisher,
            request.PublishedDate,
            request.OriginalLanguage,
            request.Pages,
            id
        );
    }
}