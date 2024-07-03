using BestSellerBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BestSellerBooks.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
}

