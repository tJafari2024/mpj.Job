
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mpj.DataLayer.Entities.Common;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class WorkExperienceRecords:BaseEntity
    {
        #region work experience
        [DisplayName("عنوان شغل")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string JobTitle { get; set; }
        [DisplayName("استان محل کار")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfJobId { get; set; }
        [DisplayName("شهر محل کار")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityOfJobId { get; set; }
        [DisplayName("نام شرکت")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string CompanyName { get; set; }
        [DisplayName("سال شروع به کار")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
       
        public int YearOfStartingJob { get; set; }
        [DisplayName("سال ترک کار")]
       [Required(ErrorMessage = "این فیلد الزامی است")]
       
        public int YearOfEndingJob { get; set; }
        [DisplayName("علت ترک کار")]
        [StringLength(450)]
        public string ReasonForLeavingWork { get; set; }
        public string ProvinceOfJob { get; set; }
        public string CityOfPlaceOfJob { get; set; }



        #endregion
    }
}
