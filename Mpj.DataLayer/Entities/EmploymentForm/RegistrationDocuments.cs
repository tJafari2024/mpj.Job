using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpj.DataLayer.Entities.Common;
using Mpj.DataLayer.Entities.ProvinceAndCity;
using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.Entities.EmploymentForm
{
    public class RegistrationDocuments:BaseEntity
    {
        #region Property
        public byte? TypeDocument { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }

        #endregion
        #region Relation
        public Employment Employment { get; set; }
        public long EmploymentId { get; set; }
        #endregion
    }
}
