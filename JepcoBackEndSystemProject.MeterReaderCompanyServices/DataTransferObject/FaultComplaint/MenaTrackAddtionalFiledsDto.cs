using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.Complaints
{
    public class MenaTrackAddtionalFiledsDto
    {

        long IssueID { get; set; }
        int BranchId { get; set; }
        public string FieldID { get; set; }
     
        public string FieldValue { get; set; }
        

    }
}
