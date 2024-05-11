
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Mpj.DataLayer.Enums
{
    public enum Gender
    {
        [Display(Name = "مرد ")]
        Men = 0,
        [Display(Name = "زن")]
        Women = 1,

    }
    public enum SponsorshipStatus
    {
        [Display(Name = "تحت تکفل ندارم ")]
        NotHave = 0,
        [Display(Name = "تحت تکفل دارم")]
        Have = 1,

    }
    public enum MaritalStatus
    {
        [Display(Name = "مجرد ")]
        Single = 0,
        [Display(Name = "متاهل")]
        Married = 1,
        [Display(Name = "معیل")]
        Moeil = 2,

    }
    public enum FieldName
    {
        [Display(Name = "آدرس ")]
        Address = 0,
        [Display(Name = "وضعیت جسمانی")]
        PhysicalCondition = 1,
        [Display(Name = "علت معافیت")]
        ExemptionReason = 2,
        [Display(Name = "مدرک تحصیلی")]
        DegreeOfEducation = 3,

    }
    public enum MilitaryServiceStatus
    {
        [Display(Name = "پایان خدمت ")]
        TheEndOfService = 0,
        [Display(Name = "معافیت پزشکی")]
        MedicalExemption = 1,
        [Display(Name = "معافیت کفالت")]
        ExemptionFromSponsorship = 2,
    }
    public enum PhysicalCondition
    {
        [Display(Name = "سالم ")]
        Healthy = 0,
        [Display(Name = "دارای نقص جسمانی")]
        PhysicallyDisabled = 1

    }
    public enum DrivingLicences
    {
        [Display(Name = "لیفتراک ")]
        Forklift = 0,
        [Display(Name = "جرثقیل")]
        Crane = 1,
        [Display(Name = "تراکتور")]
        Tractor = 2,
        [Display(Name = "پایه یک")]
        BaseOne = 3,
        [Display(Name = "پایه دو")]
        BaseTwo = 4,
        [Display(Name = "پایه سه")]
        BaseThree = 5,
        [Display(Name = "موتورسیکلت")]
        Motorcycle = 6,
        [Display(Name = "هیچ کدام")]
        None = 7,

    }
    public enum EmploymentStatus
    {
        [Display(Name = "مشغول به کار - تمام وقت ")]
        WorkingFullTime = 0,
        [Display(Name = "مشغول به کار - پاره وقت")]
        EmployedPartTime = 1,
        [Display(Name = "بیکار")]
        Unemployed = 2,


    }
    public enum YesORNo
    {
        [Display(Name = "خیر")]
        No = 0,
        [Display(Name = "بله")]
        Yes = 1,



    }
    public enum Religion
    {
        [Display(Name = "اسلام")]
        Eslam = 0,
        [Display(Name = "مسیحی")]
        Masihi = 1,
        [Display(Name = "یهودی")]
        Yahoodi = 2,
        [Display(Name = "زرتشت")]
        Zartosht = 3,

    }

    public enum Sect
    {
        [Display(Name = "شیعه")]
        Shieh = 0,
        [Display(Name = "سنی")]
        Sonni = 1,
        [Display(Name = "")]
        Notthing = 2,
    }
    public enum SendSmsType
    {
        [Display(Name = "برای احراز هویت")]
        ForAuthentication = 1,
        [Display(Name = "برای کد رهگیری")]
        ForTrackingCode = 2,
    }
    public enum DegreeOfEducation
    {
        [Display(Name = "سیکل ")]
        Sikle = 0,
        [Display(Name = "دیپلم")]
        Diplom = 1,
        [Display(Name = "فوق دیپلم")]
        PhogheDiplom = 2,
        [Display(Name = "کارشناسی")]
        Karshenasi = 3,
        [Display(Name = "کارشناسی ارشد")]
        KarshenasiArshad = 4,
        [Display(Name = "دکتری")]
        Doctora = 5,
    }
    public enum EmploymentLoginResultenum
    {
        [Display(Name = "اطلاعات کاربر در سامانه موجود موجود است")]
        Success = 0,
        [Display(Name = "کاربر اقدام به ورود با شماره موبایل دیگری کرده است")]
        Warning = 1,
        [Display(Name = "اطلاعاتی از کاربر در سامانه موجود نمی باشد")]
        NotExists

    }
    public enum TypeDocument
    {
        [Display(Name = "تصویر صفحه اول شناسنامه ")]
        PageOne = 0,
        [Display(Name = "تصویر صفحه دوم شناسنامه")]
        PageTwo = 1,
        [Display(Name = "تصویر صفحه سوم شناسنامه")]
        PageThree = 2,
        [Display(Name = "تصویر صفحه توضیحات")]
        PageDescription = 3,
        [Display(Name = "تصویر صفحه اول شناسنامه همسر")]
        SponsorshipPage1 = 4,
        [Display(Name = "تصویر صفحه دوم شناسنامه همسر")]
        SponsorshipPage2 = 5,
        [Display(Name = "تصویر صفحه سوم شناسنامه همسر")]
        SponsorshipPage3 = 6,
        [Display(Name = "تصویر صفحه توضیحات شناسنامه همسر ")]
        SponsorshipDescription = 7,
        [Display(Name = "تصویر صفحه اول شناسنامه فرزند")]
        ChildPage1 = 8,
        [Display(Name = "تصویر کارت ملی")]
        NationCodePage1 = 9,
        [Display(Name = "تصویر پشت کارت ملی")]
        NationCodePage2 = 10,
        [Display(Name = "تصویر کارت ملی همسر")]
        SponsorshipNationPage1 = 11,
        [Display(Name = "تصویر پشت کارت ملی همسر")]
        SponsorshipNationPage2 = 12,
        [Display(Name = "تصویر کارت پایان خدمت / معافیت")]
        TheEndOfServiceImage = 13,
        [Display(Name = "تصویر سابقه بیمه")]
        InsuranceHistory = 14,
        [Display(Name = "تصویر آخرین مدرک تحصیلی")]
        DegreeOfEducation = 15,
        //[Display(Name = "شماره بیمه تامین اجتماعی")]
        //NumberOfBimeh = 16,
        //[Display(Name = "شماره حساب بانک تجارت")]
        //TejaratBankNumber = 17,
        //[Display(Name = "شماره شبای بانک تجارت")]
        //TejaratBankSheba = 18,
        //[Display(Name = "تاریخ ازدواج(براساس شناسنامه)")]
        //MaritalDate = 19,

    }
    public enum Relation
    {
        [Display(Name = "همسر")]
        Spouse = 0,
        [Display(Name = "فرزند")]
        Child = 1,
       
    }
    public enum BasicInsurance
    {
        [Display(Name = "تامین اجتماعی")]
         Tamin = 0,
        [Display(Name = "خدمات درمانی")]
        KhadatDarmani = 1,

    }
}
