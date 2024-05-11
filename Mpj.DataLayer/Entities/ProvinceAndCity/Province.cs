using Mpj.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mpj.DataLayer.Entities.ProvinceAndCity
{
    public class Province:BaseEntity
    {
        [StringLength(450)]
        [DisplayName("نام استان")]
        public string? ProvinceName { get; set; }
    }
}
