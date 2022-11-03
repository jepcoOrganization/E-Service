using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EService.DataTransferObject.UserModel
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class UserModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string Emails { get; set; }
        [Required]
        public string source { get; set; }
    }
}
