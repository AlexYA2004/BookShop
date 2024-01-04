﻿using BookShop.DataBaseLogic.Interfaces;
using BookShop.Domain.Entities;

namespace BookShop.DataBaseLogic.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Create(User entity)
        {
            await _dbContext.Users.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }


        public async Task Delete(User entity)
        {
            _dbContext.Users.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users.AsQueryable();
        }

        public async Task<User> Update(User entity)
        {
            _dbContext.Users.Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
