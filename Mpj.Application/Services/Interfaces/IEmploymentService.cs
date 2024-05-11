using Mpj.DataLayer.DTOs.EmploymentForm;
using System.Drawing.Drawing2D;
using Mpj.Application.Services.Implementations;
using Mpj.DataLayer.Entities.EmploymentForm;
using static Mpj.Application.Services.Implementations.EmploymentService;
using System.Collections.Generic;

namespace Mpj.Application.Services.Interfaces
{
    public interface IEmploymentService : IAsyncDisposable
    {
        //Task<long> AddEmployment(EmploymentDTO employment);

        Task<EditEmploymentResult> AddEmploymentStep2(PersonalImageDTO personalImage, long Id);
        Task<EditEmploymentResult> AddEmploymentStep3(SpecificationsDTO specifications,List<SpouseDTO>? lst);
        Task<EditEmploymentResult> AddEmploymentStep7(AcquaintancesDTO acquaintances, long Id);
        Task<EditEmploymentResult> AddEmploymentStep8(AbilitiesDTO abilities, long Id);
        Task<EditEmploymentResult> AddEmploymentStep9(EndStepDTO employment);
        Task<long> AddEmployment_Auth(string nationCode, string mobile);
        Task<bool> Update_CountAuth(long employmentId);
        Task<bool> Update_Step(long employmentId, int step);
        Task<EmploymentService.EmploymentResult> CheckExist(string nationCode, string mobile);
        Task<EmploymentLoginResult> UpdateMobile(long employmentId,string mobile);
        Task<Employment> GetEmploymentInfo(string nationCode, string mobile);
        Task<bool> CheckExistsTrackingCode(int id);
        Task<EditEmploymentResult> AddSupplementaryInfo(FurtherInformationDTO info, long Id);
        Task<EditEmploymentResult> UpdateUploadedDocument(long employmentId);
        //Task<bool> GetIsConfirmHumanResourceUnit(long employmentId);
    }
    public enum EditEmploymentResult
    {
        Success,
        Error


    }

}
