
using Mpj.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.VisualBasic;
using Mpj.DataLayer.Utils;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class SpecificationsDTO
    {
        #region Identification details

        public long EmploymentId { get; set; }

        [StringLength(100)]
        [DisplayName("نام ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string Name { get; set; }
        [StringLength(100)]
        [DisplayName("نام خانوادگی (پسوند ذکر شود) ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string Family { get; set; }
        [DisplayName("جنسیت")]
        public Gender Gender { get; set; }
        
        [DisplayName("شماره شناسنامه ")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(20)]
        public string BirthCertificateId { get; set; }

        [DisplayName("حرف")]
        [StringLength(1)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string SerialBirthCertificateSection1 { get; set; }

        [DisplayName("کد دو رقمی")]
        [StringLength(2)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string SerialBirthCertificateSection2 { get; set; }

        [DisplayName("سریال")]
        [StringLength(6)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string SerialBirthCertificateSection3 { get; set; }


        [DisplayName("دین ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public Religion Religion { get; set; }
        [DisplayName("مذهب ")]
        public Sect Sect { get; set; }
        [StringLength(50)]
        [DisplayName("نام پدر ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string FatherName { get; set; }
        [StringLength(100)]
        [DisplayName("شغل پدر ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string JobFather { get; set; }
        [DisplayName("استان محل تولد ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceId { get; set; }

        [DisplayName("شهر محل تولد ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityId { get; set; }

        [DisplayName("استان محل صدور ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfIssueId { get; set; }

        [DisplayName("شهر محل صدور ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityOfIssueCityId { get; set; }

        [DisplayName("تاریخ تولد ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string BrithDate { get; set; }
        [DisplayName("وضعیت تاهل")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public MaritalStatus MaritalStatus { get; set; }

        [DisplayName("تعداد فرزندان")]
        [Range(0, 10, ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [ReverseRequiredIfCustom(nameof(MaritalStatus), Enums.MaritalStatus.Moeil,
            ErrorMessage = "این فیلد الزامی است")]
        public int? ChildrenCount { get; set; }
       
        #endregion

        #region Specifications of the duty system
        [Display(Name = "وضعیت نظام وظیفه ")]
        [Required(ErrorMessage = "این فیلد الزامی می باشد")]
        public MilitaryServiceStatus MilitaryServiceStatus { get; set; }
        [Display(Name = "ارگان محل خدمت")]
        [StringLength(100)]
        [RequiredIfCustom(nameof(MilitaryServiceStatus), (MilitaryServiceStatus.TheEndOfService),
            ErrorMessage = "این فیلد الزامی است")]
        public string? PlaceOfServiceOrgan { get; set; }
        [Display(Name = "علت معافیت ")]
        [StringLength(250)]
        [RequiredIfCustom(nameof(MilitaryServiceStatus), (MilitaryServiceStatus.MedicalExemption),
            ErrorMessage = "این فیلد الزامی است")]
        [RequiredIfCustomAttributeV1(nameof(MilitaryServiceStatus), (MilitaryServiceStatus.ExemptionFromSponsorship),
            ErrorMessage = "این فیلد الزامی است")]

        public string? ExemptionReason { get; set; }
        [Display(Name = "کد معافیت ")]
        [StringLength(20)]
        [RequiredIfCustomAttributeSecond(nameof(MilitaryServiceStatus), (MilitaryServiceStatus.MedicalExemption),
            ErrorMessage = "این فیلد الزامی است")]
        [RequiredIfCustomAttributeSecondV2(nameof(MilitaryServiceStatus), (MilitaryServiceStatus.ExemptionFromSponsorship),
            ErrorMessage = "این فیلد الزامی است")]
        public string? ExemptionCode { get; set; }
        [Display(Name = "تاریخ شروع")]
        [DataType(DataType.Date)]
        public string? MilitaryStartDate { get; set; }
        [Display(Name = "تاریخ دریافت کارت")]
        [DataType(DataType.Date)]
        public string? CardReceiptDate { get; set; }


        #endregion

        #region Physical characteristics
        [Display(Name = "قد (سانتی متر) ")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Range(100, 250, ErrorMessage = "مقدار مجاز از 100 تا 250 می باشد")]
        public int? Height { get; set; }
        [Display(Name = "وزن(کیلوگرم) ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Range(45, 300, ErrorMessage = "مقدار مجاز از 45 تا 300 می باشد")]
        public int? Weight { get; set; }
        [Display(Name = "مجموع شماره چشم")]
        [RegularExpression("([0-9.]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Range(1,10, ErrorMessage = "مقدار مجاز از 1 تا 10 می باشد")]
        [RequiredIfCustom(nameof(UseOfGlasses), true,
            ErrorMessage = "این فیلد الزامی است")]
        public decimal? TotalNumberOfEyes { get; set; }
        [Display(Name = "آیا از عینک استفاده می کنید ؟ ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]

        public bool UseOfGlasses { get; set; }
        [Display(Name = "وضعیت جسمانی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public PhysicalCondition PhysicalCondition { get; set; }

        [Display(Name = "توضیح پیرامون بیماری یا نقص عضو")]
        [RequiredIfCustom(nameof(PhysicalCondition), PhysicalCondition.PhysicallyDisabled,
            ErrorMessage = "این فیلد الزامی است")]
        public string? DescriptionOfPhysicalCondition { get; set; }

        #endregion

        #region Insurance history
        [Display(Name = "ماه")]
        [StringLength(4)]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public string? InsuranceHistoryMonth { get; set; }
        [Display(Name = "سال")]
        [StringLength(4)]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public string? InsuranceHistoryYear { get; set; }

        #endregion

        #region Employment in the group
        [Display(Name = "آیا سابقه اشتغال در گروه صنعتی جهان آرا را دارید ؟ ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public YesORNo HasEmploymentHistory { get; set; }
        [Display(Name = "محل کار")]
        [StringLength(200)]
        [RequiredIfCustom(nameof(HasEmploymentHistory), YesORNo.Yes,
            ErrorMessage = "این فیلد الزامی است")]
        public string? PlaceOfWork { get; set; }
        [Display(Name = "کد پرسنلی")]
        [StringLength(100)]
        [RequiredIfCustom(nameof(HasEmploymentHistory), YesORNo.Yes,
            ErrorMessage = "این فیلد الزامی است")]
        public string? PersonalCode { get; set; }
        [Display(Name = "گواهینامه رانندگی ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        //public List<SelectedListElement> DrivingLicences { get; set; }
        public List<int> DrivingLicences { get; set; }
        [Display(Name = "وضعیت اشتغال")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public EmploymentStatus EmploymentStatus { get; set; }
        [Display(Name = "حقوق پیشنهادی(ریال) ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        //[DisplayFormat(DataFormatString = "{0:0.#}")]
        [StringLength(13, ErrorMessage = "مقدار مجاز بین 50,000,000 تا1,000,000,000 می باشد")]
        //[Range(50000000,1000000000,  ErrorMessage = "مقدار مجاز بین 50,000,000 تا1,000,000,000 می باشد")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public string ProposedSalary { get; set; }

        #endregion

        #region residence address
        [DisplayName("استان")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ResidenceProvinceId { get; set; }
        [DisplayName("شهر")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ResidenceCityId { get; set; }
        [DisplayName("کد پستی ")]
        [StringLength(20)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string ResidencePostalCode { get; set; }

        [DisplayName("آدرس ")]
        [StringLength(450)]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string Address { get; set; }
        [DisplayName("مدت سکونت(ماه) ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public byte ResidencePeriodByMonth { get; set; }
        [DisplayName("مدت سکونت(سال) ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public byte ResidencePeriodByYear { get; set; }
        [DisplayName("تلفن محل سکونت(با ذکر کد شهر) ")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(15)]
        public string ResidencePhone { get; set; }

        #endregion

        #region ProvienceAndCity

        public CascadingDTO? CascadingDto { get; set; }

        #endregion
        [DisplayName("تعداد همسران")]
        [Range(0, 4, ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [RegularExpression("([0-4]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public byte SpouseCount { get; set; }
       public List<SpouseDTO>? Spouse { get; set; }
    }
}
