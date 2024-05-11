using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.Common;
using Mpj.DataLayer.Entities.ProvinceAndCity;
using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.Entities.EmploymentForm
{
    public class EducationalRecode:BaseEntity
    {
        #region Properties
        [DisplayName("مدرک تحصیلی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public DegreeOfEducation? DegreeOfEducation { get; set; }
        [DisplayName("استان محل تحصبل")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfPlaceOfStudyId { get; set; }
        [DisplayName("شهر محل تحصیل")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityOfPlaceOfStudyId { get; set; }

        [DisplayName("رشته تحصیلی")]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(100)]
        public string? FieldOfStudy { get; set; }
        [DisplayName("سال تحصیلی(شروع)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
       
        public int? YearOfStartingEducation { get; set; }
        [DisplayName("سال تحصیلی(پایان)")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        public int? YearOfEndingEducation { get; set; }
        [DisplayName("معدل")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public decimal? Avg { get; set; }

        [DisplayName("مرکز آموزشی")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(150)]
        public string? CentralEducation { get; set; }

        public bool IsEndOfDegreeOfEducation { get; set; }=false;

        // public bool IsLastOfDegreeOfEducation { get; set; } = false;
        #endregion

        #region Relation


        public Province ProvinceOfPlaceOfStudy { get; set; }
        public City CityOfPlaceOfStudy { get; set; }
        public Employment Employment { get; set; }
        public long EmploymentId { get; set; }
        #endregion
    }
}
