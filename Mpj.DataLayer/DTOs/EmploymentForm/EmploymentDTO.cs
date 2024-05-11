namespace Mpj.DataLayer.DTOs.EmploymentForm
{
   
    public class EmploymentDTO
    {
       public PersonalImageNameMem? PersonalImage { get; set; }
        public AuthenticationDTO? Authentication { get; set; }
        public AuthorizationDTO? Authorization { get; set; }
        public SpecificationsDTO? Specification { get; set; }
        public List<EducationalRecords>? EducationalRecord { get; set; }
        public List<WorkExperienceRecords>? WorkExperience { get; set; }
        public AcquaintancesDTO? Acquaintances { get; set; }
        public AbilitiesDTOMem? Abilities { get; set; }
        public CascadingDTO? Cascading { get; set; }
        public EndStepDTO EndStep { get; set; }
        public DocumentFileDTO DocumentFile { get; set; }
       


    }
}
