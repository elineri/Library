using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) :base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }
        public DbSet<LoanCartItem> LoanCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customers
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Elin",
                LastName = "Ericstam",
                PhoneNumber = "070-12345678",
                Address = "Strandvägen 1"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Olof",
                LastName = "Karlsson",
                PhoneNumber = "070-12345690",
                Address = "Storgatan 5"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Doris",
                LastName = "Svensson",
                PhoneNumber = "070-34545678",
                Address = "Skogsvägen 3"
            });

            // Books
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                Title = "The Lord of the Rings: The Two Towers",
                Author = "J.R.R. Tolkien"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                Title = "The Lord of the Rings: The Return of the King",
                Author = "J.R.R. Tolkien"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 4,
                Title = "A Game of Thrones",
                Author = "George R.R. Martin"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 5,
                Title = "A Clash of Kings",
                Author = "George R.R. Martin"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 6,
                Title = "Under the Dome",
                Author = "Steven King"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 7,
                Title = "Harry Potter and the Philosopher's stone",
                Author = "J.K. Rowling"
            });
        }
    }
}
