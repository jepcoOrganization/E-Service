using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
   
    public partial class tb_Technical
    {

        //[Key]
        public long ID { get; set; }

        //[Required]
        public int MenaTrackUserID { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeNumber { get; set; }

        //[Required]
        //[StringLength(50)]
        public string FullName { get; set; }

        //[Required]
        //[StringLength(50)]
        public bool SystemActive { get; set; }
    }
}