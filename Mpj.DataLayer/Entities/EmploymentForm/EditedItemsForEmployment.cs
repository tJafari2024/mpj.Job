
using Mpj.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Mpj.DataLayer.Entities.Common;

namespace Mpj.DataLayer.Entities.EmploymentForm
{
    public class EditedItemsForEmployment:BaseEntity
    {
        public FieldName FiledName { get; set; }
        public string FiledValue { get; set; }
        public long EmploymentId { get; set; }
       public Employment Employment { get; set; }
    }
}
