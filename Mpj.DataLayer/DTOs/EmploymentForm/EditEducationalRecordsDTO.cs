using Mpj.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class EditEducationalRecordsDTO:EducationalRecordsDTO
    {
        public long Id { get; set; }
    }
}
