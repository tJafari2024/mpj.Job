
using Mpj.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mpj.DataLayer.Entities.ProvinceAndCity
{
    public class City:BaseEntity
    {
        [StringLength(450)]
        [DisplayName("نام شهر")]
        public string? CityName { get; set; }

        /// <summary>
        /// شناسه استان (کلید خارجی به جدول استان‌ها)
        /// </summary>
        [DisplayName("شناسه استان")]
        public long? ProvinceId { get; set; }
        public virtual Province Province { get; set; }

    }
}
