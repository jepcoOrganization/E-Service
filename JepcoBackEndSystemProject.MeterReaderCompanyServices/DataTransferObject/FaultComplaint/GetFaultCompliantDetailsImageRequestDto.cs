namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint
{
    public class GetFaultCompliantDetailsImageRequestDto
    {
        public string LanguageId { get; set; }
        public int FaultComplaintID { get; set; }

        public int Image { get; set; }
    }
}
