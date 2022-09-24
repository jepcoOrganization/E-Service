namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultClassfication
{


    public class FaultClassficationRequestDto
    {
        public string LanguageId { get; set; }

    }

    public class FaultSubClassficationRequestDto
    {
        public string LanguageId { get; set; }
        public int FaultClassficationID { get; set; }

    }


    public class FaultClassficationResponsetDto
    {
        public int FaultClassficationID { get; set; }
        public string FaultClassficationName { get; set; }

    }


    public class FaultSubClassficationResponsetDto
    {
        public int FaultClassficationID { get; set; }
        public int FaultSubClassficationID { get; set; }
        public string FaultSubClassficationName { get; set; }

    }

}
