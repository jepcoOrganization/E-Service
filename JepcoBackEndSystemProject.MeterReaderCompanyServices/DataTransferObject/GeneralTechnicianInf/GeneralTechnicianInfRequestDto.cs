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
        public string EmployeeNumber { get; set; }
        public string PiorityID { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }
}
