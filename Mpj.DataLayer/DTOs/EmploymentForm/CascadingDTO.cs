
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class CascadingDTO
    {
        public CascadingDTO()
        {
            States = new List<SelectListItem>();
            Cities = new List<SelectListItem>();
        }

        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> CityOfIssue { get; set; }
        public List<SelectListItem> ResidenceCity { get; set; }

        public long StateId { get; set; }
        public long CityId { get; set; }
        public long CityOfIssueId { get; set;}
        public long ResidenceCityId { get; set; }
    }
}
