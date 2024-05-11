using Mpj.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;
using Mpj.DataLayer.Enums;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;
using System.Security.AccessControl;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using Mpj.DataLayer.Entities.ProvinceAndCity;
using Mpj.DataLayer.Entities.Site;
using System.Resources;

namespace Mpj.DataLayer.Entities.EmploymentForm
{
    public class Employment : BaseEntity
    {
        #region property

        #region Identification details


        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        [StringLength(10)]
        public string NationCode { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string Mobile { get; set; }

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
        [StringLength(200)]
        [DisplayName("عکس پرسنلی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? PersonalImage { get; set; }


        [DisplayName("شماره شناسنامه")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(20)]
        public string? BirthCertificateId { get; set; }
        [DisplayName("حرف")]
        [StringLength(1)]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        public string? SerialBirthCertificateSection1 { get; set; }

        [DisplayName("کد دو رقمی")]
        [StringLength(2)]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        public string? SerialBirthCertificateSection2 { get; set; }

        [DisplayName("سریال")]
        [StringLength(6)]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? SerialBirthCertificateSection3 { get; set; }
        [DisplayName("دین")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte Religion { get; set; }
        [DisplayName("مذهب")]
        // [Required(ErrorMessage = "این فیلد الزامی است")]
        public byte Sect { get; set; }
        [StringLength(50)]
        [DisplayName("نام پدر")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? FatherName { get; set; }
        [StringLength(100)]
        [DisplayName("شغل پدر")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? JobFather { get; set; }
        [DisplayName("استان محل تولد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceId { get; set; }

        [DisplayName("شهر محل تولد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityId { get; set; }

        [DisplayName("استان محل صدور")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfIssueId { get; set; }

        [DisplayName("شهر محل صدور")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityOfIssueCityId { get; set; }

        [DisplayName("تاریخ تولد")]
        [DataType(DataType.Date)]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public DateTime? BrithDate { get; set; }
        [DisplayName("وضعیت تاهل")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte? MaritalStatus { get; set; }

        //[DisplayName("وضعیت تکفل")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        //public byte? SponsorshipStatus { get; set; }
        //[DisplayName("تعداد افراد تحت تکفل")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        // public int? SponsorshipCount { get; set; }
        [DisplayName("تعداد فرزندان")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public byte? ChildrenCount { get; set; }
        [DisplayName("تعداد همسران")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public byte? SpouseCount { get; set; }
        //[DisplayName("شغل همسر")]
        //[StringLength(100)]
        //public string? SpouseJob { get; set; }
        //[DisplayName("شماره همراه همسر")]
        //[StringLength(11)]
        //public string? SpouseMobile { get; set; }
        #endregion

        #region Specifications of the duty system
        [Display(Name = "وضعیت نظام وظیفه")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public byte? MilitaryServiceStatus { get; set; }
        [Display(Name = "ارگان محل خدمت")]
        [StringLength(100)]
        public string? PlaceOfServiceOrgan { get; set; }

        [Display(Name = "علت معافیت")]
        [StringLength(250)]
        public string? ExemptionReason { get; set; }
        [Display(Name = "کد معافیت")]
        [StringLength(200)]
        public string? ExemptionCode { get; set; }
        [Display(Name = "تاریخ شروع")]
        [DataType(DataType.Date)]
        public DateTime? MilitaryStartDate { get; set; }
        [Display(Name = "تاریخ دریاغت کارت")]
        [DataType(DataType.Date)]
        public DateTime? CardReceiptDate { get; set; }


        #endregion

        #region Physical characteristics
        [Display(Name = "قد")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public int? Height { get; set; }
        [Display(Name = "وزن")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public int? Weight { get; set; }
        [Display(Name = "مجموع شماره چشم")]
        public decimal? TotalNumberOfEyes { get; set; }
        [Display(Name = "آیا از عینک استفاده می کنید ؟")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public bool? UseOfGlasses { get; set; }
        [Display(Name = "وضعیت جسمانی")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public byte? PhysicalCondition { get; set; }
        [Display(Name = "توضیح پیرامون بیماری یا نقص عضو")]
        [StringLength(450)]
        public string? DescriptionOfPhysicalCondition { get; set; }
        #endregion

        #region Insurance history
        [Display(Name = "ماه")]
        public byte? InsuranceHistoryMonth { get; set; }
        [Display(Name = "سال")]
        public byte? InsuranceHistoryYear { get; set; }

        #endregion

        #region Employment in the group
        [Display(Name = "آیا سابقه اشتغال در گروه صنعتی جهان آرا را دارید ؟")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public bool? HasEmploymentHistory { get; set; }
        [Display(Name = "محل کار")]
        [StringLength(200)]
        public string? PlaceOfWork { get; set; }
        [Display(Name = "کد پرسنلی")]
        [StringLength(100)]
        public string? PersonalCode { get; set; }
        [Display(Name = "گواهینامه رانندگی")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        [StringLength(100)]
        public string? DrivingLicences { get; set; }
        [Display(Name = "وضعیت اشتغال")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public byte EmploymentStatus { get; set; }
        [Display(Name = "حقوق پیشنهادی")]
        //[Required(ErrorMessage = "فیلد {0} الزامی می باشد")]
        public long? ProposedSalary { get; set; }

        #endregion

        #region residence address
        [DisplayName("استان")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ResidenceProvinceId { get; set; }
        [DisplayName("شهر")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ResidenceCityId { get; set; }
        [DisplayName("کد پستی")]
        [StringLength(20)]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? ResidencePostalCode { get; set; }

        [DisplayName("آدرس")]
        [StringLength(450)]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? Address { get; set; }
        [DisplayName("مدت سکونت(ماه)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte ResidencePeriodByMonth { get; set; }
        [DisplayName("مدت سکونت(سال)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public byte ResidencePeriodByYear { get; set; }
        [DisplayName("تلفن محل سکونت(با ذکر کد شهر)")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(15)]
        public string? ResidencePhone { get; set; }

        #endregion

        #region Familiar
        [DisplayName("نام و نام خانوادگی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? FirstFamiliarFullName { get; set; }
        [DisplayName("شفل و سمت")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? FirstFamiliarJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(11)]
        public string? FirstFamiliarMobile { get; set; }

        [DisplayName("نام و نام خانوادگی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? SecondFamiliarFullName { get; set; }
        [DisplayName("شفل و سمت")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? SecondFamiliarJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(11)]
        public string? SecondFamiliarMobile { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? AccessiblePersonFullName { get; set; }
        [DisplayName("شفل و سمت")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? AccessiblePersonJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(11)]
        public string? AccessiblePersonMobile { get; set; }

        [DisplayName("نام و نام خانوادگی")]
        [StringLength(200)]
        public string? RepresentativeFullName { get; set; }
        [DisplayName("شفل و سمت")]
        [StringLength(200)]
        public string? RepresentativeJob { get; set; }
        [DisplayName("شماره همراه")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [StringLength(11)]
        public string? RepresentativeMobile { get; set; }


        #endregion

        #region General abilities
        [DisplayName("توانایی کار در مشاغل کارمندی")]
        public bool? AbilityToWorkInClericalJobs { get; set; }
        [DisplayName("توانایی مسافرت به عنوان ماموریت")]
        public bool? AbilityToTravelAsAMission { get; set; }
        [DisplayName("توانایی کار در نوبت کاری")]
        public bool? AbilityToWorkInShifts { get; set; }

        #endregion

        #region Specialized abilities
        [DisplayName("عنوان توانایی")]
        [StringLength(500)]
        public string? AbilityTitle { get; set; }

        #endregion

        #region Other
        [DisplayName("دارای حادثه شغلی در طول دوران کار")]
        public bool? HavingAnAccident { get; set; }
        [DisplayName("توضیح حادثه شغلی")]
        [StringLength(1000)]
        public string? DescriptionOfAccident { get; set; }
        [DisplayName("فعالیت های ورزشی، علائق و سرگرمی ها")]
        [StringLength(1000)]
        public string? Entertainments { get; set; }
        [DisplayName("ایده، توانایی و یا هر مهارتی به غیر از مهارت های ذکر شده")]
        [StringLength(1000)]
        public string? Ideas { get; set; }
        [DisplayName("انتخاب فایل رزومه")]
        [StringLength(500)]
        public string? ResumeFile { get; set; }
        [DisplayName("رضایت")]
        [StringLength(1000)]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public string? SatisfactionRules { get; set; }
        #endregion

        #region FurtherInformation

        [DisplayName("شماره بیمه تامین اجتماعی")]
        [StringLength(50)]
        public string? InsuranceNumber { get; set; }
        [DisplayName("شماره حساب بانک تجارت")]
        [StringLength(50)]
        public string? TejaratBankNumber { get; set; }
        [DisplayName("شماره شبای بانک تجارت")]
        [StringLength(50)]
        public string? TejaratSheba { get; set; }
        [DisplayName("تاریخ ازدواج (بر اساس شناسنامه)")]
        [DataType(DataType.Date)]
        public DateTime? DateOfMarriage { get; set; }

        #endregion
        public bool? IsConfirmAbsorptionUnit { get; set; } = false;
        public bool? IsConfirmInspectionUnit { get; set; } = false;
        public bool? IsConfirmHumanResourceUnit { get; set; } = false;
        public int? TrackingCode { get; set; } = 0;

        public int? CountSendSms { get; set; } = 0;
        public DateTime? DateSendSms { get; set; }
        public int? Step { get; set; } = 1;
        public bool? UpdateMobile { get; set; }
        [StringLength(2500)]
        public string? DescriptionAbsorptionUnit { get; set; }
        public string? DescriptionInspectionUnit { get; set; }
        public string? DescriptionResourceUnit { get; set; }
        public bool? IsUploadDocument { get; set; } = false;

        #endregion

        #region Relation
        public Province Province { get; set; }
        public City City { get; set; }
        public Province ProvinceOfIssue { get; set; }
        public City CityOfIssueCity { get; set; }
        public Province ResidenceProvince { get; set; }
        public City ResidenceCity { get; set; }
        public ICollection<EducationalRecode> EducationalRecodes { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        public ICollection<Sponsorship> Sponsorships { get; set; }
        public ICollection<RegistrationDocuments> RegistrationDocuments { get; set; }
        public ICollection<EditedItemsForEmployment> EditedItemsForEmployments { get; set; }
        #endregion

    }
}
