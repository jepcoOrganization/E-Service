using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class tb_EngineersAccessRegister
    {
        [Key]
        public long ID { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime LoginDateTime { get; set; }
        [Required]
        public DateTime? LogoutDateTime { get; set; }

    }
}
