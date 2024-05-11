
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mpj.DataLayer.Entities.Common;
using Mpj.DataLayer.Entities.ProvinceAndCity;

namespace Mpj.DataLayer.Entities.EmploymentForm
{
    public class Sponsorship:BaseEntity
    {
        #region Properties
        [DisplayName("شغل همسر")]
        [StringLength(100)]
        public string? SpouseJob { get; set; }
        [DisplayName("شماره همراه همسر")]
        [StringLength(11)]
        public string? SpouseMobile { get; set; }
        [StringLength(100)]
        [DisplayName("نام")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? Name { get; set; }
        [StringLength(100)]
        [DisplayName("نام خانوادگی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? Family { get; set; }
        [DisplayName("جنسیت")]
        public byte Gender { get; set; }
        [DisplayName("تاریخ تولد")]
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public DateTime? BrithDate { get; set; }
        [DisplayName("شماره شناسنامه")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(20)]
        public string? BirthCertificateId { get; set; }
        [StringLength(50)]
        [DisplayName("نام پدر")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? FatherName { get; set; }

        [Display(Name = "کد ملی")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        [StringLength(10)]
        public string? NationCode { get; set; }
        [DisplayName("استان محل تولد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceId { get; set; }
        [DisplayName("استان محل صدور")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfIssueId { get; set; }
        [DisplayName("وضعیت تاهل")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte? MaritalStatus { get; set; }

        [Display(Name = "آیا تحت پوشش است ؟")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public bool? IsCovered { get; set; } = true;
        [DisplayName("نسبت")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte? Relation { get; set; }
        [DisplayName("کد بیمه پایه")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte? BasicInsurance { get; set; }
        [Display(Name = "سریال بیمه")]
        [StringLength(50)]
        public string? SerialInsurance { get; set; }
        #endregion
        #region Relation
        public Employment Employment { get; set; }
        public long EmploymentId { get; set; }
        #endregion
    }
}
