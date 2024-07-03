namespace BestSellerBooks.Contract.Books;

public record GetBestSellerBookRequest(
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
);