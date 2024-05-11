
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;

namespace Mpj.Application.Services.Interfaces
{
    public interface IEmploymentSpouseService:IAsyncDisposable
    {
        Task<bool> AddSpouse(List<SpouseDTO> lst, long employmentId, List<SpouseDTO>? lstsponser);
        Task<bool> AddSponsorShip(List<SpouseDTO> lst);
        Task<List<Sponsorship>> GetSponserRecode(long employmentId);
        Task<bool> AddSupllementaryInfo(List<SponsershipDTO> lst, long employmentId);
       
    }
}
