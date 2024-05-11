using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mpj.Application.Services.Interfaces.Admin;
using Mpj.Application.Utils;
using Mpj.DataLayer.DTOs.EmploymentForm.Admin;
using Mpj.DataLayer.DTOs.Paging;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Repository;
using Mpj.DataLayer.Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace Mpj.Application.Services.Implementations.Admin
{
    public class AdminEmploymentService : IAdminEmploymentService
    {
        #region Constructor

        private readonly IGenericRepository<Employment> _repository;
        private readonly IGenericRepository<EducationalRecode> _eduRepository;
        private readonly IGenericRepository<WorkExperience> _woRepository;

        public AdminEmploymentService(IGenericRepository<Employment> repository, IGenericRepository<EducationalRecode> eduRepository, IGenericRepository<WorkExperience> woRepository)
        {
            _repository = repository;
            _eduRepository = eduRepository;
            _woRepository = woRepository;
        }

        #endregion
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
        }

        public async Task<FilterEmploymentDTO> FilterEmploymentInfo(FilterEmploymentDTO filter)
        {
            var query = _repository.GetQuery()
                .Include(s => s.Province)
                .Include(c => c.City)
                .Include(e => e.EducationalRecodes)
                .ThenInclude(e => e.CityOfPlaceOfStudy)
                .ThenInclude(e => e.Province)
                .Include(w => w.WorkExperiences)
                .ThenInclude(w => w.CityOfJob)
                .ThenInclude(w => w.Province)
                .AsQueryable()
                .Select(item => new Employment
                {
                    Id = item.Id,
                    NationCode = item.NationCode,
                    Mobile = item.Mobile,
                    PersonalImage = item.PersonalImage,
                    Name = item.Name,
                    Family = item.Family,
                    Gender = (byte)item.Gender,
                    BirthCertificateId = item.BirthCertificateId,
                    Religion = (byte)item.Religion,
                    Sect = (byte)item.Sect,
                    FatherName = item.FatherName,
                    JobFather = item.JobFather,
                    BrithDate = item.BrithDate,
                    MaritalStatus = (byte)item.MaritalStatus,
                    ExemptionCode = item.ExemptionCode,
                    ExemptionReason = item.ExemptionReason,
                    ChildrenCount = (item.ChildrenCount != null)
                        ? (byte)item.ChildrenCount
                        : (byte)0,
                    MilitaryServiceStatus = (byte)item.MilitaryServiceStatus,
                    PlaceOfServiceOrgan = item.PlaceOfServiceOrgan,
                    MilitaryStartDate = item.MilitaryStartDate,
                    CardReceiptDate = item.CardReceiptDate,
                    Height = item.Height,
                    Weight = item.Weight,
                    UseOfGlasses = (bool)item.UseOfGlasses,
                    PhysicalCondition = (byte)item.PhysicalCondition,
                    DescriptionOfPhysicalCondition = item.DescriptionOfPhysicalCondition,
                    InsuranceHistoryMonth = (byte)(item.InsuranceHistoryMonth),
                    InsuranceHistoryYear = (byte)(item.InsuranceHistoryYear),
                    HasEmploymentHistory = item.HasEmploymentHistory,
                    DrivingLicences = item.DrivingLicences,
                    TotalNumberOfEyes = item.TotalNumberOfEyes,
                    EmploymentStatus = (byte)item.EmploymentStatus,
                    ProposedSalary = item.ProposedSalary,
                    ResidencePostalCode = item.ResidencePostalCode,
                    ResidencePeriodByMonth = item.ResidencePeriodByMonth,
                    ResidencePeriodByYear = item.ResidencePeriodByYear,
                    ResidencePhone = item.ResidencePhone,
                    IsConfirmAbsorptionUnit = false,
                    IsConfirmHumanResourceUnit = false,
                    IsConfirmInspectionUnit = false,
                    CityId = item.CityId,
                    City = item.City,
                    CityOfIssueCityId = item.CityOfIssueCityId,
                    CityOfIssueCity = item.CityOfIssueCity,
                    ProvinceId = item.ProvinceId,
                    Province = item.Province,
                    ProvinceOfIssueId = item.ProvinceOfIssueId,
                    ProvinceOfIssue = item.ProvinceOfIssue,
                    ResidenceCityId = item.ResidenceCityId,
                    ResidenceCity = item.ResidenceCity,
                    ResidenceProvinceId = item.ResidenceProvinceId,
                    ResidenceProvince = item.ResidenceProvince,
                    PlaceOfWork = item.PlaceOfWork,
                    PersonalCode = item.PersonalCode,
                    Address = item.Address,
                    FirstFamiliarMobile = item.FirstFamiliarMobile,
                    FirstFamiliarFullName = item.FirstFamiliarFullName,
                    FirstFamiliarJob = item.FirstFamiliarJob,
                    SecondFamiliarFullName = item.SecondFamiliarFullName,
                    SecondFamiliarJob = item.SecondFamiliarJob,
                    SecondFamiliarMobile = item.SecondFamiliarMobile,
                    AccessiblePersonFullName = item.AccessiblePersonFullName,
                    AccessiblePersonMobile = item.AccessiblePersonMobile,
                    AccessiblePersonJob = item.AccessiblePersonJob,
                    RepresentativeFullName = item.RepresentativeFullName,
                    RepresentativeMobile = item.RepresentativeMobile,
                    RepresentativeJob = item.RepresentativeJob,
                    ResumeFile = item.ResumeFile,
                    AbilityTitle = item.AbilityTitle,
                    AbilityToTravelAsAMission = item.AbilityToTravelAsAMission,
                    AbilityToWorkInClericalJobs = item.AbilityToWorkInClericalJobs,
                    AbilityToWorkInShifts = item.AbilityToWorkInShifts,
                    DescriptionOfAccident = item.DescriptionOfAccident,
                    Entertainments = item.Entertainments,
                    HavingAnAccident = item.HavingAnAccident,
                    Ideas = item.Ideas,
                    TrackingCode = item.TrackingCode,
                    CreateDate = item.CreateDate,
                    EducationalRecodes = item.EducationalRecodes.Where(e => e.EmploymentId == item.Id).ToList(),
                    WorkExperiences = item.WorkExperiences.Where(w => w.EmploymentId == item.Id).ToList()

                });

            if (!query.Any())
                return null;
           

            if (!string.IsNullOrEmpty(filter.TrackingCode))
                query = query.Where(s => EF.Functions.Like(s.TrackingCode.ToString(), $"%{filter.TrackingCode}%"));

            if (!string.IsNullOrEmpty(filter.NationCode))
                query = query.Where(s => EF.Functions.Like(s.NationCode.ToString(), $"%{filter.NationCode}%"));

           
            if (!string.IsNullOrEmpty(filter.BrithDate))
            {

                query = query.Where(a => ((DateTime)a.BrithDate).Date == filter.BrithDate.ToMiladiDateTime().Date);

            }
            if (!string.IsNullOrEmpty(filter.CreateDate))
            {

                query = query.Where(a => ((DateTime)a.CreateDate).Date == filter.CreateDate.ToMiladiDateTime().Date);

            }
         

            if (!string.IsNullOrEmpty(filter.DrivingLicences.ToString()))
                query = query.Where(s => EF.Functions.Like(s.DrivingLicences, $"%{((int)filter.DrivingLicences).ToString()}%"));

            if (!string.IsNullOrEmpty(filter.DegreeOfEducations.ToString()))
                query = query.Where(s =>
                    s.EducationalRecodes.Any(f => f.DegreeOfEducation == filter.DegreeOfEducations));


            query = query.OrderByDescending(s => s.Id);
            if (!query.Any())
                return null;

            #region paging

            var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.TakeEntity, filter.HowManyShowPageAfterAndBefore);
            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion
            return filter.SetPaging(pager).SetEmploymentInfos(allEntities);
        }

        public async Task<Employment> GetEmploymentById(long id)
        {
            var query =await _repository.GetQuery()
                .Include(s => s.Province)
                .Include(c => c.City)
                .Include(e => e.EducationalRecodes)
                .ThenInclude(e => e.CityOfPlaceOfStudy)
                .ThenInclude(e => e.Province)
                .Include(w => w.WorkExperiences)
                .ThenInclude(w => w.CityOfJob)
                .ThenInclude(w => w.Province)
                .AsQueryable()
                .Where(e=>e.Id==id)
                .Select(item => new Employment
                {
                    Id = item.Id,
                    NationCode = item.NationCode,
                    Mobile = item.Mobile,
                    PersonalImage = item.PersonalImage,
                    Name = item.Name,
                    Family = item.Family,
                    Gender = (byte)item.Gender,
                    BirthCertificateId = item.BirthCertificateId,
                    Religion = (byte)item.Religion,
                    Sect = (byte)item.Sect,
                    FatherName = item.FatherName,
                    JobFather = item.JobFather,
                    BrithDate = item.BrithDate,
                    MaritalStatus = (byte)item.MaritalStatus,
                    ExemptionCode = item.ExemptionCode,
                    ExemptionReason = item.ExemptionReason,
                    ChildrenCount = (item.ChildrenCount != null)
                        ? (byte)item.ChildrenCount
                        : (byte)0,
                    MilitaryServiceStatus = (byte)item.MilitaryServiceStatus,
                    PlaceOfServiceOrgan = item.PlaceOfServiceOrgan,
                    MilitaryStartDate = item.MilitaryStartDate,
                    CardReceiptDate = item.CardReceiptDate,
                    Height = item.Height,
                    Weight = item.Weight,
                    UseOfGlasses = (bool)item.UseOfGlasses,
                    PhysicalCondition = (byte)item.PhysicalCondition,
                    DescriptionOfPhysicalCondition = item.DescriptionOfPhysicalCondition,
                    InsuranceHistoryMonth = (byte)(item.InsuranceHistoryMonth),
                    InsuranceHistoryYear = (byte)(item.InsuranceHistoryYear),
                    HasEmploymentHistory = item.HasEmploymentHistory,
                    DrivingLicences = item.DrivingLicences,
                    TotalNumberOfEyes = item.TotalNumberOfEyes,
                    EmploymentStatus = (byte)item.EmploymentStatus,
                    ProposedSalary = item.ProposedSalary,
                    ResidencePostalCode = item.ResidencePostalCode,
                    ResidencePeriodByMonth = item.ResidencePeriodByMonth,
                    ResidencePeriodByYear = item.ResidencePeriodByYear,
                    ResidencePhone = item.ResidencePhone,
                    IsConfirmAbsorptionUnit = false,
                    IsConfirmHumanResourceUnit = false,
                    IsConfirmInspectionUnit = false,
                    CityId = item.CityId,
                    City = item.City,
                    CityOfIssueCityId = item.CityOfIssueCityId,
                    CityOfIssueCity = item.CityOfIssueCity,
                    ProvinceId = item.ProvinceId,
                    Province = item.Province,
                    ProvinceOfIssueId = item.ProvinceOfIssueId,
                    ProvinceOfIssue = item.ProvinceOfIssue,
                    ResidenceCityId = item.ResidenceCityId,
                    ResidenceCity = item.ResidenceCity,
                    ResidenceProvinceId = item.ResidenceProvinceId,
                    ResidenceProvince = item.ResidenceProvince,
                    PlaceOfWork = item.PlaceOfWork,
                    PersonalCode = item.PersonalCode,
                    Address = item.Address,
                    FirstFamiliarMobile = item.FirstFamiliarMobile,
                    FirstFamiliarFullName = item.FirstFamiliarFullName,
                    FirstFamiliarJob = item.FirstFamiliarJob,
                    SecondFamiliarFullName = item.SecondFamiliarFullName,
                    SecondFamiliarJob = item.SecondFamiliarJob,
                    SecondFamiliarMobile = item.SecondFamiliarMobile,
                    AccessiblePersonFullName = item.AccessiblePersonFullName,
                    AccessiblePersonMobile = item.AccessiblePersonMobile,
                    AccessiblePersonJob = item.AccessiblePersonJob,
                    RepresentativeFullName = item.RepresentativeFullName,
                    RepresentativeMobile = item.RepresentativeMobile,
                    RepresentativeJob = item.RepresentativeJob,
                    ResumeFile = item.ResumeFile,
                    AbilityTitle = item.AbilityTitle,
                    AbilityToTravelAsAMission = item.AbilityToTravelAsAMission,
                    AbilityToWorkInClericalJobs = item.AbilityToWorkInClericalJobs,
                    AbilityToWorkInShifts = item.AbilityToWorkInShifts,
                    DescriptionOfAccident = item.DescriptionOfAccident,
                    Entertainments = item.Entertainments,
                    HavingAnAccident = item.HavingAnAccident,
                    Ideas = item.Ideas,
                    TrackingCode = item.TrackingCode,
                    CreateDate = item.CreateDate,
                    EducationalRecodes = item.EducationalRecodes.Where(e => e.EmploymentId == item.Id).ToList(),
                    WorkExperiences = item.WorkExperiences.Where(w => w.EmploymentId == item.Id).ToList()

                }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<List<EducationalRecode>?> ShowEducation(long empId)
        {
            var educationalRecodes = await _eduRepository.GetQuery().AsQueryable()
                .Include(p => p.ProvinceOfPlaceOfStudy)
                .Include(c => c.CityOfPlaceOfStudy)
                .Where(e => e.EmploymentId == empId).AsNoTracking().ToListAsync();
            return educationalRecodes;


        }
        public async Task<List<WorkExperience>?> ShowWork(long empId)
        {
            var workExperiences = _woRepository.GetQuery().AsQueryable()
                .Include(p => p.ProvinceOfJob)
                .Include(c => c.CityOfJob)
                .Where(e => e.EmploymentId == empId);
            return await workExperiences.ToListAsync();

        }

        public async Task<bool> UpdateDescription(string description,long id)
        {
            try
            {
                var emp = await _repository.GetEntityById(id);
                emp.DescriptionAbsorptionUnit = description;
                _repository.EditEntity(emp);
                await _repository.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            


        }
    }
}
