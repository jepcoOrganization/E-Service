using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_District
    //{
    //}
  
    public partial class tb_District
    {
        [Key]
        [Required]
        public long ID { get; set; }
        [Required]
        public int Code { get; set; }

     

        [Required]
        public long GovernateId { get; set; }
        public string DistrictName { get; set; }
        [Required]
        public bool Active { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
