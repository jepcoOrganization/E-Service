using System;
namespace JepcoBackEndSystemProject.Services.DataTransferObject.SmsVerification
{
    public class SmsVerificationReturnDto
    {
        
        
        //public string Smscode { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? UsedDate { get; set; }
        public long Smsstatus { get; set; }
        public int Smstry { get; set; }
    }

    public class ValidatePhoneDto
    {
        public string FormattedNumber { get; set; }
        public bool IsMobile { get; set; }
        public bool IsValidNumber { get; set; }
        public bool IsValidNumberForRegion { get; set; }
        public string Region { get; set; }
    }
}
