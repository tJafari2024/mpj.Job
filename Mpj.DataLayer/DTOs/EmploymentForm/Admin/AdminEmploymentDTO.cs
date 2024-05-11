
using Mpj.DataLayer.Entities.EmploymentForm;

namespace Mpj.DataLayer.DTOs.EmploymentForm.Admin
{
    public class AdminEmploymentDTO
    {
        public FilterEmploymentDTO filterEmployment { get; set; }
        public List<EducationalRecode>? EducationalRecodes { get; set; }
        public List<WorkExperience>? WorkExperiences { get; set; }
        public Employment Employment { get; set; }
        public string Description { get; set; }
        public string id { get; set; }
    }
}
