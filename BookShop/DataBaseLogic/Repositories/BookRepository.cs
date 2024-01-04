using Microsoft.EntityFrameworkCore;
using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;

namespace BookShop.DataBaseLogic.Repositories
{
    public class BookRepository : IBaseRepository<Book>
    {
        private AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Book entity)
        {
            _dbContext.Books.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Book> GetAll()
        {
            return _dbContext.Books.AsQueryable();
        }

        public async Task<Book> Update(Book entity)
        {
            _dbContext.Books.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Create(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
