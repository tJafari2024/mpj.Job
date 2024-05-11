using Mpj.DataLayer.DTOs.EmploymentForm;
using System.ComponentModel.DataAnnotations;

namespace Mpj.DataLayer.Utils
{
    public class CompareValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            EducationalRecordsDTO app = value as EducationalRecordsDTO;
            if (app.YearOfStartingEducation> app.YearOfEndingEducation)
            {
                ErrorMessage = "سال پایان باید بزرگتر مساوی سال شروع باشد";
                return false;
            }
            return true;
        }
    }
}
