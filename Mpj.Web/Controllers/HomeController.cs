using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.Application.Extensions;
using Mpj.Application.Utils;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.InMemoryCache;
using Mpj.DataLayer.Utils;
using Mpj.Web.Utils;
using Mpj.Web.Utils.Http;
using static Mpj.Web.Utils.ConfigHandler;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Internal;
using Mpj.Application.Services.Implementations;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Migrations;

namespace Mpj.Web.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region constructor
        private readonly ICityService _cityService;
        private readonly ILowMemoryCache _lowDtoMemory;
        private readonly IAuthenticationMemoryCache _authenticationMemory;
        private readonly IAuthorizationMemoryCache _authorizationMemoryCache;
        private readonly IAuthenticationWithSmsMemoryCache _authenticationWithSmsMemoryCache;
        private readonly IPersonalImageMemoryCache _personalImageMemory;
        private readonly ISpecificationMemoryCache _specificationMemory;
        private readonly IAbilitiesMemoryCache _abilitiesMemory;
        private readonly IAcquaintancesMemoryCache _acquaintancesMemory;
        private readonly IEducationalRecordMemoryCache _educationalRecordMemory;
        private readonly IWorkExperienceMemory _workExperienceMemory;
        private readonly IDocumentMemoryCache _documentMemory;
        private readonly IEducationalRecordService _educationalRecordService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IEmploymentService _employmentService;
        private readonly IEmploymentSpouseService _employmentSpouse;
        private readonly IEndStepMemoryCache _endStepMemory;
        private readonly IUploadDocumentService _uploadDocumentService;
        private readonly IEditItemForEmploymentMemoryCache _editItemForEmploymentMemory;
        private readonly ISupplementaryInfoMemoryCache _supplementaryInfoMemory;
        private readonly ISponserShipMemoryCache _sponserShipMemoryCache;


        public HomeController(ICityService cityService, ILowMemoryCache lowDtoMemory, IAuthenticationMemoryCache authenticationMemory, IAuthorizationMemoryCache authorizationMemoryCache, IAuthenticationWithSmsMemoryCache authenticationWithSmsMemoryCache, IPersonalImageMemoryCache personalImageMemory, ISpecificationMemoryCache specificationMemory, IAbilitiesMemoryCache abilitiesMemory, IAcquaintancesMemoryCache acquaintancesMemory, IEducationalRecordMemoryCache educationalRecordMemory, IWorkExperienceMemory workExperienceMemory, IDocumentMemoryCache documentMemory, IEducationalRecordService educationalRecordService, IWorkExperienceService workExperienceService, IEmploymentService employmentService, IEmploymentSpouseService employmentSpouse, IEndStepMemoryCache endStepMemory, IUploadDocumentService uploadDocumentService, IEditItemForEmploymentMemoryCache editItemForEmploymentMemory, ISupplementaryInfoMemoryCache supplementaryInfoMemory, ISponserShipMemoryCache sponserShipMemoryCache)
        {
            _cityService = cityService;
            _lowDtoMemory = lowDtoMemory;
            _authenticationMemory = authenticationMemory;
            _authorizationMemoryCache = authorizationMemoryCache;
            _authenticationWithSmsMemoryCache = authenticationWithSmsMemoryCache;
            _personalImageMemory = personalImageMemory;
            _specificationMemory = specificationMemory;
            _abilitiesMemory = abilitiesMemory;
            _acquaintancesMemory = acquaintancesMemory;
            _educationalRecordMemory = educationalRecordMemory;
            _workExperienceMemory = workExperienceMemory;
            _documentMemory = documentMemory;
            _educationalRecordService = educationalRecordService;
            _workExperienceService = workExperienceService;
            _employmentService = employmentService;
            _employmentSpouse = employmentSpouse;
            _endStepMemory = endStepMemory;
            _uploadDocumentService = uploadDocumentService;
            _editItemForEmploymentMemory = editItemForEmploymentMemory;
            _supplementaryInfoMemory = supplementaryInfoMemory;
            _sponserShipMemoryCache = sponserShipMemoryCache;

        }

        #endregion
        #region Step1

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var lowDto = new LowDTO();
            var personalImage = new PersonalImageNameMem();
            var authentication = new AuthenticationDTO();
            var authenticationSms = new AuthenticationDTOWithSms();
            var authorizationDto = new AuthorizationDTO();
            var specifications = new SpecificationsDTO();
            var educationalRecords = new List<EducationalRecords>();
            var lstWorkExperienceRecordsList = new List<WorkExperienceRecords>();
            var acquaintances = new AcquaintancesDTO();
            var abilities = new AbilitiesDTOMem();
            var documentFile = new List<DocumentFileDTO>();
            var supplementaryInfo = new FurtherInformationDTO();
            var sponsershipInfo = new List<SpouseDTO>();

            _lowDtoMemory.Set("Low", lowDto);
            _authenticationMemory.Set("SaveAuth", authentication);
            _personalImageMemory.Set("SavePersonalImage", personalImage);
            _authorizationMemoryCache.Set("SaveAuthorization", authorizationDto);
            _authenticationWithSmsMemoryCache.Set("SaveAuthSms", authenticationSms);
            _specificationMemory.Set("SaveSpecification", specifications);
            _educationalRecordMemory.Set("SaveEdu", educationalRecords);
            _workExperienceMemory.Set("SaveWork", lstWorkExperienceRecordsList);
            _acquaintancesMemory.Set("SaveAcquaintance", acquaintances);
            _abilitiesMemory.Set("SaveAbility", abilities);
            _documentMemory.Set("SaveDocFile", documentFile);
            _supplementaryInfoMemory.Set("SaveSupplementaryInfo", supplementaryInfo);
            _sponserShipMemoryCache.Set("SaveSponsershipInfo", sponsershipInfo);

            return View(lowDto);
            //return RedirectToAction(nameof(AddSpecification));

        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LowDTO lowDto)
        {
            if (!ModelState.IsValid) return View(lowDto);

            _lowDtoMemory.Set("Low", lowDto);
            return RedirectToAction(nameof(AddAuthentication));
        }
        #endregion
        #region Step2
        [HttpGet("add-authentication")]
        public async Task<IActionResult> AddAuthentication()
        {
            AuthenticationDTO? authentication = _authenticationMemory.Get("SaveAuth");
            return View(authentication ?? new AuthenticationDTO());
        }

        [HttpPost("add-authentication")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAuthentication(AuthenticationDTO model)
        {
            var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            if (authorization.EmploymentId == null)//اولین بار مراحعه
                authorization = new AuthorizationDTO();
            else//دکمه ویرایش شماره را زده
            {
                var resUpdate = await _employmentService.UpdateMobile((long)authorization.EmploymentId, model.Mobile);
                switch (resUpdate)
                {
                    case EmploymentService.EmploymentLoginResult.Error:
                        TempData[ErrorMessage] = "عدم ویرایش شماره همراه،لطفا مجددا اقدام کنید";
                        return View(model);
                    case EmploymentService.EmploymentLoginResult.Block:
                        TempData[WarningMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                        return View(model);

                }

            }
            if (!ModelState.IsValid) return View(model);
            if (!model.NationCode.IsValidNationalCode())
            {
                TempData[ErrorMessage] = "کد ملی وارد شده معتبر نمی باشد";
                return View(model);
            }
            EmploymentService.EmploymentResult result = await _employmentService.CheckExist(model.NationCode, model.Mobile);
            switch (result.status)
            {
                case EmploymentService.EmploymentLoginResult.Block:
                    TempData[ErrorMessage] = "سقف ارسال پیام برای شما در روز آتی به پایان رسیده است. لطفا در روزهای دیگر اقدام کنید سقف ارسال پیام :" + "3";
                    return View(model);
                case EmploymentService.EmploymentLoginResult.Exists:

                    authorization.EmploymentLoginResult = EmploymentLoginResultenum.Success;
                    authorization.EmploymentId = result.Employment.Id;
                    authorization.Step = result.Step;
                    authorization.IsConfirm = result.Employment.IsConfirmAbsorptionUnit;
                    authorization.ChildrenCount = result.Employment.ChildrenCount;
                    authorization.SponsorshipCount = result.Employment.SpouseCount;
                    authorization.Gender = (Gender)result.Employment.Gender;
                    authorization.MaritalStatus = (MaritalStatus)(result.Employment.MaritalStatus ?? 0);
                    authorization.TrackingCode = result.Employment.TrackingCode ?? 0;
                    authorization.IsUploadDoc = result.Employment.IsUploadDocument ?? false;
                    authorization.IsConfirmHumanResourceUnit = result.Employment.IsConfirmHumanResourceUnit??false;
                    GetPersonalImage(result.Employment.PersonalImage);
                    await GetSpecificationAsync(result.Employment);
                    await GetEducation(result.Educational);
                    await GetWork(result.WorkExperience);
                    await GetAcquaintance(result.Employment);
                    await GetAbility(result.Employment);
                    await GetEndStep(result.Employment);
                    await GetDocument(result.DocumentsList);
                    await GeSupplementary(result.Employment);
                    await GetSponsership(result.SponsershipsList);
                    break;
                case EmploymentService.EmploymentLoginResult.Warning:
                    TempData[WarningMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                    return View(model);
                case EmploymentService.EmploymentLoginResult.NotExists:
                    authorization.EmploymentLoginResult = EmploymentLoginResultenum.NotExists;
                    authorization.EmploymentId = result.Id;

                    break;
            }
            try
            {

                Random generator = new Random();
                string code = generator.Next(0, 100000).ToString("D5");
                SendSms(model.Mobile, SendSmsType.ForAuthentication, code);
                authorization.Key = code;
                _authenticationMemory.Set("SaveAuth", model);
                _authorizationMemoryCache.Set("SaveAuthorization", authorization);


            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(AddAuthentication));
            }

            return RedirectToAction(nameof(AddAuthenticationWithSms));

        }
        #region GetAuthSms
        [HttpGet("add-authenticationSms/{stepExpire?}")]
        public async Task<IActionResult> AddAuthenticationWithSms(int? stepExpire = 0)
        {
            AuthenticationDTO authentication = _authenticationMemory.Get("SaveAuth");
            if (authentication == null)
                return RedirectToAction(nameof(Index));

            AuthenticationDTOWithSms? authenticationsms = _authenticationWithSmsMemoryCache.Get("SaveAuthSms");
            if (authenticationsms.Mobile != null && authenticationsms.Valid == false)
                return RedirectToAction(nameof(Index));


            if (authenticationsms.Mobile == null)
            {
                authenticationsms = new AuthenticationDTOWithSms
                {
                    Mobile = authentication.Mobile,
                    StepWithTimer = (byte)stepExpire

                };

            }
            return View(authenticationsms);
        }

        [HttpPost("add-authenticationSms/{stepExpire?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAuthenticationWithSms(AuthenticationDTOWithSms model, int? stepExpire = 0)
        {
            if (stepExpire == 0)
            {
                if (!ModelState.IsValid) return View(model);
                var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
                if (model.Password != authorization.Key)
                {
                    TempData[ErrorMessage] = "رمز وارد شده صحیح نمی باشد";
                    return View(model);
                }

                model.Password = "";
                _authenticationWithSmsMemoryCache.Set("SaveAuthSms", model);
                if ((authorization.Step == 9) || (authorization.Step == 8 && authorization.TrackingCode > 0 && !(bool)authorization.IsUploadDoc))
                    return RedirectToAction(nameof(SupplementaryStep));
                else if (authorization.Step == 10 && !(bool)authorization.IsUploadDoc)
                    return RedirectToAction(nameof(UploadDocument));
                else
                    return RedirectToAction(nameof(AddPersonalImage));



            }
            else
            {
                return RedirectToAction(nameof(AddAuthentication));
            }
        }
        #endregion
        [HttpPost("/Home/GetPassword/{password}")]
        public async Task<JsonResult> GetPassword(string password)
        {
            AuthenticationDTO authentication = _authenticationMemory.Get("SaveAuth");
            var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            var result = new JsonResultValue();

            if (password != authorization.Key)
            {
                result.IsValid = false;
            }
            else
                result.IsValid = true;

            if ((authorization.TrackingCode > 0 && (bool)authorization.IsUploadDoc)||authorization.TrackingCode==0)
                result.Url = "/add-personalImage";
            
           // else if (authorization.Step == 10 && !(bool)authorization.IsUploadDoc) 
               // result.Url = "/upload-document";
            else
                result.Url = "/supplementarystep";



            var authSms = new AuthenticationDTOWithSms()
            {
                Valid = false,
                Mobile = authentication.Mobile
            };
            _authenticationWithSmsMemoryCache.Set("SaveAuthSms", authSms);
            return Json(result);

        }
        #endregion
        #region Step3
        [HttpGet("add-personalImage")]
        public async Task<IActionResult> AddPersonalImage()
        {
            PersonalImageNameMem? personalImage = _personalImageMemory.Get("SavePersonalImage");
            if (personalImage != null)
            {
                PersonalImageDTO personalImageDto = new PersonalImageDTO
                {
                    PersonalImageName = personalImage.PersonalImageName
                };
                return View(personalImageDto);
            }
            return View(new PersonalImageDTO());

        }
        [HttpPost("add-personalImage"),ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPersonalImage(PersonalImageDTO model)
        {
            PersonalImageNameMem? pImage = _personalImageMemory.Get("SavePersonalImage");
            if (model.PersonalImage == null && (pImage == null || pImage?.PersonalImageName == null))
            {
                TempData[ErrorMessage] = "لطفا عکس پرسنلی را بارگزاری کنید";
                return View(model);
            }

            #region checkValidImage
            string fileName = "";
            string[] imgsize = { };
            if (model.PersonalImage != null)
            {
                ImageSetting imgSetting = GeImageSetting();
                if (model.PersonalImage.Length <= 0) return null;
                else
                {
                    if (model.PersonalImage.Length > long.Parse(imgSetting.ImageSize))
                    {
                        TempData[ErrorMessage] = " حداکثر اندازه فایل " + (long.Parse(imgSetting.ImageSize)).ToString() + " مگابایت می باشد ";
                        return View(model);
                    }
                }
                if (!model.PersonalImage.IsImage())
                {
                    TempData[ErrorMessage] = "لطفا یک فایل با فرمت " + imgSetting.ImageFormat + " انتخاب کنید";
                    return View(model);

                }
                else
                {
                    fileName = Guid.NewGuid() + Path.GetExtension(model.PersonalImage.FileName).ToLower();
                    if (imgSetting.ImageSize.Length > 0)
                    {
                        imgsize = imgSetting.ImageW_H.Replace(" ", "").Split('_');
                        model.PersonalImage.AddImageToServer(fileName, PathExtension.PersonalImageServerOrigin,
                            int.Parse(imgsize[0].Split('*')[0]), int.Parse(imgsize[0].Split('*')[1]),
                            int.Parse(imgsize[1].Split('*')[0]), int.Parse(imgsize[1].Split('*')[1]), 100, 100);
                        model.PersonalImageName = fileName;

                    }

                }

            }
            #endregion
            if (model.PersonalImageName != null)//آپلود
            {
                PersonalImageNameMem personalImage = new PersonalImageNameMem
                {
                    PersonalImageName = model.PersonalImageName,
                };

                #region SaveInDateBase
                var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
                if (!(bool)authinfo.IsConfirmHumanResourceUnit)
                {
                    _personalImageMemory.Set("SavePersonalImage", personalImage);
                    await _employmentService.AddEmploymentStep2(model, (long)authinfo.EmploymentId);
                }

                #endregion
            }
            else //تصویر قبلی و خواندن از حافظه
            {
                PersonalImageNameMem? personalImageold = _personalImageMemory.Get("SavePersonalImage");
                PersonalImageNameMem personalImage = new PersonalImageNameMem
                {
                    PersonalImageName = personalImageold.PersonalImageName,
                };
                _personalImageMemory.Set("SavePersonalImage", personalImage);

            }
            return RedirectToAction(nameof(AddSpecification));
        }
        #endregion
        #region Step4
        [HttpGet("add-specification")]
        public async Task<IActionResult> AddSpecification()
        {
            //var auth = _specificationMemory.Get("SaveAuth");
            var auth = _authenticationMemory.Get("SaveAuth");

            if (auth != null)
            {
                SpecificationsDTO? specifications = _specificationMemory.Get("SaveSpecification");
                if (specifications != null)
                {
                    CascadingDTO cascadingDto = new CascadingDTO();
                    cascadingDto.States = await _cityService.GetAllProvince();
                    if (specifications.ProvinceId != null)
                        cascadingDto.Cities = await _cityService.GetCityByProvinceId((long)specifications.ProvinceId);
                    else
                        cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value
                            .ToString()));

                    if (specifications.ProvinceOfIssueId != null)
                        cascadingDto.CityOfIssue =
                            await _cityService.GetCityByProvinceId((long)specifications.ProvinceOfIssueId);
                    else
                        cascadingDto.CityOfIssue =
                            await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value
                                .ToString()));

                    if (specifications.ResidenceProvinceId != null)
                        cascadingDto.ResidenceCity =
                            await _cityService.GetCityByProvinceId((long)specifications.ResidenceProvinceId);
                    else
                        cascadingDto.ResidenceCity =
                            await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value
                                .ToString()));
                    specifications.CascadingDto = cascadingDto;
                }
                else
                {
                    specifications = new SpecificationsDTO();
                    CascadingDTO cascadingDto = new CascadingDTO();
                    cascadingDto.States = await _cityService.GetAllProvince();
                    cascadingDto.Cities =
                        await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value
                            .ToString()));
                    cascadingDto.CityOfIssue =
                        await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value
                            .ToString()));
                    cascadingDto.ResidenceCity =
                        await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value
                            .ToString()));
                    specifications.CascadingDto = cascadingDto;

                }
                var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
                if (specifications.MaritalStatus != MaritalStatus.Married)
                    specifications.SpouseCount = 0;
                else
                {
                    var sponership = _sponserShipMemoryCache.Get("SaveSponsershipInfo");
                    if (sponership != null && sponership.Count > 0)
                    {
                        specifications.SpouseCount = (byte)sponership.Count(s => s.Relation == (byte)Relation.Spouse);
                        specifications.Spouse = sponership.Where(s => s.Relation == (byte)Relation.Spouse).ToList();
                    }
                    else
                    {
                        specifications.SpouseCount = 1;
                        var spouse = new SpouseDTO()
                        {
                            SpouseJob = "",
                            SpouseMobile = "",
                            EmploymentId = (long)authinfo.EmploymentId
                        };
                        specifications.Spouse =
                        [
                            spouse
                        ];
                    }

                }

                specifications.ChildrenCount = specifications.ChildrenCount ?? 0;

                return View(specifications);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet("get-spouse/{count}")]
        public async Task<IActionResult> GetSpouseView(byte count)
        {
            SpecificationsDTO? specifications = _specificationMemory.Get("SaveSpecification");
            specifications.SpouseCount = count;
            int scount = 0;
            if (specifications.Spouse != null)
                scount = specifications.Spouse.Count;
            else
                specifications.Spouse = new List<SpouseDTO>();
            if (scount < count)
            {
                for (int i = 0; i < count - scount; i++)
                {
                    var spouse = new SpouseDTO()
                    {
                        SpouseJob = "",
                        SpouseMobile = "",
                        EmploymentId = specifications.EmploymentId
                    };
                    specifications.Spouse.Add(spouse);
                }

            }

            return PartialView("_SpousePartial", specifications);
        }
        [HttpPost("add-specification")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSpecification(SpecificationsDTO model)
        {
            //var sponership = _sponserShipMemoryCache.Get("SaveSponsershipInfo");
            if (model.Spouse != null && model.Spouse.Count > 0)
            {
                model.SpouseCount = model.SpouseCount;
                model.Spouse = model.Spouse;
            }
            else
            {
                model.SpouseCount = model.SpouseCount;
                int scount = 0;
                if (model.Spouse != null)
                    scount = model.Spouse.Count;
                else
                    model.Spouse = new List<SpouseDTO>();
                if (scount < model.SpouseCount)
                {
                    for (int i = 0; i < model.SpouseCount - scount; i++)
                    {
                        var spouse = new SpouseDTO()
                        {
                            SpouseJob = "",
                            SpouseMobile = "",
                            EmploymentId = model.EmploymentId
                        };
                        model.Spouse.Add(spouse);
                    }

                }
            }
            if (!ModelState.IsValid)
            {
                CascadingDTO cascadingDto = new CascadingDTO();
                cascadingDto.States = await _cityService.GetAllProvince();
                cascadingDto.Cities = await _cityService.GetCityByProvinceId((long)model.ProvinceId);
                cascadingDto.CityOfIssue = await _cityService.GetCityByProvinceId((long)model.ProvinceOfIssueId);
                cascadingDto.ResidenceCity = await _cityService.GetCityByProvinceId((long)model.ResidenceProvinceId);
                model.CascadingDto = cascadingDto;
                var lstDrivingLicences = new List<SelectedListElement>();
                return View(model);
            }
            var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
            if (model.Religion != Religion.Eslam)
                model.Sect = Sect.Notthing;
            model.EmploymentId = (long)authinfo.EmploymentId;
            authinfo.ChildrenCount = model.ChildrenCount;
            authinfo.SponsorshipCount = model.SpouseCount;
            authinfo.MaritalStatus = model.MaritalStatus;
            _authorizationMemoryCache.Set("SaveAuthorization", authinfo);
            //_sponserShipMemoryCache.Set("SaveSponsershipInfo", model.Spouse);
            //if (model.MaritalStatus == MaritalStatus.Single || model.MaritalStatus == MaritalStatus.Moeil)
            //{
            //    if (model.MaritalStatus == MaritalStatus.Single)
            //        model.SpouseCount = 0;
            //    else
            //        model.SpouseCount = 1;
            //    var spouse = new SpouseDTO
            //    {
            //        SpouseJob = "",
            //        SpouseMobile = "",
            //        EmploymentId = (long)authinfo.EmploymentId
            //    };
            //    model.Spouse =
            //    [
            //        spouse
            //    ];
            //}
            //if (model.MaritalStatus != MaritalStatus.Married)
            //    model.SpouseCount = 0;
            //else
            //{
            //    model.SpouseCount = 1;
            //    var spouse = new SpouseDTO()
            //    {
            //        SpouseJob = "",
            //        SpouseMobile = "",
            //        EmploymentId = (long)authinfo.EmploymentId
            //    };
            //    model.Spouse =
            //    [
            //        spouse
            //    ];
            //}


            #region SaveInDateBase

            if (!(bool)authinfo.IsConfirmHumanResourceUnit)
            {
                _specificationMemory.Set("SaveSpecification", model);
                var sponsership=_sponserShipMemoryCache.Get("SaveSponsershipInfo");
                if (sponsership.Any())
                {
                    var lstSponser = sponsership.Where(s => s.Relation == (byte)Relation.Spouse).ToList();
                    for (int i = 0; i < lstSponser.Count(); i++)
                    {
                        lstSponser[i].SpouseJob = sponsership[i].SpouseJob;
                        lstSponser[i].SpouseMobile = sponsership[i].SpouseMobile;
                    }
                }

                var result = await _employmentService.AddEmploymentStep3(model,sponsership);
                if (result == EditEmploymentResult.Error)
                    TempData[ErrorMessage] = "برای ذخیره اطلاعات در بانک اطاعاتی ،مجددا تلاش کنید";
            }
            #endregion
            return RedirectToAction(nameof(AddEducationalRecord));
        }
        #endregion
        #region Step5
        #region Add
        [HttpGet("add-educationalRecord")]
        public async Task<IActionResult> AddEducationalRecord()
        {
            List<EducationalRecords>? educationalRecords = _educationalRecordMemory.Get("SaveEdu");
            EducationalRecordsDTO model = new EducationalRecordsDTO();
            CascadingDTO cascadingDto = new CascadingDTO();
            cascadingDto.States = await _cityService.GetAllProvince();
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            model.CascadingDto = cascadingDto;
            return View(model);
        }
        [HttpPost("add-educationalRecord")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEducationalRecord(EducationalRecordsDTO model)
        {
            List<EducationalRecords>? educationalRecords = _educationalRecordMemory.Get("SaveEdu");
            CascadingDTO cascadingDto = new CascadingDTO();
            cascadingDto.States = await _cityService.GetAllProvince();
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(model.ProvinceOfPlaceOfStudyId.ToString()));
            model.CascadingDto = cascadingDto;
            if (model.YearOfStartingEducation > model.YearOfEndingEducation)
            {
                TempData[ErrorMessage] = "سال پایان باید از سال شروع بزرگتر مساوی باشد.";
                return View(model);
            }
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            EducationalRecords recored = new EducationalRecords
            {
                Id = (educationalRecords == null || educationalRecords.Count == 0) ? 1 : educationalRecords.Count + 1,
                CityOfPlaceOfStudyId = model.CityOfPlaceOfStudyId,
                Avg = (decimal)model.Avg,
                DegreeOfEducation = model.DegreeOfEducation,
                FieldOfStudy = model.FieldOfStudy,
                IsEndOfDegreeOfEducation = model.IsEndOfDegreeOfEducation,
                ProvinceOfPlaceOfStudyId = model.ProvinceOfPlaceOfStudyId,
                YearOfStartingEducation = model.YearOfStartingEducation,
                YearOfEndingEducation = model.YearOfEndingEducation,
                CentralEducation = model.CentralEducation,
                ProvinceOfPlaceOfStudy = cascadingDto.States.Find(s => s.Value == model.ProvinceOfPlaceOfStudyId.Value.ToString()).Text,
                CityOfPlaceOfStudy = cascadingDto.Cities.Find(s => s.Value == model.CityOfPlaceOfStudyId.Value.ToString()).Text,
            };
            educationalRecords ??= new List<EducationalRecords>();
            if(recored.IsEndOfDegreeOfEducation)
            foreach (var item in educationalRecords)
            {
                item.IsEndOfDegreeOfEducation = false;
            }
            educationalRecords.Add(recored);
            _educationalRecordMemory.Set("SaveEdu", educationalRecords);
            model = new EducationalRecordsDTO
            {
                CascadingDto = cascadingDto
            };
            return RedirectToAction(nameof(AddEducationalRecord));
        }
        [HttpPost("add-educationalRecordFinal")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEducationalRecordFinal(EducationalRecordsDTO model)
        {
            var educationalRecords = _educationalRecordMemory.Get("SaveEdu");
            if (educationalRecords == null || educationalRecords.Count == 0)
            {
                CascadingDTO cascadingDto = new()
                {
                    States = await _cityService.GetAllProvince()
                };
                cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
                model.CascadingDto = cascadingDto;
                return View("AddEducationalRecord", model);
            }
            #region savedatabase
            var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
            if (!(bool)authinfo.IsConfirmHumanResourceUnit)
            {
                var dbEdu = new List<EducationalRecode>();
                foreach (var item in educationalRecords)
                {
                    var edu = new EducationalRecode
                    {
                        CentralEducation = item.CentralEducation,
                        Avg = item.Avg,
                        CityOfPlaceOfStudyId = item.CityOfPlaceOfStudyId,
                        DegreeOfEducation = item.DegreeOfEducation,
                        FieldOfStudy = item.FieldOfStudy,
                        IsEndOfDegreeOfEducation = item.IsEndOfDegreeOfEducation,
                        ProvinceOfPlaceOfStudyId = item.ProvinceOfPlaceOfStudyId,
                        YearOfStartingEducation = item.YearOfStartingEducation,
                        YearOfEndingEducation = item.YearOfEndingEducation,
                        IsDelete = item.IsDelete,
                        EmploymentId = (long)authinfo.EmploymentId

                    };
                    dbEdu.Add(edu);
                }

                await _educationalRecordService.AddEducation(dbEdu, (long)authinfo.EmploymentId);
            }
            await _employmentService.Update_Step((long)authinfo.EmploymentId, 5);
            #endregion
            return RedirectToAction(nameof(AddWorkExperience));
        }

        #endregion
        #region Edit
        [HttpGet()]
        public async Task<IActionResult> EditEducationalRecord(long Id)
        {
            var educationalRecords = _educationalRecordMemory.Get("SaveEdu");
            if (educationalRecords == null) return NotFound();
            var record = new EditEducationalRecordsDTO
            {
                Id = educationalRecords.FirstOrDefault(e => e.Id == Id).Id,
                CentralEducation = educationalRecords.FirstOrDefault(e => e.Id == Id).CentralEducation,
                CityOfPlaceOfStudyId = educationalRecords.FirstOrDefault(e => e.Id == Id).CityOfPlaceOfStudyId,
                Avg = (decimal)educationalRecords.FirstOrDefault(e => e.Id == Id).Avg,
                IsEndOfDegreeOfEducation = educationalRecords.FirstOrDefault(e => e.Id == Id).IsEndOfDegreeOfEducation,
                DegreeOfEducation = educationalRecords.FirstOrDefault(e => e.Id == Id).DegreeOfEducation,
                FieldOfStudy = educationalRecords.FirstOrDefault(e => e.Id == Id).FieldOfStudy,
                ProvinceOfPlaceOfStudyId = educationalRecords.FirstOrDefault(e => e.Id == Id).ProvinceOfPlaceOfStudyId,
                YearOfStartingEducation = educationalRecords.FirstOrDefault(e => e.Id == Id).YearOfStartingEducation,
                YearOfEndingEducation = educationalRecords.FirstOrDefault(e => e.Id == Id).YearOfEndingEducation,
                ProvinceOfPlaceOfStudy = educationalRecords.FirstOrDefault(e => e.Id == Id).ProvinceOfPlaceOfStudy,
                CityOfPlaceOfStudy = educationalRecords.FirstOrDefault(e => e.Id == Id).CityOfPlaceOfStudy,

            };

            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince(),
                Cities = await _cityService.GetCityByProvinceId(long.Parse(record.ProvinceOfPlaceOfStudyId.ToString()))
            };
            record.CascadingDto = cascadingDto;
            var result = record;
            return Json(result);
        }

        [HttpPost("edit-educationalRecord"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEducationalRecord(EducationalRecordsDTO model)
        {

            CascadingDTO cascadingDto = new CascadingDTO();
            cascadingDto.States = await _cityService.GetAllProvince();
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(model.ProvinceOfPlaceOfStudyId.ToString()));
            model.CascadingDto = cascadingDto;
            if (model.YearOfStartingEducation > model.YearOfEndingEducation)
            {

                TempData[ErrorMessage] = "سال پایان باید از سال شروع بزرگتر مساوی باشد.";
                return View("AddEducationalRecord", model);
            }
            List<EducationalRecords>? educationalRecords = _educationalRecordMemory.Get("SaveEdu");
            if (educationalRecords == null) return NotFound();
            var record = educationalRecords.FirstOrDefault(s => s.Id == model.Id);
            foreach (var edu in (List<EducationalRecords>)educationalRecords)
            {
                if (model.IsEndOfDegreeOfEducation)
                    edu.IsEndOfDegreeOfEducation = false;
                if (edu.Id == model.Id)
                {
                    edu.Id = model.Id;
                    edu.ProvinceOfPlaceOfStudyId = model.ProvinceOfPlaceOfStudyId;
                    edu.Avg = (decimal)model.Avg;
                    edu.IsEndOfDegreeOfEducation = model.IsEndOfDegreeOfEducation;
                    edu.CityOfPlaceOfStudyId = model.CityOfPlaceOfStudyId;
                    edu.DegreeOfEducation = model.DegreeOfEducation;
                    edu.FieldOfStudy = model.FieldOfStudy;
                    edu.YearOfEndingEducation = model.YearOfEndingEducation;
                    edu.YearOfStartingEducation = model.YearOfStartingEducation;
                    edu.CentralEducation = model.CentralEducation;
                    edu.ProvinceOfPlaceOfStudy = cascadingDto.States
                        .Find(s => s.Value == model.ProvinceOfPlaceOfStudyId.Value.ToString()).Text;
                    edu.CityOfPlaceOfStudy = cascadingDto.Cities
                        .Find(s => s.Value == model.CityOfPlaceOfStudyId.Value.ToString()).Text;

                    edu.IsEditable = true;
                }
            }
            _educationalRecordMemory.Set("SaveEdu", educationalRecords);
            return RedirectToAction(nameof(AddEducationalRecord));
        }
        #endregion
        #region Delete
        [HttpGet("delete-educationalRecord/{Id}")]
        public async Task<IActionResult> DeleteEducationalRecord(long Id)
        {

            List<EducationalRecords>? educationalRecords = _educationalRecordMemory.Get("SaveEdu");
            if (educationalRecords == null) return NotFound();
            var record = educationalRecords.FirstOrDefault(s => s.Id == Id);
            record.IsDelete = true;
            EducationalRecordsDTO model = new EditEducationalRecordsDTO();
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            model.CascadingDto = cascadingDto;
            _educationalRecordMemory.Set("SaveEdu", educationalRecords);
            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "حذف با موفقیت انجام شد", educationalRecords);
        }

        #endregion
        #endregion
        #region Step6
        #region Add
        [HttpGet("add-workExperience")]
        public async Task<IActionResult> AddWorkExperience()
        {
            var workExperience = _workExperienceMemory.Get("SaveWork");
            var model = new WorkExperienceDTO();
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities =
                await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            model.CascadingDto = cascadingDto;
            return View(model);
        }
        [HttpPost("add-workExperience")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkExperience(WorkExperienceDTO model)
        {
            List<WorkExperienceRecords>? workExperience = _workExperienceMemory.Get("SaveWork");
            CascadingDTO cascadingDto = new CascadingDTO();
            cascadingDto.States = await _cityService.GetAllProvince();
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(model.ProvinceOfJobId.ToString()));
            model.CascadingDto = cascadingDto;
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            if (model.YearOfStartingJob > model.YearOfEndingJob)
            {
                TempData[ErrorMessage] = "سال پایان باید از سال شروع بزرگتر مساوی باشد.";
                return View(model);
            }
            WorkExperienceRecords recored = new WorkExperienceRecords
            {
                Id = (workExperience == null || workExperience.Count == 0) ? 1 : workExperience.Count + 1,
                CityOfJobId = model.CityOfJobId,
                ProvinceOfJobId = model.ProvinceOfJobId,
                CompanyName = model.CompanyName,
                JobTitle = model.JobTitle,
                YearOfStartingJob = model.YearOfStartingJob,
                YearOfEndingJob = model.YearOfEndingJob,
                ReasonForLeavingWork = model.ReasonForLeavingWork,
                ProvinceOfJob = cascadingDto.States.Find(s => s.Value == model.ProvinceOfJobId.Value.ToString()).Text,
                CityOfPlaceOfJob = cascadingDto.Cities.Find(s => s.Value == model.CityOfJobId.Value.ToString()).Text,
            };
            if (workExperience == null)
                workExperience = new List<WorkExperienceRecords>();
            workExperience.Add(recored);

            _workExperienceMemory.Set("SaveWork", workExperience);
            model = new WorkExperienceDTO();
            model.CascadingDto = cascadingDto;
            return RedirectToAction(nameof(AddWorkExperience));
        }

        [HttpPost("add-workExperienceFinal")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkExperienceFinal(WorkExperienceDTO model)
        {
            List<WorkExperienceRecords>? workExperienceRecords = _workExperienceMemory.Get("SaveWork");
            if (workExperienceRecords == null || workExperienceRecords.Count == 0)
            {
                CascadingDTO cascadingDto = new CascadingDTO();
                cascadingDto.States = await _cityService.GetAllProvince();
                cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
                model.CascadingDto = cascadingDto;

                return View("AddWorkExperience", model);
            }
            #region savedatabase
            var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
            if (!(bool)authinfo.IsConfirmHumanResourceUnit)
            {
                var dbWork = new List<WorkExperience>();
                foreach (var item in workExperienceRecords)
                {
                    var wrk = new WorkExperience();
                    wrk.CityOfJobId = item.CityOfJobId;
                    wrk.CompanyName = item.CompanyName;
                    wrk.ProvinceOfJobId = item.ProvinceOfJobId;
                    wrk.JobTitle = item.JobTitle;
                    wrk.ReasonForLeavingWork = item.ReasonForLeavingWork;
                    wrk.YearOfStartingJob = item.YearOfStartingJob;
                    wrk.YearOfEndingJob = item.YearOfEndingJob;
                    wrk.EmploymentId = (long)authinfo.EmploymentId;
                    wrk.IsDelete = item.IsDelete;
                    dbWork.Add(wrk);
                }
                await _workExperienceService.AddWorkExperience(dbWork, (long)authinfo.EmploymentId);
            }

            await _employmentService.Update_Step((long)authinfo.EmploymentId, 6);
            #endregion

            return RedirectToAction(nameof(AddAcquaintances));
        }
        #endregion
        #region Edit
        [HttpGet()]
        public async Task<IActionResult> EditWorkExperienceRecord(long Id)
        {
            var workExperience = _workExperienceMemory.Get("SaveWork"); ;
            if (workExperience == null) return NotFound();
            var record = new WorkExperienceDTO
            {
                Id = workExperience.FirstOrDefault(e => e.Id == Id).Id,
                CityOfJobId = workExperience.FirstOrDefault(e => e.Id == Id).CityOfJobId,
                CompanyName = workExperience.FirstOrDefault(e => e.Id == Id).CompanyName,
                JobTitle = workExperience.FirstOrDefault(e => e.Id == Id).JobTitle,
                ProvinceOfJobId = workExperience.FirstOrDefault(e => e.Id == Id).ProvinceOfJobId,
                ReasonForLeavingWork = workExperience.FirstOrDefault(e => e.Id == Id).ReasonForLeavingWork,
                YearOfEndingJob = workExperience.FirstOrDefault(e => e.Id == Id).YearOfEndingJob,
                YearOfStartingJob = workExperience.FirstOrDefault(e => e.Id == Id).YearOfStartingJob,

            };
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince(),
                Cities = await _cityService.GetCityByProvinceId(long.Parse(record.ProvinceOfJobId.ToString()))
            };
            record.CascadingDto = cascadingDto;
            var result = record;
            return Json(result);
        }
        [HttpPost("edit-workExperienceRecord"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWorkExperienceRecord(WorkExperienceDTO model)
        {
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince(),
                Cities = await _cityService.GetCityByProvinceId(long.Parse(model.ProvinceOfJobId.ToString()))
            };
            model.CascadingDto = cascadingDto;
            var workExperienceRecords = _workExperienceMemory.Get("SaveWork");
            if (workExperienceRecords == null) return NotFound();
            if (model.YearOfStartingJob > model.YearOfEndingJob)
            {

                TempData[ErrorMessage] = "سال پایان باید از سال شروع بزرگتر مساوی باشد.";
                return View("AddWorkExperience");
            }
            var record = workExperienceRecords.FirstOrDefault(s => s.Id == model.Id);
            foreach (var wrk in ((List<WorkExperienceRecords>)workExperienceRecords).Where(wrk => wrk.Id == model.Id))
            {
                wrk.CityOfJobId = model.CityOfJobId;
                wrk.CompanyName = model.CompanyName;
                wrk.JobTitle = model.JobTitle;
                wrk.ProvinceOfJobId = model.ProvinceOfJobId;
                wrk.ReasonForLeavingWork = model.ReasonForLeavingWork;
                wrk.YearOfEndingJob = model.YearOfEndingJob;
                wrk.YearOfStartingJob = model.YearOfStartingJob;
                wrk.ProvinceOfJob = cascadingDto.States
                    .Find(s => s.Value == model.ProvinceOfJobId.Value.ToString()).Text;
                wrk.CityOfPlaceOfJob = cascadingDto.Cities
                    .Find(s => s.Value == model.CityOfJobId.Value.ToString()).Text;


            }
            _workExperienceMemory.Set("SaveWork", workExperienceRecords);
            return RedirectToAction(nameof(AddWorkExperience));
        }
        #endregion
        #region Delete
        [HttpGet("delete-workExperienceRecord/{Id}")]
        public async Task<IActionResult> DeleteWorkExperienceRecord(long Id)
        {
            var workingRecords = _workExperienceMemory.Get("SaveWork");
            if (workingRecords == null) return NotFound();
            var record = workingRecords.FirstOrDefault(s => s.Id == Id);
            record.IsDelete = true;
            var model = new WorkExperienceDTO();
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            model.CascadingDto = cascadingDto;
            _workExperienceMemory.Set("SaveWork", workingRecords);
            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success, "حذف با موفقیت انجام شد", workingRecords);

        }

        #endregion
        #endregion
        #region Step7

        [HttpGet("add-acquaintances")]
        public async Task<IActionResult> AddAcquaintances()
        {
            AcquaintancesDTO? acquaintances = _acquaintancesMemory.Get("SaveAcquaintance");
            return View(acquaintances ?? new AcquaintancesDTO());
        }
        [HttpPost("add-acquaintances")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAcquaintances(AcquaintancesDTO model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            if (model.FirstFamiliarMobile == model.SecondFamiliarMobile ||
               model.FirstFamiliarMobile == model.AccessiblePersonMobile ||
               model.SecondFamiliarMobile == model.AccessiblePersonMobile
               )
            {
                TempData[ErrorMessage] = "شماره همراه وارد شده برای آشنایان ،نباید تکراری باشد.";
                return View(model);
            }
            _acquaintancesMemory.Set("SaveAcquaintance", model);

            #region SaveInDataBase
            var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
            if (!(bool)authinfo.IsConfirmHumanResourceUnit)
            {
                var result = await _employmentService.AddEmploymentStep7(model, (long)authinfo.EmploymentId);
                if (result == EditEmploymentResult.Error)
                {
                    TempData[ErrorMessage] = "برای ذخیره اطلاعات در بانک اطاعاتی ،مجددا تلاش کنید";
                    return RedirectToAction(nameof(AddEducationalRecord));
                }
            }
            #endregion
            return RedirectToAction(nameof(AddAbilities));
        }

        #endregion
        #region Step8
        [HttpGet("add-abilities")]
        public async Task<IActionResult> AddAbilities()
        {
            AbilitiesDTOMem? abilitiesmem = _abilitiesMemory.Get("SaveAbility");
            if (abilitiesmem != null)
            {
                AbilitiesDTO abilities = new AbilitiesDTO
                {
                    ResumeFileUrl = abilitiesmem.ResumeFile,
                    AbilityTitle = abilitiesmem.AbilityTitle,
                    AbilityToTravelAsAMission = abilitiesmem.AbilityToTravelAsAMission,
                    AbilityToWorkInClericalJobs = abilitiesmem.AbilityToWorkInClericalJobs,
                    AbilityToWorkInShifts = abilitiesmem.AbilityToWorkInShifts,
                    DescriptionOfAccident = abilitiesmem.DescriptionOfAccident,
                    Entertainments = abilitiesmem.Entertainments,
                    HavingAnAccident = abilitiesmem.HavingAnAccident,
                    Ideas = abilitiesmem.Ideas


                };
                return View(abilities);
            }
            else
            {
                return View(new AbilitiesDTO());
            }


        }
        [HttpPost("add-abilities")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAbilities(AbilitiesDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            #region CheckFile
            string fileName = "";
            FileSetting fileSetting = GeFileSetting();
            if (model.ResumeFile != null)
            {
                if (model.ResumeFile.Length <= 0) return null;
                else
                {

                    if (model.ResumeFile.Length > long.Parse(fileSetting.FileSize) * 1024)
                    {
                        TempData[ErrorMessage] = " حداکثر اندازه فایل " + (long.Parse(fileSetting.FileSize)).ToString() + " مگابایت می باشد ";
                        return View(model);
                    }
                }
                if (!model.ResumeFile.IsPdf())
                {
                    TempData[ErrorMessage] = "لطفا یک فایل با فرمت " + fileSetting.FileFormat + " انتخاب کنید";
                    return View(model);

                }
                else
                {
                    fileName = Guid.NewGuid() + Path.GetExtension(model.ResumeFile.FileName).ToLower();
                    model.ResumeFile.AddFileToServer(fileName, PathExtension.ResumeFileServerOrigin);
                    model.ResumeFileUrl = fileName;
                }
            }
            #endregion
            var abilities = new AbilitiesDTOMem
            {
                ResumeFile = model.ResumeFileUrl,
                AbilityTitle = model.AbilityTitle,
                AbilityToTravelAsAMission = model.AbilityToTravelAsAMission,
                AbilityToWorkInClericalJobs = model.AbilityToWorkInClericalJobs,
                AbilityToWorkInShifts = model.AbilityToWorkInShifts,
                DescriptionOfAccident = model.DescriptionOfAccident,
                Entertainments = model.Entertainments,
                HavingAnAccident = model.HavingAnAccident,
                Ideas = model.Ideas


            };
            _abilitiesMemory.Set("SaveAbility", abilities);
            #region SaveInDataBase
            var authinfo = _authorizationMemoryCache.Get("SaveAuthorization");
            if (!(bool)authinfo.IsConfirmHumanResourceUnit)
            {
                var result = await _employmentService.AddEmploymentStep8(model, (long)authinfo.EmploymentId);
                if (result == EditEmploymentResult.Error)
                {
                    TempData[ErrorMessage] = "برای ذخیره اطلاعات در بانک اطاعاتی ،مجددا تلاش کنید";
                    return RedirectToAction(nameof(AddEducationalRecord));
                }

            }
            #endregion
            return RedirectToAction(nameof(EndStep));
        }
        #endregion
        #region Step9
        [HttpGet("endstep")]
        public async Task<IActionResult> EndStep()
        {

            EmploymentDTO model = new EmploymentDTO();
            model.Authentication = _authenticationMemory.Get("SaveAuth");
            model.Authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            model.Specification = _specificationMemory.Get("SaveSpecification");
            model.Acquaintances = _acquaintancesMemory.Get("SaveAcquaintance");
            model.Abilities = _abilitiesMemory.Get("SaveAbility");
            model.PersonalImage = _personalImageMemory.Get("SavePersonalImage");
            model.EducationalRecord = _educationalRecordMemory.Get("SaveEdu");
            model.WorkExperience = _workExperienceMemory.Get("SaveWork");
            //model.Specification.Spouse = _sponserShipMemoryCache.Get("SaveSponsershipInfo");
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            model.Cascading = cascadingDto;
            SatisfactionRules rule = GeRuleSetting();
            var endStep = new EndStepDTO()
            {
                SatisfactionRules = rule.Rule,
                EmploymentId = (long)model.Authorization.EmploymentId
            };
            model.EndStep = endStep;

            return View(model);
        }
        [HttpPost("endstep"), ValidateAntiForgeryToken]
        public async Task<IActionResult> EndStep(EmploymentDTO model2)
        {

            var endStepInfo = _endStepMemory.Get("SaveEndStep");
            var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            var auth = _authenticationMemory.Get("SaveAuth");
            if (!(bool)authorization.IsUploadDoc && authorization.TrackingCode==0)
            {
                SatisfactionRules rule = GeRuleSetting();
                var endStep = new EndStepDTO
                {
                    SatisfactionRules = rule.Rule,
                    EmploymentId = (long)authorization.EmploymentId
                };

                if (authorization.EmploymentLoginResult == EmploymentLoginResultenum.NotExists ||
                    (authorization.EmploymentLoginResult == EmploymentLoginResultenum.Success &&
                     authorization.TrackingCode == 0))
                {
                    #region SendCodePeygiri

                    Random r = new Random();
                    int trackingcode;
                    trackingcode = r.Next(10000000, 99999999);
                    while (true)
                    {
                        if (await _employmentService.CheckExistsTrackingCode(trackingcode))
                            trackingcode = r.Next(10000000, 99999999);
                        else
                            break;
                    }

                    #endregion

                    endStep.TrackingCode = trackingcode;
                    var result = await _employmentService.AddEmploymentStep9(endStep);
                    SendSms(auth.Mobile, SendSmsType.ForTrackingCode, trackingcode.ToString());
                    TempData[SuccessMessage] = "اطلاعات شما با موفقیت در سامانه ثبت شد.";
                    _endStepMemory.Set("SaveEndStep", endStep);

                }
                else if (authorization.EmploymentLoginResult == EmploymentLoginResultenum.Success)
                {
                    if (endStepInfo.TrackingCode == 0)
                    {
                        #region SendCodePeygiri

                        Random r = new Random();
                        int trackingcode;
                        trackingcode = r.Next(10000000, 99999999);
                        while (true)
                        {
                            if (await _employmentService.CheckExistsTrackingCode(trackingcode))
                                trackingcode = r.Next(10000000, 99999999);
                            else
                                break;
                        }

                        #endregion

                        endStep.TrackingCode = trackingcode;
                        if (!(bool)authorization.IsConfirmHumanResourceUnit)
                        {
                            var result = await _employmentService.AddEmploymentStep9(endStep);
                            TempData[SuccessMessage] = "اطلاعات شما با موفقیت در سامانه ثبت شد.";
                        }

                    }

                }

                return RedirectToAction("EndStepForShowCode");
            }
            else
                return RedirectToAction("SupplementaryStep");

        }
        [HttpGet("endstep-showcode")]
        public async Task<IActionResult> EndStepForShowCode()
        {
            EmploymentDTO model = new EmploymentDTO();
            model.Authentication = _authenticationMemory.Get("SaveAuth");
            var endStepInfo = _endStepMemory.Get("SaveEndStep");
            if (endStepInfo != null)
            {
                var endStep = new EndStepDTO()
                {
                    TrackingCode = endStepInfo.TrackingCode

                };
                model.EndStep = endStep;
                var authentication = new AuthenticationDTO();
                _authenticationMemory.Set("SaveAuth", authentication);
                var endStepmem = new EndStepDTO();
                _endStepMemory.Set("SaveEndStep", endStepmem);
            }

            return View(model);
        }

        #endregion
        #region Step10
        [HttpGet("supplementarystep")]
        public async Task<IActionResult> SupplementaryStep()
        {
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities =
                await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            if (authorization == null) RedirectToAction("Index");
            var SupplementaryInfo = _supplementaryInfoMemory.Get("SaveSupplementaryInfo");
            var model = new SupplementaryInfoStepDTO
            {
                Authorization = authorization,
                InformationDto = SupplementaryInfo,
                CascadingDto = cascadingDto

            };
            if (authorization.MaritalStatus != MaritalStatus.Single)
            {
                var sponsershipInfo = _sponserShipMemoryCache.Get("SaveSponsershipInfo");
                model.SponsershipDto = sponsershipInfo.Select(a => new SponsershipDTO()
                {
                    Name = a.Name,
                    Family = a.Family,
                    NationCode = a.NationCode,
                    Gender = a.Gender,
                    MaritalStatus = a.MaritalStatus,
                    BasicInsurance = a.BasicInsurance,
                    BirthCertificateId = a.BirthCertificateId,
                    BrithDate = a.BrithDate,
                    FatherName = a.FatherName,
                    IsCovered = (bool)a.IsCovered,
                    ProvinceId = a.ProvinceId,
                    ProvinceOfIssueId = a.ProvinceOfIssueId,
                    Relation = a.Relation,
                    SerialInsurance = a.SerialInsurance,
                    EmploymentId = a.EmploymentId


                }).ToList();
            }
            return View(model);

        }

        [HttpPost("supplementarystep"), ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplementaryStep(SupplementaryInfoStepDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities =
                await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            model.CascadingDto = cascadingDto;
            var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            if (authorization == null) RedirectToAction("Index");
            model.Authorization = authorization;
            if (model.SponsershipDto != null)
            {
                var error = false;
                foreach (var item in model.SponsershipDto)
                {
                    if (!item.NationCode.IsValidNationalCode())
                    {
                        TempData[ErrorMessage] = "کد ملی وارد شده معتبر نمی باشد";
                        error = true;
                        break;
                    }
                }

                if (error)
                    return View(model);
            }

            _supplementaryInfoMemory.Set("SaveSupplementaryInfo", model.InformationDto);
            #region SaveInDataBase
            if (!(bool)model.Authorization.IsConfirmHumanResourceUnit)
            {
                var resultSupplementaryInfo = await _employmentService.AddSupplementaryInfo(model.InformationDto,
                    (long)model.Authorization?.EmploymentId);
                if (resultSupplementaryInfo == EditEmploymentResult.Error)
                {
                    TempData[ErrorMessage] = "برای ذخیره اطلاعات در بانک اطاعاتی ،مجددا تلاش کنید";
                    return RedirectToAction(nameof(SupplementaryStep));
                }
                if (model.SponsershipDto != null)
                {
                    var spouseList = model.SponsershipDto.Select(a => new SpouseDTO()
                    {
                        Name = a.Name,
                        Family = a.Family,
                        NationCode = a.NationCode,
                        Gender = a.Gender,
                        MaritalStatus = a.MaritalStatus,
                        BasicInsurance = a.BasicInsurance,
                        BirthCertificateId = a.BirthCertificateId,
                        BrithDate = a.BrithDate,
                        FatherName = a.FatherName,
                        IsCovered = (bool)a.IsCovered,
                        ProvinceId = a.ProvinceId,
                        ProvinceOfIssueId = a.ProvinceOfIssueId,
                        Relation = a.Relation,
                        SerialInsurance = a.SerialInsurance,
                        EmploymentId = a.EmploymentId

                    }).ToList();
                    SpecificationsDTO? specifications = _specificationMemory.Get("SaveSpecification");

                    var result = await _employmentSpouse.AddSpouse(specifications.Spouse, (long)model.Authorization?.EmploymentId, spouseList);
                    if (!result)
                    {
                        TempData[ErrorMessage] = "برای ذخیره اطلاعات در بانک اطاعاتی ،مجددا تلاش کنید";
                        return RedirectToAction(nameof(SupplementaryStep));
                    }
                }
            }
            #endregion
            return RedirectToAction(nameof(UploadDocument));
        }

        #endregion
        #region SendSms
        private void SendSms(string mobile, SendSmsType MessageType, string code)
        {
            //using (WebClient client = new WebClient())
            //{
            //    string response = client.DownloadString(url);
            //    //return await Task.FromResult(true);
            //}
            SMSSetting smsSetting = GetSMSSetting();
            NameValueCollection _NameValueCollection = new NameValueCollection();
            _NameValueCollection.Add("api_key", smsSetting.api_key);
            _NameValueCollection.Add("receiver_number", mobile);
            _NameValueCollection.Add("sender_number", smsSetting.SenderNumber);
            if (MessageType == SendSmsType.ForAuthentication)//ارسال کد احراز هویت
                _NameValueCollection.Add("note_arr[]", smsSetting.MessageForAuth.Replace("{0}", code));
            else
                _NameValueCollection.Add("note_arr[]", smsSetting.MessageForTrackingCode.Replace("{0}", code));

            WebClient _CLIENT = new WebClient();
            byte[] response = _CLIENT.UploadValues("http://toptip.ir/webservice/rest/sms_send?",
                _NameValueCollection);
            string result = System.Text.Encoding.UTF8.GetString(response);
            //result.ToString().Split('\r')[0]
        }
        #endregion
        #region UploadDocument

        [HttpGet("upload-document")]
        public async Task<IActionResult> UploadDocument()
        {
            var authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            var docFile = _documentMemory.Get("SaveDocFile");
            DocumentModel objdocument = new();
            if (authorization == null) return View(objdocument);
            var sponsorshipDoc = new List<DocumentModel>();
            var childDoc = new List<DocumentModel>();
            var nationDoc = new List<DocumentModel>();
            var index = 10;
            if (authorization.Gender == Gender.Women)
                index = 9;
            var sponsorshipCount = authorization.SponsorshipCount;
            int cntPageBirthCertificate = 4;
            int cntPageNationalCard = 2;
            var childCount = authorization.ChildrenCount;
            for (int i = 0; i < sponsorshipCount; i++) // تعداد تحت تکغل
            {
                var sponsorshipPage1 = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (sponsorshipCount > 1 ? TypeDocument.SponsorshipPage1.GetDisplayName() + (i + 1).ToString() : TypeDocument.SponsorshipPage1.GetDisplayName()),
                    DocumentType = TypeDocument.SponsorshipPage1,
                    Mandatory = 1,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.SponsorshipPage1)
                        ?.FileName
                };
                index++;
                sponsorshipDoc.Add(sponsorshipPage1);
                var sponsorshipPage2 = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (sponsorshipCount > 1 ? TypeDocument.SponsorshipPage2.GetDisplayName() + (i + 1).ToString() : TypeDocument.SponsorshipPage2.GetDisplayName()),
                    DocumentType = TypeDocument.SponsorshipPage2,
                    Mandatory = 1,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.SponsorshipPage2)
                        ?.FileName
                };
                sponsorshipDoc.Add(sponsorshipPage2);
                index++;
                var sponsorshipPage3 = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (sponsorshipCount > 1 ? TypeDocument.SponsorshipPage3.GetDisplayName() + (i + 1).ToString() : TypeDocument.SponsorshipPage3.GetDisplayName()),
                    DocumentType = TypeDocument.SponsorshipPage3,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.SponsorshipPage3)
                        ?.FileName,
                    Mandatory = 1
                };
                sponsorshipDoc.Add(sponsorshipPage3);
                index++;
                var sponsorshipDescription = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (sponsorshipCount > 1 ? TypeDocument.SponsorshipDescription.GetDisplayName() + (i + 1).ToString() : TypeDocument.SponsorshipDescription.GetDisplayName()),
                    DocumentType = TypeDocument.SponsorshipDescription,
                    DocumentFileName = docFile
                        ?.FirstOrDefault(a => a.TypeDocument == TypeDocument.SponsorshipDescription)?.FileName,
                    Mandatory = 1
                };

                sponsorshipDoc.Add(sponsorshipDescription);
                //index++;
            }

            index = index + (int)sponsorshipCount;
            for (int i = 0; i < sponsorshipCount; i++) //تصویر کارت ملی افراد تحت تکفل
            {
                var nationPage1 = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (sponsorshipCount > 1 ? TypeDocument.SponsorshipNationPage1.GetDisplayName() + (i + 1).ToString() : TypeDocument.SponsorshipNationPage1.GetDisplayName()),
                    DocumentType = TypeDocument.SponsorshipNationPage1,
                    DocumentFileName = docFile
                        ?.FirstOrDefault(a => a.TypeDocument == TypeDocument.SponsorshipNationPage1)?.FileName,
                    Mandatory = 1
                };
                index++;
                var nationPage2 = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (sponsorshipCount > 1 ? TypeDocument.SponsorshipNationPage2.GetDisplayName() + (i + 1).ToString() : TypeDocument.SponsorshipNationPage2.GetDisplayName()),
                    DocumentType = TypeDocument.SponsorshipNationPage2,
                    DocumentFileName = docFile
                        ?.FirstOrDefault(a => a.TypeDocument == TypeDocument.SponsorshipNationPage2)?.FileName,
                    Mandatory = 1
                };

                nationDoc.Add(nationPage1);
                nationDoc.Add(nationPage2);
                //index++;

            }

            index++;
            for (int i = 0; i < childCount; i++)
            {
                var childPage1 = new DocumentModel
                {
                    DocumentID = index + i,
                    DocumentName = (childCount > 1 ? TypeDocument.ChildPage1.GetDisplayName() + (i + 1).ToString() : TypeDocument.ChildPage1.GetDisplayName()),
                    DocumentType = TypeDocument.ChildPage1,
                    DocumentFileName =
                        docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.ChildPage1)?.FileName,
                    Mandatory = 1
                };
                childDoc.Add(childPage1);

            }



            //if (authorization.Gender == Gender.Men)
            //{
            objdocument.DocumentList =
            [
                new DocumentModel
                {
                    DocumentID = 1,
                    DocumentName = TypeDocument.PageOne.GetDisplayName(),
                    DocumentType = TypeDocument.PageOne,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.PageOne)
                        ?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 2,
                    DocumentName = TypeDocument.PageTwo.GetDisplayName(),
                    DocumentType = TypeDocument.PageTwo,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.PageTwo)
                        ?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 3,
                    DocumentName = TypeDocument.PageThree.GetDisplayName(),
                    DocumentType = TypeDocument.PageThree,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.PageThree)
                        ?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 4,
                    DocumentName = TypeDocument.PageDescription.GetDisplayName(),
                    DocumentType = TypeDocument.PageDescription,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.PageDescription)
                        ?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 5,
                    DocumentName = TypeDocument.NationCodePage1.GetDisplayName(),
                    DocumentType = TypeDocument.NationCodePage1,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.NationCodePage1)
                        ?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 6,
                    DocumentName = TypeDocument.NationCodePage2.GetDisplayName(),
                    DocumentType = TypeDocument.NationCodePage2,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.NationCodePage2)
                        ?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 7,
                    DocumentName = TypeDocument.DegreeOfEducation.GetDisplayName(),
                    DocumentType = TypeDocument.DegreeOfEducation,
                    DocumentFileName = docFile
                        ?.FirstOrDefault(a => a.TypeDocument == TypeDocument.DegreeOfEducation)?.FileName,
                    Mandatory = 1
                },
                new DocumentModel
                {
                    DocumentID = 8,
                    DocumentName = TypeDocument.InsuranceHistory.GetDisplayName(),
                    DocumentType = TypeDocument.InsuranceHistory,
                    DocumentFileName = docFile?.FirstOrDefault(a => a.TypeDocument == TypeDocument.InsuranceHistory)
                        ?.FileName,
                    Mandatory = 1
                }
            ];
            if (authorization.Gender == Gender.Men)
            {
                objdocument.DocumentList.Add(new DocumentModel
                {
                    DocumentID = 9,
                    DocumentName = TypeDocument.TheEndOfServiceImage.GetDisplayName(),
                    DocumentType = TypeDocument.TheEndOfServiceImage,
                    DocumentFileName = docFile
                        ?.FirstOrDefault(a => a.TypeDocument == TypeDocument.TheEndOfServiceImage)?.FileName,
                    Mandatory = 1
                });
            }


            objdocument.DocumentList.Add(new DocumentModel
            {
                DocumentID = -1,
                DocumentList = sponsorshipDoc,
                DocumentType = TypeDocument.SponsorshipPage1
            });
            objdocument.DocumentList.Add(new DocumentModel
            {
                DocumentID = -1,
                DocumentList = nationDoc,
                DocumentType = TypeDocument.NationCodePage1
            });
            objdocument.DocumentList.Add(new DocumentModel
            {
                DocumentID = -1,
                DocumentList = childDoc,
                DocumentType = TypeDocument.ChildPage1
            });
            return View(objdocument);
        }

        [HttpPost("upload-document")]
        public async Task<IActionResult> UploadDocument(IFormFileCollection fileinput, DocumentModel DocumentModel)
        {
            var auth = _authorizationMemoryCache.Get("SaveAuthorization");
            if (!(bool)auth.IsConfirmHumanResourceUnit)
            {


                var DocumentUpload = DocumentModel.DocumentList;

                var docFile = _documentMemory.Get("SaveDocFile");
                var lstdocumentFileDTO = new List<DocumentFileDTO>();

                foreach (var doc in DocumentUpload)
                {
                    string strFileUpload = "file_" + Convert.ToString(doc.DocumentID);
                    IFormFile file = Request.Form.Files[strFileUpload];

                    if (file != null && file.Length > 0)
                    {

                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName).ToLower();
                        if (file.IsImage())
                        {

                            if (docFile != null && docFile.Count > 0)
                            {
                                for (int j = 0; j < docFile.Count; j++)
                                {
                                    if (docFile[j].TypeDocument == doc.DocumentType)
                                    {
                                        var oldFilename = docFile[j].FileName;
                                        file.AddImageToServer(fileName, PathExtension.DocumentFileServerOrigin, null, null,
                                            null, null, null, null, null, oldFilename);
                                        docFile[j].FileName = fileName;
                                    }
                                }

                            }
                            else
                            {
                                file.AddImageToServer(fileName, PathExtension.DocumentFileServerOrigin);
                            }
                        }
                        else if (file.IsPdf())
                        {
                            if (docFile != null && docFile.Count > 0)
                            {
                                for (int j = 0; j < docFile.Count; j++)
                                {
                                    if (docFile[j].TypeDocument == doc.DocumentType)
                                    {
                                        var oldFilename = docFile[j].FileName;
                                        file.AddImageToServer(fileName, PathExtension.DocumentFileServerOrigin, null, null,
                                            null, null, null, null, null, oldFilename);
                                        docFile[j].FileName = fileName;
                                    }

                                }

                            }
                            else
                            {
                                file.AddImageToServer(fileName, PathExtension.DocumentFileServerOrigin);
                            }
                        }

                        if (docFile != null && docFile.Count == 0)//مدارک خود فرد در اولین مراجعخ گرفته می شه
                        {

                            var document = new DocumentFileDTO()
                            {
                                TypeDocument = doc.DocumentType,
                                FileName = fileName,
                                EmploymentId = (long)auth.EmploymentId
                            };
                            lstdocumentFileDTO.Add(document);


                        }

                    }


                    var sunDocumentUpload = doc.DocumentList;

                    if (sunDocumentUpload != null)
                    {

                        foreach (var subDoc in sunDocumentUpload)
                        {
                            string substrFileUpload = "file_" + Convert.ToString(subDoc.DocumentID);
                            IFormFile subfile = Request.Form.Files[substrFileUpload];

                            if (subfile != null && subfile.Length > 0)
                            {
                                var subfileName = Guid.NewGuid() + Path.GetExtension(subfile.FileName).ToLower();
                                if (subfile.IsImage())
                                {
                                    if (docFile.Any(d => d.TypeDocument == subDoc.DocumentType))
                                    {
                                        if (docFile != null && docFile.Count > 0)
                                        {
                                            for (int j = 0; j < docFile.Count; j++)
                                            {
                                                if (docFile[j].TypeDocument == subDoc.DocumentType)
                                                {
                                                    var oldFilename = docFile[j].FileName;
                                                    subfile.AddImageToServer(subfileName,
                                                        PathExtension.DocumentFileServerOrigin,
                                                        null, null, null, null, null, null, null, oldFilename);
                                                    docFile[j].FileName = subfileName;
                                                }
                                            }

                                        }
                                        else
                                        {
                                            subfile.AddImageToServer(subfileName, PathExtension.DocumentFileServerOrigin);
                                        }
                                    }
                                    else
                                    {
                                        subfile.AddImageToServer(subfileName, PathExtension.DocumentFileServerOrigin);
                                    }
                                }

                                else if (subfile.IsPdf())
                                {
                                    if (docFile != null && docFile.Count > 0)
                                    {
                                        for (int j = 0; j < docFile.Count; j++)
                                        {
                                            if (docFile[j].TypeDocument == doc.DocumentType)
                                            {
                                                var oldFilename = docFile[j].FileName;
                                                subfile.AddFileToServer(subfileName, PathExtension.DocumentFileServerOrigin,
                                                    oldFilename);
                                                docFile[j].FileName = subfileName;

                                            }
                                        }

                                    }
                                    else
                                    {
                                        subfile.AddFileToServer(subfileName, PathExtension.DocumentFileServerOrigin);
                                    }
                                }

                                if ((docFile != null && docFile.Count == 0) || !docFile.Any(d => d.TypeDocument == subDoc.DocumentType))
                                {

                                    var document = new DocumentFileDTO()
                                    {
                                        TypeDocument = subDoc.DocumentType,
                                        FileName = subfileName,
                                        EmploymentId = (long)auth.EmploymentId

                                    };
                                    lstdocumentFileDTO.Add(document);
                                }
                            }



                        }
                    }

                }

                TempData[SuccessMessage] = "بارگذاری مدارک با موفقیت انجام شد.";

                if (docFile != null && docFile?.Count() > 0 && lstdocumentFileDTO.Count == 0)//همون قبلی هاست و تغییر جدید نداشته
                {
                    var result = await _uploadDocumentService.UploadDocument(docFile);
                    if (result)
                    {
                        await _employmentService.UpdateUploadedDocument((long)auth.EmploymentId);
                        TempData[SuccessMessage] = "بارگذاری مدارک با موفقیت انجام شد.";
                    }

                    else
                        TempData[ErrorMessage] = "بارگزاری مدارک با مشکل مواجه شد\rدوباره اقدام کنید";
                }
                else if (lstdocumentFileDTO.Count > 0)//تغییرات داشته
                {
                    foreach (var item in docFile)
                    {
                        if (!lstdocumentFileDTO.Any(d => d.TypeDocument == item.TypeDocument))
                            lstdocumentFileDTO.Add(item);
                    }

                    var result = await _uploadDocumentService.UploadDocument(lstdocumentFileDTO);
                    if (result)
                    {
                        await _employmentService.UpdateUploadedDocument((long)auth.EmploymentId);
                        TempData[SuccessMessage] = "بارگذاری مدارک با موفقیت انجام شد.";
                    }

                    else
                        TempData[ErrorMessage] = "بارگزاری مدارک با مشکل مواجه شد\rدوباره اقدام کنید";
                }

            }
            return RedirectToAction("EndStepForUploadDocument");
        }

        public async Task<IActionResult> EndStepForUploadDocument()
        {
            EmploymentDTO model = new EmploymentDTO();
            model.Authentication = _authenticationMemory.Get("SaveAuth");
            model.Authorization = _authorizationMemoryCache.Get("SaveAuthorization");
            return View(model);
        }
        #endregion
        #region GetpersonalImage
        private void GetPersonalImage(string? personalImage)
        {
            var PersonalImage = new PersonalImageNameMem
            {
                PersonalImageName = personalImage
            };
            _personalImageMemory.Set("SavePersonalImage", PersonalImage);
        }
        #endregion
        #region Getspecification
        public async Task GetSpecificationAsync(Employment result)
        {
            var specifications = new SpecificationsDTO();
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            specifications.CascadingDto = cascadingDto;
            specifications.Name = result.Name;
            specifications.Family = result.Family;
            specifications.FatherName = result.FatherName;
            specifications.JobFather = result.JobFather;
            specifications.Gender = (Gender)result.Gender;
            specifications.BirthCertificateId = result.BirthCertificateId;
            specifications.SerialBirthCertificateSection1 = result.SerialBirthCertificateSection1;
            specifications.SerialBirthCertificateSection2 = result.SerialBirthCertificateSection2;
            specifications.SerialBirthCertificateSection3 = result.SerialBirthCertificateSection3;
            specifications.Religion = (Religion)result.Religion;
            specifications.Sect = (Sect)result.Sect;
            specifications.ProvinceId = result.ProvinceId;
            specifications.CityId = result.CityId;
            specifications.ProvinceOfIssueId = result.ProvinceOfIssueId;
            specifications.CityOfIssueCityId = result.CityOfIssueCityId;
            specifications.BrithDate = result.BrithDate?.ToShamsiDate();
            specifications.MaritalStatus = (MaritalStatus)(result.MaritalStatus ?? 0);
            specifications.ResidenceCityId = result.ResidenceCityId;
            specifications.ChildrenCount = result.ChildrenCount;
            specifications.MilitaryServiceStatus = result.MilitaryServiceStatus != null ? (MilitaryServiceStatus)result.MilitaryServiceStatus : MilitaryServiceStatus.TheEndOfService;
            specifications.PlaceOfServiceOrgan = result.PlaceOfServiceOrgan;
            specifications.ExemptionCode = result.ExemptionCode;
            specifications.ExemptionReason = result.ExemptionReason;
            specifications.MilitaryStartDate = result.MilitaryStartDate?.ToShamsiDate();
            specifications.CardReceiptDate = result.CardReceiptDate?.ToShamsiDate();
            specifications.Height = result.Height;
            specifications.Weight = result.Weight;
            specifications.UseOfGlasses = result.UseOfGlasses != null && (bool)result.UseOfGlasses;
            specifications.TotalNumberOfEyes = result.TotalNumberOfEyes;
            specifications.PhysicalCondition = result.PhysicalCondition != null ? (PhysicalCondition)result.PhysicalCondition : PhysicalCondition.Healthy;
            specifications.DescriptionOfPhysicalCondition = result.DescriptionOfPhysicalCondition;
            specifications.InsuranceHistoryMonth = result.InsuranceHistoryMonth.ToString();
            specifications.InsuranceHistoryYear = result.InsuranceHistoryYear.ToString();
            specifications.HasEmploymentHistory = (result.HasEmploymentHistory != null && (bool)result.HasEmploymentHistory) ? YesORNo.Yes : YesORNo.No;
            specifications.PlaceOfWork = result.PlaceOfWork;
            specifications.PersonalCode = result.PersonalCode;
            specifications.DrivingLicences = result.DrivingLicences?.Split(',').Select(Int32.Parse).ToList();
            specifications.EmploymentStatus = result.EmploymentStatus != null ? (EmploymentStatus)result.EmploymentStatus : EmploymentStatus.WorkingFullTime;
            specifications.ProposedSalary = (result.ProposedSalary != null) ? ((long)result.ProposedSalary).ToRial() : "";
            specifications.ResidenceProvinceId = result.ResidenceProvinceId;
            specifications.ResidenceCityId = result.ResidenceCityId;
            specifications.ResidencePostalCode = result.ResidencePostalCode;
            specifications.Address = result.Address;
            specifications.ResidencePeriodByMonth = result.ResidencePeriodByMonth;
            specifications.ResidencePeriodByYear = result.ResidencePeriodByYear;
            specifications.ResidencePhone = result.ResidencePhone;
            if (specifications.MaritalStatus == MaritalStatus.Married)
            {
                var lst = new List<SpouseDTO>();
                foreach (var item in result.Sponsorships)
                {
                    lst.Add(new SpouseDTO()
                    {
                        SpouseJob = item.SpouseJob,
                        SpouseMobile = item.SpouseMobile,
                        EmploymentId = result.Id
                    });
                }

                specifications.Spouse = lst;
            }

            specifications.SpouseCount = result.SpouseCount ?? 0;
            _specificationMemory.Set("SaveSpecification", specifications);

        }
        #endregion
        #region Geteducation
        public async Task GetEducation(List<EducationalRecode>? result)
        {
            var educationallist = new List<EducationalRecords>();
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            foreach (var item in result)
            {
                EducationalRecords educational = new EducationalRecords();
                educational.Id = item.Id;
                educational.CentralEducation = item.CentralEducation;
                educational.FieldOfStudy = item.FieldOfStudy;
                educational.IsEndOfDegreeOfEducation= item.IsEndOfDegreeOfEducation;
                educational.YearOfStartingEducation = (int)item.YearOfStartingEducation;
                educational.YearOfEndingEducation = (int)item.YearOfEndingEducation;
                educational.Avg = (decimal)item.Avg;
                educational.CityOfPlaceOfStudyId = item.CityOfPlaceOfStudyId;
                educational.ProvinceOfPlaceOfStudyId = item.ProvinceOfPlaceOfStudyId;
                educational.DegreeOfEducation = (DegreeOfEducation)item.DegreeOfEducation;
                cascadingDto.Cities = await _cityService.GetCityByProvinceId((long)item.ProvinceOfPlaceOfStudyId);
                educational.ProvinceOfPlaceOfStudy = cascadingDto.States
                    .Find(s => s.Value == item.ProvinceOfPlaceOfStudyId.Value.ToString()).Text;
                educational.CityOfPlaceOfStudy = cascadingDto.Cities
                    .Find(s => s.Value == item.CityOfPlaceOfStudyId.Value.ToString()).Text;
                educationallist.Add(educational);
            }
            _educationalRecordMemory.Set("SaveEdu", educationallist);

        }

        #endregion
        #region GetWork
        public async Task GetWork(List<WorkExperience>? result)
        {
            var workExperienceslist = new List<WorkExperienceRecords>();
            var cascadingDto = new CascadingDTO
            {
                States = await _cityService.GetAllProvince()
            };
            cascadingDto.Cities = await _cityService.GetCityByProvinceId(long.Parse(cascadingDto.States.First().Value.ToString()));
            foreach (var item in result)
            {
                WorkExperienceRecords work = new WorkExperienceRecords();
                work.Id = item.Id;
                work.YearOfEndingJob = (int)item.YearOfEndingJob;
                work.CityOfJobId = item.CityOfJobId;
                work.CompanyName = item.CompanyName;
                work.JobTitle = item.JobTitle;
                work.ProvinceOfJobId = item.ProvinceOfJobId;
                work.ProvinceOfJob = cascadingDto.States
                    .Find(s => s.Value == item.ProvinceOfJobId.Value.ToString()).Text;
                cascadingDto.Cities = await _cityService.GetCityByProvinceId((long)item.ProvinceOfJobId);
                work.CityOfPlaceOfJob = cascadingDto.Cities
                    .Find(s => s.Value == item.CityOfJobId.Value.ToString()).Text;
                work.ReasonForLeavingWork = item.ReasonForLeavingWork;
                work.YearOfStartingJob = (int)item.YearOfStartingJob;
                workExperienceslist.Add(work);
            }
            _workExperienceMemory.Set("SaveWork", workExperienceslist);

        }
        #endregion
        #region GetAcquaintance
        public async Task GetAcquaintance(Employment result)
        {
            var acquaintancesDto = new AcquaintancesDTO
            {
                FirstFamiliarFullName = result.FirstFamiliarFullName,
                FirstFamiliarMobile = result.FirstFamiliarMobile,
                FirstFamiliarJob = result.FirstFamiliarJob,
                SecondFamiliarFullName = result.SecondFamiliarFullName,
                SecondFamiliarMobile = result.SecondFamiliarMobile,
                SecondFamiliarJob = result.SecondFamiliarJob,
                RepresentativeFullName = result.RepresentativeFullName,
                RepresentativeJob = result.RepresentativeJob,
                RepresentativeMobile = result.RepresentativeMobile,
                AccessiblePersonFullName = result.AccessiblePersonFullName,
                AccessiblePersonMobile = result.AccessiblePersonMobile,
                AccessiblePersonJob = result.AccessiblePersonJob
            };
            _acquaintancesMemory.Set("SaveAcquaintance", acquaintancesDto);

        }

        #endregion(int)result.TrackingCode
        #region Getability
        public async Task GetAbility(Employment result)
        {
            var abilities = new AbilitiesDTOMem
            {
                ResumeFile = result.ResumeFile,
                AbilityTitle = result.AbilityTitle,
                AbilityToTravelAsAMission = result.AbilityToTravelAsAMission != null && (bool)result.AbilityToTravelAsAMission,
                AbilityToWorkInClericalJobs = result.AbilityToWorkInClericalJobs != null && (bool)result.AbilityToWorkInClericalJobs,
                AbilityToWorkInShifts = result.AbilityToWorkInShifts != null && (bool)result.AbilityToWorkInShifts,
                DescriptionOfAccident = result.DescriptionOfAccident,
                Entertainments = result.Entertainments,
                HavingAnAccident = result.HavingAnAccident != null && (bool)result.HavingAnAccident,
                Ideas = result.Ideas
            };
            _abilitiesMemory.Set("SaveAbility", abilities);
        }
        #endregion
        #region GetEndStep
        public async Task GetEndStep(Employment result)
        {
            var endstep = new EndStepDTO()
            {
                TrackingCode = result.TrackingCode ?? 0,
                SatisfactionRules = result.SatisfactionRules,
                EmploymentId = result.Id
            };
            _endStepMemory.Set("SaveEndStep", endstep);
        }
        #endregion
        #region GeSupplementary
        public async Task GeSupplementary(Employment result)
        {
            var SupplementaryInfo = new FurtherInformationDTO()
            {
                TejaratBankNumber = result.TejaratBankNumber,
                TejaratSheba = result.TejaratSheba,
                DateOfMarriage = result.DateOfMarriage?.ToShamsiDate(),
                InsuranceNumber = result.InsuranceNumber,

            };
            _supplementaryInfoMemory.Set("SaveSupplementaryInfo", SupplementaryInfo);
        }
        #endregion
        #region GetDocument
        public async Task GetDocument(List<RegistrationDocuments>? result)
        {
            var documentFile = new List<DocumentFileDTO>();

            foreach (var item in result)
            {
                DocumentFileDTO doc = new DocumentFileDTO()
                {
                    FileName = item.FileName,
                    TypeDocument = (TypeDocument)item.TypeDocument,
                    EmploymentId = item.EmploymentId
                };

                documentFile.Add(doc);
            }
            _documentMemory.Set("SaveDocFile", documentFile);

        }
        #endregion
        #region GetSponsership
        public async Task GetSponsership(List<SpouseDTO>? result)
        {
            var lstspon = new List<SpouseDTO>();
            lstspon = result.Select(a => new SpouseDTO()
            {
                SpouseJob = a.SpouseJob,
                SpouseMobile = a.SpouseMobile,
                Name = a.Name,
                Family = a.Family,
                NationCode = a.NationCode,
                Gender = a.Gender,
                MaritalStatus = a.MaritalStatus,
                BasicInsurance = a.BasicInsurance,
                BirthCertificateId = a.BirthCertificateId,
                BrithDate = a.BrithDate,
                FatherName = a.FatherName,
                IsCovered = (bool)a.IsCovered,
                ProvinceId = a.ProvinceId,
                ProvinceOfIssueId = a.ProvinceOfIssueId,
                Relation = a.Relation,
                SerialInsurance = a.SerialInsurance,
                EmploymentId = a.EmploymentId,


            }).ToList();
            _sponserShipMemoryCache.Set("SaveSponsershipInfo", lstspon);

        }
        #endregion
        [HttpPost("/Home/GetCity/{Id}")]
        public async Task<JsonResult> GetCity(long Id)
        {
            CascadingDTO model = new CascadingDTO();
            model.Cities = await _cityService.GetCityByProvinceId(Id);
            return Json(model);

        }

        [HttpPost("/Home/GetSect")]
        public async Task<JsonResult> GetSect()
        {
            var lstSect = Enum.GetValues(typeof(Sect)).Cast<Sect>().Select(v => new SelectListItem
            {
                Text = v.GetEnumName().ToString(),
                Value = ((int)v).ToString()
            }).ToList();
            return Json(lstSect);

        }



        public class JsonResultValue
        {
            public bool IsValid { get; set; }
            public string Url { get; set; }
        }

    }
}
