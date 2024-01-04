using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookShop.Domain.Entities;
using BookShop.Services;

namespace BookShop.DataBaseLogic
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Authors {  get; set; }

        public DbSet<Book> Books {  get; set; }

        public DbSet<Operation> Operations {  get; set; }

        public DbSet<User> Users {  get; set; }

        public DbSet<Authorship> Authorship { get; set; }

        public DbSet<Operationship> Operationships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация отношения многие-ко-многим через таблицу Authorships с помощью Fluent API
            modelBuilder.Entity<Authorship>()
                .HasKey(a => new { a.BookId, a.AuthorId }); // Устанавливаем составной ключ

            modelBuilder.Entity<Authorship>()
                .HasOne(a => a.Author)
                .WithMany(a => a.Authorships)
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Authorship>()
                .HasOne(a => a.Book)
                .WithMany(b => b.Authorships)
                .HasForeignKey(a => a.BookId);


            modelBuilder.Entity<Operationship>()
            .HasKey(os => new { os.OperationID, os.BookID });

            modelBuilder.Entity<Operationship>()
                .HasOne(os => os.Operation)
                .WithMany(o => o.Operationships)
                .HasForeignKey(os => os.OperationID);

            modelBuilder.Entity<Operationship>()
                .HasOne(os => os.Book)
                .WithMany(b => b.Operationships)
                .HasForeignKey(os => os.BookID);
        }



    }
}
