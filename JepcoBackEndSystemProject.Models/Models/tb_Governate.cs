using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_Governate
    //{
    //}
    public partial class tb_Governate
    {
        [Key]
        [Required]
        public long ID { get; set; }
        [Required]
        public int Code { get; set; }

        [Required]
        [StringLength(50)]
        public string GovernateName { get; set; }
        [Required]
        public bool Active { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
