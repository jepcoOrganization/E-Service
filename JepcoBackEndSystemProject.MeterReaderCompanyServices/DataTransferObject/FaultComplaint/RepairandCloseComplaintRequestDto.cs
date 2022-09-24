namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint
{
  

   

    public class RepairandCloseComplaintRequestDto
    {
        public string LanguageId { get; set; }
        public int FaultComplaintID { get; set; }
        public int? FaultClassficationID { get; set; }

        public string FaultClassficationName { get; set; }

        public int FaultSubClassficationID { get; set; }

        public string FaultSubClassficationName { get; set; }

        public string UpdateSubstationID { get; set; }

        public string UpdateSubstationName { get; set; }

        public string UpdatedSubstationLatt { get; set; }

        public string UpdatedSubstationLong { get; set; }

        public string UpdatedLV_Feeder { get; set; }


        public int? RepairingStatusID { get; set; }

        public string RepairingImage1 { get; set; }

        public string TechnicationNote { get; set; }
        public string FaultReason { get; set; }
        public string FaultDescription { get; set; }



    }
}
