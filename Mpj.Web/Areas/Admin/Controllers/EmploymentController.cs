using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mpj.Application.Services.Interfaces.Admin;
using Mpj.Application.Utils;
using Mpj.DataLayer.DTOs.EmploymentForm.Admin;
using Newtonsoft.Json.Linq;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace Mpj.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/employment")]
    public class EmploymentController : Controller
    {
        #region constructor
        private readonly IAdminEmploymentService _employmentService;


        public EmploymentController(IAdminEmploymentService employmentService)
        {
            _employmentService = employmentService;
        }
        #endregion
        #region list

        [HttpGet("employments")]
        public async Task<IActionResult> Employments(AdminEmploymentDTO model)
        {
            try
            {
                model.filterEmployment ??= new FilterEmploymentDTO();
                if (DateTime.TryParse(model.filterEmployment.BrithDate, out DateTime Temp) == true)
                {
                    if (model.filterEmployment.BrithDate?.Length < 10)
                    {
                        string year = model.filterEmployment.BrithDate.Split('/')[0];
                        string month = model.filterEmployment.BrithDate.Split('/')[1];
                        string day = model.filterEmployment.BrithDate.Split('/')[2];

                        if (month.Length < 2)
                            month = "0" + month;
                        if (day.Length < 2)
                            day = "0" + day;
                        model.filterEmployment.BrithDate = year + "/" + month + "/" + day;
                    }
                }
                if (DateTime.TryParse(model.filterEmployment.CreateDate, out DateTime Tempcreate) == true)
                {
                    if (model.filterEmployment.CreateDate?.Length < 10)
                    {
                        string year = model.filterEmployment.CreateDate.Split('/')[0];
                        string month = model.filterEmployment.CreateDate.Split('/')[1];
                        string day = model.filterEmployment.CreateDate.Split('/')[2];

                        if (month.Length < 2)
                            month = "0" + month;
                        if (day.Length < 2)
                            day = "0" + day;
                        model.filterEmployment.CreateDate = year + "/" + month + "/" + day;
                    }
                }

                var info = new AdminEmploymentDTO()
                {
                    filterEmployment = await _employmentService.FilterEmploymentInfo(model.filterEmployment)
                };
                if (TempData["id"] != null && info.filterEmployment.AllEntitiesCount>0)
                {
                   
                    info.Employment =
                        info.filterEmployment.EmploymentInfos.FirstOrDefault(e =>
                            e.Id == long.Parse(TempData["id"].ToString()));
                    TempData.Remove("id");
                }

                return View(info);

            }
            catch (Exception e)
            {
                TempData.Remove("id");
                return View(new AdminEmploymentDTO());
            }
            
        }


        #endregion

        #region ShowEducation
        [HttpGet("show-edu")]
        public async Task<IActionResult> ShowEdu(long id)
        {
            TempData["id"] = id.ToString();
            return RedirectToAction("Employments");
        }
        #endregion
        #region ShowWork
        [HttpGet("show-wrk")]
        public async Task<IActionResult> ShowWork(long id)
        {
            TempData["id"] = id.ToString();
            return RedirectToAction("Employments");
        }
        #endregion

        #region InsertDes
        [HttpPost("insert-des"),ValidateAntiForgeryToken]
        public async Task<IActionResult> InsertDescription(AdminEmploymentDTO model)
        {
            await _employmentService.UpdateDescription(model.Description,long.Parse(model.id));
            return RedirectToAction("Employments");
        }
        #endregion

        [HttpGet("print")]
        public async Task<IActionResult>  PrintAllReport()
        {
            

            return new ViewAsPdf("PdfReport");

        }
        public async Task<IActionResult> PrintReport(long id)
        {
            var employment = await _employmentService.GetEmploymentById(id);
            var report = new ViewAsPdf("_CreatePdf", employment);
            return report;
             //return View("_CreatePdf", employment);
        }
    }
}
