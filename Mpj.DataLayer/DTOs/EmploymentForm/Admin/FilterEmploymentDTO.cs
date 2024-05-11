using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Mpj.DataLayer.DTOs.Paging;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;


namespace Mpj.DataLayer.DTOs.EmploymentForm.Admin
{

    public class FilterEmploymentDTO : BasePaging
    {
        #region properties

        public List<Employment> EmploymentInfos { get; set; }
        public string TrackingCode { get; set; }
        public string NationCode { get; set; }
        
        public string CreateDate { get; set; }
       
        public string BrithDate { get; set; }
        public DegreeOfEducation? DegreeOfEducations { get; set; }
        public DrivingLicences? DrivingLicences { get; set; }

        #endregion
        #region methods

        public FilterEmploymentDTO SetEmploymentInfos(List<Employment> infos)
        {
            EmploymentInfos = infos;
            return this;
        }

        public FilterEmploymentDTO SetPaging(BasePaging paging)
        {
            PageId = paging.PageId;
            AllEntitiesCount = paging.AllEntitiesCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;
            PageCount = paging.PageCount;
            return this;
        }

        #endregion
    }
}
