using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.ChangeTechnicalGroup
{
    public class GetTechnicianForGroupRequestDto
    {
        [Required]
        public string LanguageId { get; set; }
        [Required]
        public long GroupID { get; set; }
    }
}
