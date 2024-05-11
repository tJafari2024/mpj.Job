using Microsoft.EntityFrameworkCore;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Repository;

namespace Mpj.Application.Services.Implementations
{
    public class WorkExperienceService : IWorkExperienceService
    {
        #region Constructor

        private readonly IGenericRepository<WorkExperience> _repository;

        public WorkExperienceService(IGenericRepository<WorkExperience> workRepository)
        {
            _repository = workRepository;
        }

        #endregion
        public async Task<long> AddWork(WorkExperienceDTO work)
        {
            var newWork = new WorkExperience()
            {
                JobTitle = work.JobTitle,
                CompanyName = work.CompanyName,
                CityOfJobId = work.CityOfJobId,
                ProvinceOfJobId = work.ProvinceOfJobId,
                ReasonForLeavingWork = work.ReasonForLeavingWork,
                YearOfStartingJob = work.YearOfStartingJob,
                YearOfEndingJob = work.YearOfEndingJob

            };
            await _repository.AddEntity(newWork);
            await _repository.SaveChanges();
            return newWork.Id;
        }
        public async Task<List<WorkExperience>> GetWorkExperience(long employmentId)
        {
            List<WorkExperience> workExperiences = await _repository.GetQuery().AsQueryable()
                .Where(e => e.EmploymentId == employmentId).ToListAsync();
            return workExperiences;
        }
        public async Task<WorkResult> AddWorkExperience(List<WorkExperience> lst, long id)
        {
            try
            { 
                //حذف رکوردهای قبل
                var listwrk = await GetWorkExperience(id);
                foreach (var item in listwrk)
                {
                    item.IsDelete = true;
                    _repository.EditEntity(item);
                    await _repository.SaveChanges();
                }
                //حذف رکودهای حذف شده جاری که در دیتابیس نرفته اند
                var wrk = lst.Where(b => b.IsDelete == true);
                foreach (var item in wrk.ToList())
                {
                    lst.Remove(item);

                }
                await _repository.AddRangeEntities(lst);
                return WorkResult.Success;
            }
            catch (Exception e)
            {
                return WorkResult.Error;
            }

        }
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
        }
    }
}
