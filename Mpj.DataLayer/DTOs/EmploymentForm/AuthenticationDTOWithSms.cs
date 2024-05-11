
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class AuthenticationDTOWithSms
    {
       
        [Display(Name = "رمز یکبار مصرف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "فرمت کد ملی صحیح نیست")]
        public string Password { get; set; }
        public DateTime Timer { get; set; }
        public string? Mobile { get; set; }
        public bool Valid { get; set; }
        public int StepWithTimer { get; set; }

    }
}
