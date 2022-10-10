using System;
using System.Collections.Generic;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class TbSmsstatusLookup
    {
        public TbSmsstatusLookup()
        {
            TbSmsverification = new HashSet<TbSmsverification>();
        }

        public long StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<TbSmsverification> TbSmsverification { get; set; }
    }
}
