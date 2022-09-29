using JepcoBackEndSystemProject.Models.Models;
using System.Collections.Generic;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.GeneralTechnicianInf
{
    public class GroupCountResponseDto
    {
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public int TotalComplaintNum { get; set; }
        public int NewComplaintNum { get; set; }
        public int DeliveredComplaintNum { get; set; }
        public int ArrivingLocationComplaintNum { get; set; }
        public int ClosedFromTechnicianComplaintNum { get; set; }
        public int ReAssingedComplaintNum { get; set; }


        public List<tb_Fault_Compliants> GroupOfComplaint { get; set; }

    }

}
