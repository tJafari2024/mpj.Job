using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class DocumentModel
    {
        public long DocumentID { get; set; }
        public string DocumentName { get; set; }
        public string? DocumentFileName { get; set; }
        public TypeDocument DocumentType { get; set; }
        public int Mandatory { get; set; }
        public List<DocumentModel> DocumentList { get; set; }
    }
}