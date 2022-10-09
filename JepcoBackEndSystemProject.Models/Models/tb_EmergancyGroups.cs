using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_EmergancyGroups
    //{
    //}
    public partial class tb_EmergancyGroups
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        public long GovernorateId { get; set; }

        public bool Group_Active { get; set; }

        public DateTime CREATION_DATE { get; set; }

        public DateTime Update_DATE { get; set; }


    }
}
