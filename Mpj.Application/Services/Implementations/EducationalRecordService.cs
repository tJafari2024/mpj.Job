using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Repository;

namespace Mpj.Application.Services.Implementations
{
    public class EducationalRecordService : IEducationalRecordService
    {
        #region Constructor

        private readonly IGenericRepository<EducationalRecode> _repository;
        private readonly IEditedItemsForEmploymentService _editedItems;

        public EducationalRecordService(IGenericRepository<EducationalRecode> repository, IEditedItemsForEmploymentService editItemRepository)
        {
            _repository = repository;
            _editedItems = editItemRepository;
        }

        #endregion

        public async Task<List<EducationalRecode>> GetEducationRecode(long employmentId)
        {
            List<EducationalRecode> educationalRecodes = await _repository.GetQuery().AsQueryable()
                .Where(e => e.EmploymentId == employmentId).ToListAsync();
            return educationalRecodes;
        }
        public async Task<List<EducationalRecode>> GetEducationRecodeIgnoreFilter(long employmentId)
        {
            List<EducationalRecode> educationalRecodes = await _repository.GetQuery().AsQueryable()
                .Where(e => e.EmploymentId == employmentId).IgnoreQueryFilters().ToListAsync();
            return educationalRecodes;
        }
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
        }

        public async Task<EducationResult> AddEducation(List<EducationalRecode> lst, long id)
        {
            try
            {
               
                //حذف رکوردهای قبل
                var listEdu = await GetEducationRecode(id);

                foreach (var item in listEdu)
                {
                    bool finditem = false;
                    foreach (var eduitem in lst)
                    {
                        if (eduitem.DegreeOfEducation == item.DegreeOfEducation && eduitem.IsDelete == true)
                            finditem = true;
                    }

                    if (finditem)
                    {
                        if (!await _editedItems.CheckExist(FieldName.DegreeOfEducation, ((byte)item.DegreeOfEducation).ToString(), id))
                            await _editedItems.InsertItemForEmployment(FieldName.DegreeOfEducation, ((byte)item.DegreeOfEducation).ToString(),
                                id);
                    }
                    item.IsDelete = true;
                    _repository.EditEntity(item);
                    await _repository.SaveChanges();
                }
                //حذف رکودهای حذف شده جاری که در دیتابیس نرفته اند
                var edu = lst.Where(b => b.IsDelete == true);
                foreach (var item in edu.ToList())
                {
                    lst.Remove(item);

                }
                await _repository.AddRangeEntities(lst);

                return EducationResult.Success;
            }
            catch (Exception e)
            {
                return EducationResult.Error;
            }

        }
    }
}
