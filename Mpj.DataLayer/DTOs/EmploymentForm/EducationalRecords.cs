using Mpj.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Mpj.DataLayer.Entities.Common;
using Mpj.DataLayer.Entities.ProvinceAndCity;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class EducationalRecords : BaseEntity
    {
        #region Educational records
        [DisplayName("مدرک تحصیلی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public DegreeOfEducation DegreeOfEducation { get; set; }
        [DisplayName("استان محل تحصیل *")]
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
        [Required(ErrorMessage = "این فیلد الزامی است")]

        public int YearOfStartingEducation { get; set; }
        [DisplayName("سال تحصیلی(پایان)")]
        [Required(ErrorMessage = "این فیلد الزامی است")]

        public int YearOfEndingEducation { get; set; }
        [DisplayName("معدل")]
        [RegularExpression("([0-9.]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Range(10, 20, ErrorMessage = "مقدار مجاز از 10 تا 12 می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public decimal Avg { get; set; }
        [DisplayName("مرکز آموزشی")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(150)]
        public string CentralEducation { get; set; }
        public string ProvinceOfPlaceOfStudy { get; set; }
        public string CityOfPlaceOfStudy { get; set; }
       public bool IsEditable { get; set; }
       public bool IsEndOfDegreeOfEducation { get; set; }
        #endregion

    }
}
