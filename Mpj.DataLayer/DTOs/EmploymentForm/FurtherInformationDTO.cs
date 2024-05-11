using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Utils;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class FurtherInformationDTO
    {

        [DisplayName("شماره بیمه تامین اجتماعی")]
        [StringLength(50)]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        public string? InsuranceNumber { get; set; }
        [DisplayName("شماره حساب بانک تجارت")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(50)]
        [RegularExpression("([0-9]+)", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        
        public string? TejaratBankNumber { get; set; }
        [DisplayName("شماره شبای بانک تجارت")]
        [Required(ErrorMessage = "این فیلد الزامی است")]
        [StringLength(50)]
        [RegularExpression("([iIrR]{2}[0-9]{24})", ErrorMessage = "مقدار وارد شده نامعتبر می باشد")]
        public string? TejaratSheba { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        
        [DisplayName("تاریخ ازدواج (بر اساس شناسنامه)")]
        [DataType(DataType.Date)]
        [RequiredIfCustom(nameof(MaritalStatus), MaritalStatus.Married,
            ErrorMessage = "این فیلد الزامی است")]
        public string? DateOfMarriage { get; set; }
    }
}
