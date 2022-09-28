using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.GeneralTechnicianInf
{
    public class TechnicianLoginHistoryRequestDto
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public string LanguageId { get; set; }

        [Required]
        public string HistoryDateStart { get; set; }

        public string HistoryDateEnd { get; set; }
    }
}
