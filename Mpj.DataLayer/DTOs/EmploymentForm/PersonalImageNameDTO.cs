using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class PersonalImageNameDTO
    {

        [DisplayName("عکس پرسنلی *")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        public string PersonalImageName { get; set; }
        private PersonalImageDTO PersonalImageDto { get; set; }
    }
    public class PersonalImageNameMem
    {

        [DisplayName("عکس پرسنلی *")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        public string PersonalImageName { get; set; }
        
    }
}
