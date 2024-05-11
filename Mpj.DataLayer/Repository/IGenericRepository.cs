
using Mpj.DataLayer.Entities.Common;

namespace Mpj.DataLayer.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQuery();
        Task AddEntity(TEntity entity);
        Task<TEntity> GetEntityById(long entityId);
        void EditEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        Task DeleteEntity(long id);
        void DeletePermanent(TEntity entity);
        Task DeletePermanent(long id);
        void DeleteRange(List<TEntity> lstList);
        Task SaveChanges();
        Task AddRangeEntities(List<TEntity> entities);
        void DeletePermanentEntities(List<TEntity> entities);
    }
}
