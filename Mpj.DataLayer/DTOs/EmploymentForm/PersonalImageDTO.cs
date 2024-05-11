using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class PersonalImageDTO
    {

        [DisplayName("عکس پرسنلی")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        public IFormFile? PersonalImage { get; set; }
        
        // public IFormFile File { get; set; }
        //[DisplayName("عکس پرسنلی")]
        //public string PersonalImage { get; set; }

        [DisplayName("عکس پرسنلی *")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "این فیلد الزامی است")]
        public string? PersonalImageName { get; set; }
    }
}
