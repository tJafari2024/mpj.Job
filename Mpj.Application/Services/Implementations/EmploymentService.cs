
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using Mpj.Application.Services.Interfaces;
using Mpj.Application.Utils;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Repository;

namespace Mpj.Application.Services.Implementations
{
    public class EmploymentService : IEmploymentService
    {
        #region Constructor
        private readonly IGenericRepository<Employment> _repository;
        private readonly IGenericRepository<EducationalRecode> _educationRepository;
        private readonly IGenericRepository<WorkExperience> _wrkGenericRepository;
        private readonly IEducationalRecordService _educationalRecordService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IUploadDocumentService _documentService;
        private readonly IEditedItemsForEmploymentService _editedItemsForEmployment;
        private readonly IEmploymentSpouseService _employmentSpouse;
        public EmploymentService(IGenericRepository<Employment> repository, IGenericRepository<EducationalRecode> educationRepository, IGenericRepository<WorkExperience> wrkGenericRepository, IEducationalRecordService educationalRecordService, IWorkExperienceService workExperienceService, IUploadDocumentService documentService, IEditedItemsForEmploymentService editedItemsForEmployment, IEmploymentSpouseService employmentSpouse)
        {
            _repository = repository;
            _educationRepository = educationRepository;
            _wrkGenericRepository = wrkGenericRepository;
            _educationalRecordService = educationalRecordService;
            _workExperienceService = workExperienceService;
            _documentService = documentService;
            _editedItemsForEmployment = editedItemsForEmployment;
            _employmentSpouse = employmentSpouse;
        }
        #endregion
        public async Task<long> AddEmployment_Auth(string nationCode, string mobile)
        {
            var employmentAuth = new Employment
            {
                NationCode = nationCode,
                Mobile = mobile,
                Step = 1

            };
            await _repository.AddEntity(employmentAuth);
            await _repository.SaveChanges();
            return employmentAuth.Id;
        }
        public async Task<EmploymentResult> CheckExist(string nationCode, string mobile)
        {
            var employment = await _repository.GetQuery().AsQueryable()
                .Include(e=>e.Sponsorships)
                .FirstOrDefaultAsync(e => e.NationCode.Equals(nationCode) || e.Mobile.Equals(mobile));
            var result = new EmploymentResult();
            if (employment != null)
            {
                if (employment.Mobile == mobile && (employment.NationCode == nationCode))
                {
                    var Notallow = await Update_CountAuth(employment.Id);
                    result.Employment = employment;
                    result.Step = (byte)employment.Step;
                    result.Educational = await _educationalRecordService.GetEducationRecode(employment.Id);
                    result.WorkExperience = await _workExperienceService.GetWorkExperience(employment.Id);
                    result.DocumentsList = await _documentService.GetEmploymentDocument(employment.Id);
                    var lstspon = new List<SpouseDTO>();
                    lstspon = employment.Sponsorships.Select(a => new SpouseDTO()
                    {
                        SpouseJob = a.SpouseJob,
                        SpouseMobile = a.SpouseMobile,
                        Name = a?.Name,
                        Family = a?.Family,
                        NationCode = a?.NationCode,
                        Gender = a.Gender,
                        MaritalStatus = a.MaritalStatus,
                        BasicInsurance = a.BasicInsurance,
                        BirthCertificateId = a.BirthCertificateId,
                        BrithDate = (a.BrithDate)?.ToShamsiDate(),
                        FatherName = a.FatherName,
                        IsCovered = (bool)a?.IsCovered,
                        ProvinceId = a.ProvinceId,
                        ProvinceOfIssueId = a.ProvinceOfIssueId,
                        Relation = a.Relation,
                        SerialInsurance = a.SerialInsurance,
                        EmploymentId = a.EmploymentId


                    }).ToList();
                    result.SponsershipsList = lstspon;
                    result.status = Notallow
                        ? EmploymentLoginResult.Block
                        : result.status = EmploymentLoginResult.Exists;


                }
                else
                {
                    result.status = EmploymentLoginResult.Warning;

                }
            }
            else
            {
                var id = await AddEmployment_Auth(nationCode, mobile);
                result.Id = id;
                result.status = EmploymentLoginResult.NotExists;
                result.Step = 2;
            }

            return result;


        }
        public async Task<Employment?> GetEmploymentInfo(string nationCode, string mobile)
        {
            Employment? employment = await _repository.GetQuery().AsQueryable()
                .FirstOrDefaultAsync(e => e.NationCode == nationCode && e.Mobile == mobile);
            return employment;
        }
        public async Task<bool> CheckExistsTrackingCode(int id)
        {
            return await _repository.GetQuery().AsQueryable().AnyAsync(e => e.TrackingCode == id);

        }
        public async Task<bool> Update_CountAuth(long employmentId)
        {
            var employment = await _repository.GetEntityById(employmentId);

            if (employment.DateSendSms.ToString() == "0001-01-01 00:00:00.0000000")
                employment.DateSendSms = DateTime.Now;

            if ((employment.CountSendSms??0) % 4 == 0 && employment.DateSendSms?.Date != DateTime.Now.Date)
            {
                employment.CountSendSms = 0;
                employment.DateSendSms = DateTime.Now;
            }

            if ((employment.CountSendSms ?? 0) < 4)
                employment.CountSendSms++;
            _repository.EditEntity(employment);
            await _repository.SaveChanges();
            return ((employment.CountSendSms??0) % 4 == 0 && employment.DateSendSms?.Date == DateTime.Now.Date);

        }
        public async Task<bool> Update_Step(long employmentId, int step)
        {
            var employment = await _repository.GetEntityById(employmentId);
            employment.Step = step;
            _repository.EditEntity(employment);
            await _repository.SaveChanges();
            return true;

        }
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
            await _educationRepository.DisposeAsync();
            await _wrkGenericRepository.DisposeAsync();

        }
        public async Task<EditEmploymentResult> AddEmploymentStep2(PersonalImageDTO personalImage, long Id)
        {
            try
            {
                var Employmentinfo = await _repository.GetEntityById(Id);
                Employmentinfo.PersonalImage = personalImage.PersonalImageName;
                Employmentinfo.Step = 3;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();
                return EditEmploymentResult.Success;

            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
        }
        public async Task<EditEmploymentResult> AddEmploymentStep3(SpecificationsDTO specifications,List<SpouseDTO>? lst=null)
        {//lst is sponseship in complete
            try
            {
              
                string drivingLicences = "";
                foreach (var val in specifications.DrivingLicences)
                {
                    drivingLicences += val.ToString() + ",";
                }

                drivingLicences = drivingLicences.Substring(0, drivingLicences.Length - 1);

                var Employmentinfo = await _repository.GetEntityById(specifications.EmploymentId);
                if (Employmentinfo.Address != specifications.Address && Employmentinfo.Address != null)
                    await _editedItemsForEmployment.InsertItemForEmployment(FieldName.Address, Employmentinfo.Address,
                        Employmentinfo.Id);
                if (Employmentinfo.PhysicalCondition != null && Employmentinfo.PhysicalCondition != (byte)specifications.PhysicalCondition)
                    await _editedItemsForEmployment.InsertItemForEmployment(FieldName.PhysicalCondition, Employmentinfo.PhysicalCondition.ToString(),
                        Employmentinfo.Id);
                if (Employmentinfo.ExemptionReason != null && Employmentinfo.ExemptionReason != specifications.ExemptionReason)
                    await _editedItemsForEmployment.InsertItemForEmployment(FieldName.ExemptionReason, Employmentinfo.ExemptionReason,
                        Employmentinfo.Id);


                Employmentinfo.Step = 4;
                Employmentinfo.Name = specifications.Name;
                Employmentinfo.Family = specifications.Family;
                Employmentinfo.Gender = (byte)specifications.Gender;
                Employmentinfo.BirthCertificateId = specifications.BirthCertificateId;
                Employmentinfo.SerialBirthCertificateSection1 = specifications.SerialBirthCertificateSection1;
                Employmentinfo.SerialBirthCertificateSection2= specifications.SerialBirthCertificateSection2;
                Employmentinfo.SerialBirthCertificateSection3 = specifications.SerialBirthCertificateSection3;
                Employmentinfo.Religion = (byte)specifications.Religion;
                Employmentinfo.Sect = (byte)specifications.Sect;
                Employmentinfo.FatherName = specifications.FatherName;
                Employmentinfo.JobFather = specifications.JobFather;
                Employmentinfo.BrithDate = specifications.BrithDate.ToMiladiDateTime();
                Employmentinfo.MaritalStatus = (byte)specifications.MaritalStatus;
                Employmentinfo.ExemptionCode = specifications.ExemptionCode;
                Employmentinfo.ExemptionReason = specifications.ExemptionReason;
                Employmentinfo.ChildrenCount = (specifications.ChildrenCount != null)
                    ? (byte)specifications.ChildrenCount
                    : (byte)0;
                Employmentinfo.MilitaryServiceStatus = (byte)specifications.MilitaryServiceStatus;
                Employmentinfo.PlaceOfServiceOrgan = specifications.PlaceOfServiceOrgan;
                Employmentinfo.MilitaryStartDate = specifications.MilitaryStartDate?.ToMiladiDateTime();
                Employmentinfo.CardReceiptDate = specifications.CardReceiptDate?.ToMiladiDateTime();
                Employmentinfo.Height = specifications.Height;
                Employmentinfo.Weight = specifications.Weight;
                Employmentinfo.UseOfGlasses = (bool)specifications.UseOfGlasses;
                Employmentinfo.PhysicalCondition = (byte)specifications.PhysicalCondition;
                Employmentinfo.DescriptionOfPhysicalCondition = specifications.DescriptionOfPhysicalCondition;
                Employmentinfo.InsuranceHistoryMonth = byte.Parse(specifications.InsuranceHistoryMonth);
                Employmentinfo.InsuranceHistoryYear = byte.Parse(specifications.InsuranceHistoryYear);
                Employmentinfo.HasEmploymentHistory = (specifications.HasEmploymentHistory) == 0 ? false : true;
                Employmentinfo.DrivingLicences = drivingLicences;
                Employmentinfo.TotalNumberOfEyes = specifications.TotalNumberOfEyes;
                Employmentinfo.EmploymentStatus = (byte)specifications.EmploymentStatus;
                Employmentinfo.ProposedSalary = int.Parse(specifications.ProposedSalary.Replace(",", ""));
                Employmentinfo.ResidencePostalCode = specifications.ResidencePostalCode;
                Employmentinfo.ResidencePeriodByMonth = specifications.ResidencePeriodByMonth;
                Employmentinfo.ResidencePeriodByYear = specifications.ResidencePeriodByYear;
                Employmentinfo.ResidencePhone = specifications.ResidencePhone;
                Employmentinfo.IsConfirmAbsorptionUnit = false;
                Employmentinfo.IsConfirmHumanResourceUnit = false;
                Employmentinfo.IsConfirmInspectionUnit = false;
                Employmentinfo.CityId = specifications.CityId;
                Employmentinfo.CityOfIssueCityId = specifications.CityOfIssueCityId;
                Employmentinfo.ProvinceId = specifications.ProvinceId;
                Employmentinfo.ProvinceOfIssueId = specifications.ProvinceOfIssueId;
                Employmentinfo.ResidenceCityId = specifications.ResidenceCityId;
                Employmentinfo.ResidenceProvinceId = specifications.ResidenceProvinceId;
                Employmentinfo.PlaceOfWork = specifications.PlaceOfWork;
                Employmentinfo.PersonalCode = specifications.PersonalCode;
                Employmentinfo.Address = specifications.Address;
                Employmentinfo.SpouseCount=specifications.SpouseCount;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();

              await  _employmentSpouse.AddSpouse(specifications.Spouse, Employmentinfo.Id,lst);
            

                return EditEmploymentResult.Success;
            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
        }
        public async Task<EditEmploymentResult> AddEmploymentStep7(AcquaintancesDTO acquaintances, long Id)
        {
            try
            {

                var Employmentinfo = await _repository.GetEntityById(Id);
                Employmentinfo.Step = 7;
                Employmentinfo.FirstFamiliarMobile = acquaintances.FirstFamiliarMobile;
                Employmentinfo.FirstFamiliarFullName = acquaintances.FirstFamiliarFullName;
                Employmentinfo.FirstFamiliarJob = acquaintances.FirstFamiliarJob;
                Employmentinfo.SecondFamiliarFullName = acquaintances.SecondFamiliarFullName;
                Employmentinfo.SecondFamiliarJob = acquaintances.SecondFamiliarJob;
                Employmentinfo.SecondFamiliarMobile = acquaintances.SecondFamiliarMobile;
                Employmentinfo.AccessiblePersonFullName = acquaintances.AccessiblePersonFullName;
                Employmentinfo.AccessiblePersonMobile = acquaintances.AccessiblePersonMobile;
                Employmentinfo.AccessiblePersonJob = acquaintances.AccessiblePersonJob;
                Employmentinfo.RepresentativeFullName = acquaintances.RepresentativeFullName;
                Employmentinfo.RepresentativeMobile = acquaintances.RepresentativeMobile;
                Employmentinfo.RepresentativeJob = acquaintances.RepresentativeJob;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();
                return EditEmploymentResult.Success;
            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
        }
        public async Task<EditEmploymentResult> AddEmploymentStep8(AbilitiesDTO abilities, long Id)
        {
            try
            {

                var Employmentinfo = await _repository.GetEntityById(Id);
                Employmentinfo.Step = 8;
                Employmentinfo.ResumeFile = abilities.ResumeFileUrl;
                Employmentinfo.AbilityTitle = abilities.AbilityTitle;
                Employmentinfo.AbilityToTravelAsAMission = abilities.AbilityToTravelAsAMission;
                Employmentinfo.AbilityToWorkInClericalJobs = abilities.AbilityToWorkInClericalJobs;
                Employmentinfo.AbilityToWorkInShifts = abilities.AbilityToWorkInShifts;
                Employmentinfo.DescriptionOfAccident = abilities.DescriptionOfAccident;
                Employmentinfo.Entertainments = abilities.Entertainments;
                Employmentinfo.HavingAnAccident = abilities.HavingAnAccident;
                Employmentinfo.Ideas = abilities.Ideas;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();
                return EditEmploymentResult.Success;
            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
        }
        public async Task<EditEmploymentResult> AddEmploymentStep9(EndStepDTO employment)
        {
            try
            {
                var Employmentinfo = await _repository.GetEntityById(employment.EmploymentId);
                Employmentinfo.SatisfactionRules = employment.SatisfactionRules;
                Employmentinfo.TrackingCode = employment.TrackingCode;
                Employmentinfo.IsConfirmAbsorptionUnit = false;
                Employmentinfo.IsConfirmHumanResourceUnit = false;
                Employmentinfo.IsConfirmInspectionUnit = false;
                Employmentinfo.Step = 9;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();
                return EditEmploymentResult.Success;

            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
        }
        public async Task<EmploymentLoginResult> UpdateMobile(long employmentId,string mobile)
        {
            try
            {
                var employment = await _repository.GetQuery().AsQueryable()
                    .FirstOrDefaultAsync(e => e.Id.Equals(employmentId));
                if (employment == null)
                {
                    return EmploymentLoginResult.Error;
                }

                if (!(bool)(employment.UpdateMobile??false ))
                {
                    if (employment.Step == 0)
                    {
                        employment.Mobile = mobile;
                        employment.UpdateMobile = true;
                        _repository.EditEntity(employment);
                        await _repository.SaveChanges();
                        return EmploymentLoginResult.NotExists;
                    }
                    else
                    {
                        return EmploymentLoginResult.Exists;
                    }
                }
                else if(employment.Mobile == mobile) 
                {
                    return EmploymentLoginResult.Exists;
                }
                
                return EmploymentLoginResult.Block;
            }
            catch (Exception e)
            {
                return EmploymentLoginResult.Error;
            }

        }
        public async Task<EditEmploymentResult> AddSupplementaryInfo(FurtherInformationDTO info, long Id)
        {
            try
            {
                var Employmentinfo = await _repository.GetEntityById(Id);
                Employmentinfo.InsuranceNumber = info.InsuranceNumber;
                Employmentinfo.TejaratBankNumber = info.TejaratBankNumber;
                Employmentinfo.TejaratSheba = info.TejaratSheba;
                Employmentinfo.DateOfMarriage = info.DateOfMarriage?.ToMiladiDateTime();
                Employmentinfo.Step = 10;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();
                return EditEmploymentResult.Success;

            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
        }

        public async Task<EditEmploymentResult> UpdateUploadedDocument(long employmentId)
        {
            try
            {
                var Employmentinfo = await _repository.GetEntityById(employmentId);
                Employmentinfo.IsUploadDocument = true;
                _repository.EditEntity(Employmentinfo);
                await _repository.SaveChanges();
                return EditEmploymentResult.Success;

            }
            catch (Exception e)
            {
                return EditEmploymentResult.Error;
            }
          

        }

        //public async Task<bool> GetIsConfirmHumanResourceUnit(long employmentId)
        //{
        //    var Employmentinfo = await _repository.GetEntityById(employmentId);
        //    return Employmentinfo.IsConfirmHumanResourceUnit;
        //}


        public class EmploymentResult
        {
            public EmploymentLoginResult status { get; set; }
            public Employment? Employment { get; set; }
            public List<EducationalRecode>? Educational { get; set; }
            public List<WorkExperience>? WorkExperience { get; set; }
            public List<RegistrationDocuments>? DocumentsList { get; set; }
            public List<SpouseDTO>? SponsershipsList { get; set; }
            public long Id { get; set; }
            public byte Step { get; set; }


        }
        public enum EmploymentLoginResult
        {
            Exists,
            Warning,
            NotExists,
            Block,
            Error


        }

    }
}
