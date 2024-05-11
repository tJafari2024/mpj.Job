
using Mpj.DataLayer.Enums;

namespace Mpj.Application.Services.Interfaces
{
    public interface IEditedItemsForEmploymentService : IAsyncDisposable
    {
        Task<bool> InsertItemForEmployment(FieldName filedname, string filedvalue, long id);
        Task<bool> CheckExist(FieldName filedname, string filedvalue, long id);
    }
}
