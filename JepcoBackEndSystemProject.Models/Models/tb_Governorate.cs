using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_Governorate
    //{
    //}
    public partial class tb_Governorate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string GovernorateName { get; set; }

        public DateTime Update_DATE { get; set; }

        public DateTime CREATION_DATE { get; set; }



    }
}
