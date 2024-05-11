using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpj.DataLayer.Entities.Common;
using Mpj.DataLayer.Entities.ProvinceAndCity;

namespace Mpj.DataLayer.Entities.EmploymentForm
{
    public class WorkExperience:BaseEntity
    {
        #region propeties
        [DisplayName("عنوان شغل")]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? JobTitle { get; set; }
        [DisplayName("استان محل کار")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        public long? ProvinceOfJobId { get; set; }
        [DisplayName("شهر محل کار")]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        public long? CityOfJobId { get; set; }
        [DisplayName("نام شرکت")]
       // [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(200)]
        public string? CompanyName { get; set; }
        [DisplayName("سال شروع به کار")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        
        public int? YearOfStartingJob { get; set; }
        [DisplayName("سال ترک کار")]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        //[Required(ErrorMessage = "این فیلد الزامی است")]
        
        public int? YearOfEndingJob { get; set; }
        [DisplayName("علت ترک کار")]
        [StringLength(450)]
        public string? ReasonForLeavingWork { get; set; }

        

        #endregion
        #region Relation
        public Province ProvinceOfJob { get; set; }
        public City CityOfJob { get; set; }
        public Employment Employment { get; set; }
        public long EmploymentId { get; set; }
        #endregion

    }
}
