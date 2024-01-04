using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;

namespace BookShop.DataBaseLogic.Repositories
{
    public class AuthorshipRepository : IBaseRepository<Authorship>
    {
        private AppDbContext _dbContext;

        public AuthorshipRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Authorship entity)
        {
            await _dbContext.Authorship.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Authorship entity)
        {
            _dbContext.Authorship.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Authorship> GetAll()
        {
           return _dbContext.Authorship.AsQueryable();
        }

        public async Task<Authorship> Update(Authorship entity)
        {
            _dbContext.Authorship.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
