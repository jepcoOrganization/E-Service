using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.ChangeTechnicalGroup
{
    public class GetGroupForGovernorateRequestDto
    {

        [Required]
        public string LanguageId { get; set; }
        [Required]
        public long GovernorateeID { get; set; }

    }
}
