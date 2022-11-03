﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Models.Models
{
    //internal class tb_MaintenanceRequest
    //{
    //}

    public partial class tb_MaintenanceRequest
    {
        [Key]
        [Required]
        public long ID { get; set; }
     
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
        public int BuildingNumber { get; set; }
        [Required]
        public int PowerCapacityId { get; set; }

        [Required]
        public string Attachment_gov { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }


}