
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class AcquaintancesDTO
    {
        #region Familiar
        [DisplayName("نام و نام خانوادگی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string FirstFamiliarFullName { get; set; }
        [DisplayName("شغل و سمت")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string FirstFamiliarJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("(\\+98|0)?9\\d{9}", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(11)]
        public string FirstFamiliarMobile { get; set; }

        [DisplayName("نام و نام خانوادگی ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string SecondFamiliarFullName { get; set; }
        [DisplayName("شغل و سمت")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string SecondFamiliarJob { get; set; }
        [DisplayName("شماره همراه ")]
        [RegularExpression("(\\+98|0)?9\\d{9}", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(11)]
        public string SecondFamiliarMobile { get; set; }
        [DisplayName("نام و نام خانوادگی ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string AccessiblePersonFullName { get; set; }
        [DisplayName("شغل و سمت")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string AccessiblePersonJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("(\\+98|0)?9\\d{9}", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(11)]
        public string AccessiblePersonMobile { get; set; }

        [DisplayName("نام و نام خانوادگی")]
        [StringLength(200)]
        public string? RepresentativeFullName { get; set; }
        [DisplayName("شغل و سمت")]

        [StringLength(200)]
        public string? RepresentativeJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("(\\+98|0)?9\\d{9}", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]

        [StringLength(11)]
        public string? RepresentativeMobile { get; set; }


        #endregion

    }
}
