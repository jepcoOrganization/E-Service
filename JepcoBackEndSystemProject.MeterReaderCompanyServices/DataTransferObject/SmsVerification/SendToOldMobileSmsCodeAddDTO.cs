using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.SmsVerification
{
    public class SendToOldMobileSmsCodeAddDTO
    {
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public string OldMobileNumber { get; set; }
        [Required]
        public string NewMobileNumber { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }
}
