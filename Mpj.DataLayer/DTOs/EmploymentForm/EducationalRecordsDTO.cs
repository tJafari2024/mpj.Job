using Mpj.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mpj.DataLayer.Utils;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    //[CompareValidation]
    public class EducationalRecordsDTO
    {
        #region Educational records

        public long Id { get; set; }
        
        [DisplayName("مدرک تحصیلی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public DegreeOfEducation DegreeOfEducation { get; set; }
        [DisplayName("استان محل تحصیل")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfPlaceOfStudyId { get; set; }
        [DisplayName("شهر محل تحصیل")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityOfPlaceOfStudyId { get; set; }

        [DisplayName("رشته تحصیلی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(100)]
        public string FieldOfStudy { get; set; }
        [DisplayName("سال تحصیلی(شروع)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
       
        public int YearOfStartingEducation { get; set; }
        [DisplayName("سال تحصیلی(پایان)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        
        public int YearOfEndingEducation { get; set; }
        [DisplayName("معدل")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [Range(10, 20, ErrorMessage = "مقدار مجاز از 10 تا 20 می باشد")]
        public decimal? Avg { get; set; }
        
        [DisplayName("مرکز آموزشی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(150,ErrorMessage = "حداکثر طول مجاز 150 کراکتر می باشد")]
        public string CentralEducation { get; set; }
        public string? ProvinceOfPlaceOfStudy { get; set; }
        public string? CityOfPlaceOfStudy { get; set; }
        [DisplayName("آخرین مدرک تحصیلی می باشد")]
        public bool IsEndOfDegreeOfEducation { get; set; } 


        #region ProvienceAndCity

        public CascadingDTO? CascadingDto { get; set; }

        #endregion

        #endregion
    }
}
