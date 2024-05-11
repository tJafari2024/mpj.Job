using Mpj.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Mpj.DataLayer.Entities.Site
{
    public class Info : BaseEntity
    {
        #region properties
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? Title { get; set; }
        [AllowHtml]
        public string? Description { get; set; }
        public bool ShowTitle { get; set; }
        public bool IsShow { get; set; }



        #endregion

        #region Relation
        [ForeignKey("Value")]
        [Required]
        public long InfoTypeId { get; set; }
        public PublicInfo? InfoType { get; set; }

        #endregion


    }
}
