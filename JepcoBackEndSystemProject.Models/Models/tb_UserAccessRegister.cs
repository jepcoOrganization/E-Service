using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class tb_UserAccessRegister
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string FullName { get; set; }

        public DateTime LoginDateTime { get; set; }

        public DateTime? LogoutDateTime { get; set; }

        public int BranchId { get; set; }

        [StringLength(50)]
        public string LoginLatt { get; set; }

        [StringLength(50)]
        public string LoginLong { get; set; }

        [StringLength(50)]
        public string LogOutLatt { get; set; }

        [StringLength(50)]
        public string LogOutLong { get; set; }
    }
}

