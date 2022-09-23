using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class tb_ElectricalFaultStatus
    {

        [Key]
        public int FaultStatusID { get; set; }

        [Required]
        [StringLength(30)]
        public string FaultStatusNameAR { get; set; }

        [Required]
        [StringLength(30)]
        public string FaultStatusNameEN { get; set; }

    }
}
