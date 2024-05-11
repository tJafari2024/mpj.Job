using Mpj.DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class LowDTO
    {
        [CheckBoxRequired(ErrorMessage = " این فیلد الزامی است")]
        public bool AcceptLow { get; set; }
    }
}
