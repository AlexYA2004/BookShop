using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;

namespace BookShop.DataBaseLogic.Repositories
{
    public class OperationshipRepository : IBaseRepository<Operationship>
    {
        private AppDbContext _dbContext;

        public OperationshipRepository( AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Create(Operationship entity)
        {
            await _dbContext.Operationships.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Operationship entity)
        {
            _dbContext.Operationships.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Operationship> GetAll()
        {
           return _dbContext.Operationships.AsQueryable();
        }

        public async Task<Operationship> Update(Operationship entity)
        {
            _dbContext.Operationships.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
