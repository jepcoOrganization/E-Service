using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceRequest
{
    public class MaintenanceRequestDto
{

        [Required]
        public string LanguageId { get; set; }
        [Required]
        public long MaintenanceTypeId { get; set; }
        [Required]
        public int? ContractNumber { get; set; }

        public int GroupNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string MobileNumber { get; set; }
        [Required]
        public long GovernateId { get; set; }
        [Required]
        public long DistrictID { get; set; }

        
        [Required]
        [StringLength(100)]
        public string StreetName { get; set; }
        [Required]
        public string BuildingNumber { get; set; }
        [Required]
        public int PowerCapacityId { get; set; }
        public string PowerCapacityName { get; set; }


        [Required]

        public string Attachment_gov { get; set; }

        public string Attachment_gov_Name { get; set; }





        

    }
}

