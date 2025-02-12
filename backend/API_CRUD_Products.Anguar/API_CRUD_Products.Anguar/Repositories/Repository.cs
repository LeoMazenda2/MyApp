using API_CRUD_Products.Anguar.Context;
using Microsoft.EntityFrameworkCore;

namespace API_CRUD_Products.Anguar.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ProductsDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ProductsDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}





//using API_CRUD_Products.Anguar.Context;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace API_CRUD_Products.Anguar.Repositories
//{
//    public class Repository<T> : IRepository<T> where T : class
//    {
//        private readonly ProductsDbContext _context;
//        private readonly DbSet<T> _dbSet;
//        private readonly ILogger<Repository<T>> _logger;

//        public Repository(ProductsDbContext context, ILogger<Repository<T>> logger)
//        {
//            _context = context;
//            _dbSet = _context.Set<T>();
//            _logger = logger;
//        }

//        public async Task<IEnumerable<T>> GetAllAsync()
//        {
//            try
//            {
//                return await _dbSet.ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error retrieving all {typeof(T).Name}s: {ex.Message}");
//                throw new Exception($"An error occurred while fetching {typeof(T).Name}s.", ex);
//            }
//        }

//        public async Task<T> GetByIdAsync(int id)
//        {
//            try
//            {
//                var entity = await _dbSet.FindAsync(id);
//                if (entity == null)
//                {
//                    _logger.LogWarning($"{typeof(T).Name} with ID {id} not found.");
//                    return null;  // Or throw a custom NotFoundException if preferred
//                }
//                return entity;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error retrieving {typeof(T).Name} with ID {id}: {ex.Message}");
//                throw new Exception($"An error occurred while fetching {typeof(T).Name} with ID {id}.", ex);
//            }
//        }

//        public async Task AddAsync(T entity)
//        {
//            try
//            {
//                await _dbSet.AddAsync(entity);
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error adding {typeof(T).Name}: {ex.Message}");
//                throw new Exception($"An error occurred while adding a new {typeof(T).Name}.", ex);
//            }
//        }

//        public async Task UpdateAsync(T entity)
//        {
//            try
//            {
//                _dbSet.Update(entity);
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error updating {typeof(T).Name}: {ex.Message}");
//                throw new Exception($"An error occurred while updating {typeof(T).Name}.", ex);
//            }
//        }

//        public async Task DeleteAsync(int id)
//        {
//            try
//            {
//                var entity = await _dbSet.FindAsync(id);
//                if (entity == null)
//                {
//                    _logger.LogWarning($"{typeof(T).Name} with ID {id} not found.");
//                    return; // Or throw a custom NotFoundException if preferred
//                }

//                _dbSet.Remove(entity);
//                await _context.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Error deleting {typeof(T).Name} with ID {id}: {ex.Message}");
//                throw new Exception($"An error occurred while deleting {typeof(T).Name} with ID {id}.", ex);
//            }
//        }
//    }
//}
