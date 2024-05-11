
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Repository;
using System.Drawing;
using System.Drawing.Imaging;

namespace Mpj.Application.Services.Implementations
{
    public class EditedItemsForEmploymentService : IEditedItemsForEmploymentService
    {
        #region Constructor

        private readonly IGenericRepository<EditedItemsForEmployment> _repository;
        public EditedItemsForEmploymentService(IGenericRepository<EditedItemsForEmployment> repository)
        {
            _repository = repository;
          
        }

        #endregion
        public async Task<bool> InsertItemForEmployment(FieldName filedname,string filedvalue,long id)
        {
            try
            {
                var filed = new EditedItemsForEmployment
                {
                    FiledName = filedname,
                    FiledValue = filedvalue,
                    EmploymentId = id
                };
                await _repository.AddEntity(filed);
                await _repository.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }
       
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
           

        }

        

       public async Task<bool> CheckExist(FieldName filedname, string filedvalue, long id)
        {
            return _repository.GetQuery().AsQueryable().Any(emp => emp.Id == id && emp.FiledName == filedname && emp.FiledValue==filedvalue);
        }

       
    }
}
