using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class tb_RepairingStatus
    {
        [Key]
        public int RepairingStatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string RepairingStatusNameAR { get; set; }

        [Required]
        [StringLength(50)]
        public string RepairingStatusNameEN { get; set; }

        public virtual ICollection<tb_FaultDetails> tb_FaultDetails { get; set; }
    }
}
