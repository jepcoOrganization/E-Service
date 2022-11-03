using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_MaintenanceRequestType
    //{
    //}
    public partial class tb_MaintenanceRequestType
    {
        [Key]
        [Required]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }
    }
}
