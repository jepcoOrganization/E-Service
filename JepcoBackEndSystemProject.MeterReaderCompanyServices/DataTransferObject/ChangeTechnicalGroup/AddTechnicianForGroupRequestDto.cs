using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.ChangeTechnicalGroup
{
    public class AddTechnicianForGroupRequestDto
    {
        [Required]
        public string LanguageId { get; set; }

        [Required]
        public int GroupID { get; set; }
        [Required]
        public List<int> UserIDList { get; set; }


    }
}
