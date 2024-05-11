
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;

namespace Mpj.Application.Services.Interfaces
{
    public interface IEducationalRecordService:IAsyncDisposable
    {
        
        Task<List<EducationalRecode>> GetEducationRecode(long employmentId);
        Task<List<EducationalRecode>> GetEducationRecodeIgnoreFilter(long employmentId);
        Task<EducationResult> AddEducation(List<EducationalRecode> lst, long id);
    }
    public enum EducationResult
    {
        Success,
        Error
    }
}
