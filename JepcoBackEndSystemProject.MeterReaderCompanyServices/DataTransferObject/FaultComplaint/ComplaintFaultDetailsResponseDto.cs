using System;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint
{
    public class ComplaintFaultDetailsResponseDto
    {

        
        public long FaultDetailsId { get; set; }

        public long FaultComplaintID { get; set; }

        public DateTime? DeliveredDateTime { get; set; }


        public DateTime? ArrivingLocationDateTime { get; set; }

       
        public string ArrivingLocationLatt { get; set; }

     
        public string ArrivingLocationLong { get; set; }

        public int? FaultClassficationID { get; set; }


        public string FaultClassficationName { get; set; }

        public int? FaultSubClassficationID { get; set; }


        public string FaultSubClassficationName { get; set; }

  
        public string UpdateSubstationID { get; set; }


        public string UpdateSubstationName { get; set; }

      
        public string UpdatedSubstationLatt { get; set; }

 
        public string UpdatedSubstationLong { get; set; }


        public string UpdatedLV_Feeder { get; set; }

        public DateTime? RepairingClosingDatetime { get; set; }

        public int? RepairingStatusID { get; set; }

        public string TechnicationNote { get; set; }
        public string FaultReason { get; set; }
        public string FaultDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string ReassignReason { get; set; }

        public int? ReassignClassficationID { get; set; }

        public string ReassignClassficationName { get; set; }

        public DateTime? ReassignDate { get; set; }

        public string LV_Feeder_Color { get; set; }

    }
}
