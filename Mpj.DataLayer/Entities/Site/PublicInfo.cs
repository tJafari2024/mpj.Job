
using Mpj.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Mpj.DataLayer.Entities.Site
{
    public class PublicInfo : BaseEntity
    {
        #region properies

        [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Name { get; set; }
        public int Value { get; set; }
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Value1 { get; set; }
        public string? Value2 { get; set; }

        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Keyword { get; set; }
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsActiveForAdmin { get; set; }

        #endregion

        #region Relation

        public ICollection<Info> Infos { get; set; }
        //public ICollection<Picture> Pictures { get; set; }
        //public ICollection<BankInfo> BankInfos { get; set; }
        //public ICollection<Payment> Payments { get; set; }
        //public ICollection<ImageSetting> ImageSettings { get; set; }

        #endregion
    }

}
