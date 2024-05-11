using Microsoft.EntityFrameworkCore;
using Mpj.DataLayer.Context;
using Mpj.DataLayer.Entities.Common;

namespace Mpj.DataLayer.Repository
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MpgDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(MpgDbContext context)
        {
            _context = context;
            this._dbSet = _context.Set<TEntity>();
        }

        public async Task AddEntity(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.LastUpdateDate = entity.CreateDate;
            if(!entity.IsDelete)
                entity.IsDelete = false;
            await _dbSet.AddAsync(entity);
        }

        public async ValueTask DisposeAsync()
        {
            if (_context != null)
                await _context.DisposeAsync();
        }

        public async Task<TEntity> GetEntityById(long entityId)
        {
            return await _dbSet.SingleOrDefaultAsync(i => i.Id == entityId);
        }

       

        public void EditEntity(TEntity entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _dbSet.Update(entity);

        }

        public void DeleteEntity(TEntity entity)
        {
            entity.IsDelete = true;
            EditEntity(entity);
        }

        public async Task DeleteEntity(long id)
        {
            TEntity entity = await GetEntityById(id);
            if (entity != null)
                DeleteEntity(entity);
        }

        public void DeletePermanent(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeletePermanent(long id)
        {
            TEntity entity = await GetEntityById(id);
            if (entity != null)
                DeletePermanent(entity);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsQueryable();
        }

        public void DeleteRange(List<TEntity> lstList)
        {
            _dbSet.RemoveRange(lstList);
        }

        public async Task SaveChanges()
        {

            await _context.SaveChangesAsync();
        }
        public async Task AddRangeEntities(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                await AddEntity(entity);
                 await  SaveChanges();
            }
        }
        public void DeletePermanentEntities(List<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }

    }
}
