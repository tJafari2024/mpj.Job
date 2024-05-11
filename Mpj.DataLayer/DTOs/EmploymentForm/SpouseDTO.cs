using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class SpouseDTO
    {
        [DisplayName("شغل همسر")]
        [StringLength(100)]
        public string? SpouseJob { get; set; }
        [DisplayName("شماره همراه همسر")]
        [StringLength(11)]
        [RegularExpression("(\\+98|0)?9\\d{9}", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public string? SpouseMobile { get; set; }

        [StringLength(100)]
        [DisplayName("نام")]
        public string? Name { get; set; }
        [StringLength(100)]
        [DisplayName("نام خانوادگی")]
       
        public string? Family { get; set; }
        [DisplayName("جنسیت")]
        public byte Gender { get; set; }
        [DisplayName("تاریخ تولد")]
        public string? BrithDate { get; set; }
        [DisplayName("شماره شناسنامه")]
        [StringLength(20)]
        public string? BirthCertificateId { get; set; }
        [StringLength(50)]
        [DisplayName("نام پدر")]
        public string? FatherName { get; set; }

        [Display(Name = "کد ملی")]
        [StringLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "فرمت کد ملی صحیح نیست")]

        public string? NationCode { get; set; }
        [DisplayName("استان محل تولد")]
       
        public long? ProvinceId { get; set; }
        [DisplayName("استان محل صدور")]
        public long? ProvinceOfIssueId { get; set; }
        [DisplayName("وضعیت تاهل")]
        public byte? MaritalStatus { get; set; }

        [Display(Name = "آیا تحت پوشش است ؟")]
        public bool IsCovered { get; set; } = true;
        [DisplayName("نسبت")]
        
        public byte? Relation { get; set; }
        [DisplayName("کد بیمه پایه")]
        public byte? BasicInsurance { get; set; }
        [Display(Name = "سریال بیمه")]
        [StringLength(50)]
        public string? SerialInsurance { get; set; }
        public long EmploymentId { get; set; }
    }
}
