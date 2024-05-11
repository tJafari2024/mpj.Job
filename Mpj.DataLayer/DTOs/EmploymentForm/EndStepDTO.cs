
using Mpj.DataLayer.Utils;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
  public  class  EndStepDTO
    {
        public string? SatisfactionRules { get; set; }
        [CheckBoxRequired(ErrorMessage = " این فیلد الزامی است")]
        public bool AcceptRule { get; set; }
        public int TrackingCode { get; set; }
        public long EmploymentId { get; set; }
    }
}
