
using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class DocumentFileDTO
    {
        public long EmploymentId { get; set; }
        public string FileName { get; set; }
        public TypeDocument TypeDocument { get; set; }

    }
}
