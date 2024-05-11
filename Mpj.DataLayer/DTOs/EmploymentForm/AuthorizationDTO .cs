
using System.ComponentModel.DataAnnotations;
using Mpj.DataLayer.Enums;

namespace Mpj.DataLayer.DTOs.EmploymentForm
{
    public class AuthorizationDTO
    {
        public string? Key { get; set; }
        public bool? IsConfirm { get; set; }
        public byte Step { get; set; }
        public  EmploymentLoginResultenum? EmploymentLoginResult { get; set; }
        public long? EmploymentId { get; set; }
        public int? ChildrenCount { get; set; }
        public int? SponsorshipCount { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int TrackingCode { get; set; }
        public bool? IsUploadDoc { get; set; } = false;
        public bool? IsConfirmHumanResourceUnit { get; set; } = false;

    }
}
