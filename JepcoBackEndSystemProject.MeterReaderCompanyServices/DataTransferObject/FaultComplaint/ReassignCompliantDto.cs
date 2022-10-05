namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint
{
  

   

    public class ReassignCompliantDto
    {
        public string LanguageId { get; set; }
        public int FaultComplaintID { get; set; }
        public string ReassignReason { get; set; }


        public int ReassignClassficationID { get; set; }

        public string ReassignClassficationName { get; set; }

        public string ReassigningImage { get; set; }



    }
}
