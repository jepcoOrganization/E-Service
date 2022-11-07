using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceRequest
{
    public class DistrictLookupRequestDto
{
        [Required]
        public string LanguageId { get; set; }

        [Required]
        public long GovernateId { get; set; }

    }
}
