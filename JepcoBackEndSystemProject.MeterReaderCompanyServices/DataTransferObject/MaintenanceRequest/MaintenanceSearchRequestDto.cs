using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceRequest
{
    public class MaintenanceSearchRequestDto
    {

        [Required]
        public string LanguageId { get; set; }
       
        [Required]
        public int? ContractNumber { get; set; }

        public int GroupNumber { get; set; }

   
    }
}

