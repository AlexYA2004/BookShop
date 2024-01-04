using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;

namespace BookShop.DataBaseLogic.Repositories
{
    public class OperationRepository : IBaseRepository<Operation>
    {
        private AppDbContext _dbContext;

        public OperationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Operation entity)
        {
            await _dbContext.Operations.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

        }

        public async Task Delete(Operation entity)
        {
            _dbContext.Operations.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Operation> GetAll()
        {
           return _dbContext.Operations.AsQueryable();
        }

        public async Task<Operation> Update(Operation entity)
        {
            _dbContext.Operations.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
