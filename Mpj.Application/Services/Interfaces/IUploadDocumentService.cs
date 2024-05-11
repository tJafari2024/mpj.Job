
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;

namespace Mpj.Application.Services.Interfaces
{
    public interface IUploadDocumentService : IAsyncDisposable
    {
        Task<bool> UploadDocument(List<DocumentFileDTO> lstDoc);
        Task<List<RegistrationDocuments>> GetEmploymentDocument(long employmentId);
    }
   
}
