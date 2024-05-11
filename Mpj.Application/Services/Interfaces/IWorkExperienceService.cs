using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;

namespace Mpj.Application.Services.Interfaces
{
    public interface IWorkExperienceService: IAsyncDisposable
    {
        Task<long> AddWork(WorkExperienceDTO work);
        Task<List<WorkExperience>> GetWorkExperience(long employmentId);
        Task<WorkResult> AddWorkExperience(List<WorkExperience> lst, long id);
    }
    public enum WorkResult
    {
        Success,
        Error
    }

}
