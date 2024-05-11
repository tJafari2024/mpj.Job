using Mpj.DataLayer.DTOs.EmploymentForm.Admin;
using Mpj.DataLayer.Entities.EmploymentForm;

namespace Mpj.Application.Services.Interfaces.Admin
{
    public interface IAdminEmploymentService : IAsyncDisposable
    {
        Task<FilterEmploymentDTO> FilterEmploymentInfo(FilterEmploymentDTO filter);
        Task<Employment> GetEmploymentById(long id);
        Task<List<EducationalRecode>?> ShowEducation(long empId);
        Task<List<WorkExperience>?> ShowWork(long empId);
        Task<bool> UpdateDescription(string description,long id);
    }
}
