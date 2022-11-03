using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_FazPowerCapacity
    //{
    //}
    public partial class tb_FazPowerCapacity
    {
        [Key]
        [Required]
        public long ID { get; set; }
        [Required]
        public int PowerCapacity { get; set; }
    }
}
