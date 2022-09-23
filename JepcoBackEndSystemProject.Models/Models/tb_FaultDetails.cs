using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class tb_FaultDetails
    {
        [Key]
        public long FaultDetailsId { get; set; }

        public long FaultComplaintID { get; set; }

        public DateTime? DeliveredDateTime { get; set; }

        public DateTime? ArrivingDateTime { get; set; }

        public DateTime? ArrivingLocationDateTime { get; set; }

        public string ArrivingLocationImage { get; set; }

        [StringLength(50)]
        public string ArrivingLocationLatt { get; set; }

        [StringLength(50)]
        public string ArrivingLocationLong { get; set; }

        public int? FaultClassficationID { get; set; }

        [StringLength(50)]
        public string FaultClassficationName { get; set; }

        public int? FaultSubClassficationID { get; set; }

        [StringLength(50)]
        public string FaultSubClassficationName { get; set; }

        [StringLength(50)]
        public string UpdateSubstationID { get; set; }

        [StringLength(50)]
        public string UpdateSubstationName { get; set; }

        [StringLength(50)]
        public string UpdatedSubstationLatt { get; set; }

        [StringLength(50)]
        public string UpdatedSubstationLong { get; set; }

        [StringLength(50)]
        public string UpdatedLV_Feeder { get; set; }

        public DateTime? RepairingClosingDatetime { get; set; }

        public int? RepairingStatusID { get; set; }

        public string RepairingImage1 { get; set; }

        public string RepairingImage2 { get; set; }

        public string RepairingImage3 { get; set; }

        public string TechnicationNote { get; set; }

       
    }
}
