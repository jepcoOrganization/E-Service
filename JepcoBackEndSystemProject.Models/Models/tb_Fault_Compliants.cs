using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class tb_Fault_Compliants
    {
        [Key]
        public long FaultComplaintID { get; set; }

        [Required]
        [StringLength(30)]
        public string ComplaintRefNumber { get; set; }

        [StringLength(30)]
        public string CompliantParentRefNumber { get; set; }

        public DateTime CompliantDateTime { get; set; }

        [Required]
        [StringLength(200)]
        public string CompliantCustomerName { get; set; }

        [Required]
        [StringLength(15)]
        public string CompliantPhoneNumber { get; set; }

        [StringLength(255)]
        public string ComplaintDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string GovernateName { get; set; }

        public int GovernateId { get; set; }

        public int DistrictID { get; set; }

        [Required]
        [StringLength(50)]
        public string DistrictName { get; set; }

        public int? ZoneID { get; set; }

        [StringLength(200)]
        public string ZoneName { get; set; }

        public int? StreetID { get; set; }

        [StringLength(200)]
        public string StreetName { get; set; }

        [StringLength(50)]
        public string CustomerAddress_Latt { get; set; }

        [StringLength(50)]
        public string CustomerAddress_Long { get; set; }

        [StringLength(200)]
        public string MainStationName { get; set; }

        [StringLength(50)]
        public string SubstationNumber { get; set; }

        [StringLength(200)]
        public string SubstationName { get; set; }

        [StringLength(50)]
        public string LV_Feeder { get; set; }

        [StringLength(50)]
        public string MV_Feeder { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        public int FaultStatusID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public virtual tb_ElectricalFaultStatus tb_ElectricalFaultStatus { get; set; }

        public virtual ICollection<tb_FaultDetails> tb_FaultDetails { get; set; }
    }
}
