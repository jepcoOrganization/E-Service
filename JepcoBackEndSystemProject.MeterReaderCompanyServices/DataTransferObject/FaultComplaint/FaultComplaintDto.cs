using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;


namespace JepcoBackEndSystemProject.Services.DataTransferObject.FaultComplaint
{
    public class FaultComplaintDto
    {
     
        [Required]
        public string LanguageId { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int BranchID { get; set; }
    }

    public class ChildFaultComplaintDto
    {

        [Required]
        public string LanguageId { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int BranchID { get; set; }
        [Required]
        public long IssueID { get; set; }
        public string ComplaintRefCode { get; set; }


    }



}
