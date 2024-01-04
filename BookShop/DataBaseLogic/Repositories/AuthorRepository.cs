using Microsoft.EntityFrameworkCore;
using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;

namespace BookShop.DataBaseLogic.Repositories
{
    public class AuthorRepository : IBaseRepository<Author>
    {
        private AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Author entity)
        {
            await _dbContext.Authors.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Author entity)
        {
            _dbContext.Authors.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Author> GetAll()
        {
            return _dbContext.Authors.AsQueryable();
        }

        public async Task<Author> Update(Author entity)
        {
            _dbContext.Authors.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
