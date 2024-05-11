
namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class SupplementaryInfoStepDTO
    {
        public FurtherInformationDTO InformationDto { get; set; }
        public List<SponsershipDTO>? SponsershipDto { get; set;}
        public AuthorizationDTO? Authorization { get; set; }
        public CascadingDTO? CascadingDto { get; set; }
        public int Selected { get; set; }
        public bool IsChild { get; set; } = false;
    }
}
