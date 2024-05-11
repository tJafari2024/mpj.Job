
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class EditItemForEmploymentDTO
    {
        public string FiledValue { get; set; }
        public FieldName FieldName { get; set; }
       public long EmploymentId { get; set; }
        
    }
}
