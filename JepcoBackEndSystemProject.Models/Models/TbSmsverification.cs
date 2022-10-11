using System;
using System.Collections.Generic;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class TbSmsverification
    {
        public long Id { get; set; }
        public string Smscode { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? UsedDate { get; set; }
        public long Smsstatus { get; set; }
        public int SMSTry { get; set; }
        public string EmployeeNumber { get; set; }

        public virtual TbSmsstatusLookup SmsstatusNavigation { get; set; }
    }
}
