
using System.ComponentModel.DataAnnotations;
using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class AuthenticationDTO
    {
        [Display(Name = "کد ملی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        [MinLength(10, ErrorMessage = "کد ملی باید 10 رقمی باشد"), MaxLength(10, ErrorMessage = "کد ملی باید 10 رقمی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "فرمت کد ملی صحیح نیست")]
        public string NationCode { get; set; }
        [Display(Name = "موبایل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        [MinLength(11, ErrorMessage = " موبایل باید 11 رقمی باشد"), MaxLength(11, ErrorMessage = " موبایل باید 11 رقمی باشد")]
        [RegularExpression("(\\+98|0)?9\\d{9}", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public string Mobile { get; set; }

        //public string? Key { get; set; }
        //public bool? IsConfirm { get; set; }
        //public EmploymentLoginResultenum? EmploymentLoginResult { get; set; }
        //public long? EmploymentId { get; set; }
       


    }
}
