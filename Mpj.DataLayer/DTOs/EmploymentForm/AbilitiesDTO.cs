
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Utils;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class AbilitiesDTO
    {
        #region General abilities
        [DisplayName("توانایی کار در مشاغل کارمندی")]
        public bool AbilityToWorkInClericalJobs { get; set; }
        [DisplayName("توانایی مسافرت به عنوان ماموریت")]
        public bool AbilityToTravelAsAMission { get; set; }
        [DisplayName("توانایی کار در نوبت کاری")]
        public bool AbilityToWorkInShifts { get; set; }

        #endregion

        #region Specialized abilities
        [DisplayName("عنوان توانایی")]
        public string? AbilityTitle { get; set; }

        #endregion

        #region Other
        [DisplayName("دارای حادثه شغلی در طول دوران کار")]
        public bool HavingAnAccident { get; set; }
        [DisplayName("توضیح حادثه شغلی")]
        public string? DescriptionOfAccident { get; set; }
        [DisplayName("فعالیت های ورزشی، علائق و سرگرمی ها")]
        public string? Entertainments { get; set; }
        [DisplayName("ایده، توانایی و یا هر مهارتی به غیر از مهارت های ذکر شده")]
        public string? Ideas { get; set; }
        [DisplayName("فایل رزومه")]
        //public string? ResumeFile { get; set; }
        public IFormFile? ResumeFile { get; set; }
        public string? ResumeFileUrl { get; set; }
        #endregion
    }

    public class AbilitiesDTOMem
    {
        #region General abilities
        [DisplayName("توانایی کار در مشاغل کارمندی")]
        public bool AbilityToWorkInClericalJobs { get; set; }
        [DisplayName("توانایی مسافرت به عنوان ماموریت")]
        public bool AbilityToTravelAsAMission { get; set; }
        [DisplayName("توانایی کار در نوبت کاری")]
        public bool AbilityToWorkInShifts { get; set; }

        #endregion

        #region Specialized abilities
        [DisplayName("عنوان توانایی")]
        public string? AbilityTitle { get; set; }

        #endregion

        #region Other
        [DisplayName("دارای حادثه شغلی در طول دوران کار")]
        public bool HavingAnAccident { get; set; }
        [DisplayName("توضیح حادثه شغلی")]
        [RequiredIfCustom(nameof(HavingAnAccident), true,
            ErrorMessage = "این فیلد الزامی است")]
        public string? DescriptionOfAccident { get; set; }
        [DisplayName("فعالیت های ورزشی، علائق و سرگرمی ها")]
        public string? Entertainments { get; set; }
        [DisplayName("ایده، توانایی و یا هر مهارتی به غیر از مهارت های ذکر شده")]
        public string? Ideas { get; set; }
        [DisplayName("انتخاب فایل رزومه")]
        public string? ResumeFile { get; set; }
        #endregion
    }
}
