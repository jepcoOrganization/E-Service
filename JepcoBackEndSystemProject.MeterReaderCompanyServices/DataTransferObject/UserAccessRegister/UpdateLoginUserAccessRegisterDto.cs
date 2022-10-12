using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.UserAccessRegister
{
    public class UpdateLoginUserAccessRegisterDto
    {


        [Required]
        public string LanguageId { get; set; }
        [Required]
        public int UserRegisterID { get; set; }
        [Required]
        public string VehiclePlateNumber { get; set; }

        [Required]
        public string TechnicationFullName2 { get; set; }

        [Required]
        public string TechnicationEmployeeNumber2 { get; set; }
    }
}
