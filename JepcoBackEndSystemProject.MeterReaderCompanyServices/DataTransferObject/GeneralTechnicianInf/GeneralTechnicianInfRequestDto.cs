using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.GeneralTechnicianInf
{
    public class GeneralTechnicianInfRequestDto
    {
        [Required]
        public string ComplaintDateStart { get; set; }
        public string ComplaintDateEnd { get; set; }
        public string ComplaintTimeStart { get; set; }
        public string ComplaintTimeEnd { get; set; }
        public string TechnicianName { get; set; }
        public string FaultStatus { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }
}
