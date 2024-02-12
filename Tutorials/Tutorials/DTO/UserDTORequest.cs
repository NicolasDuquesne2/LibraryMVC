using System.ComponentModel.DataAnnotations;

namespace CoursWebApiEF.DTO
{
    public class UserDTORequest
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
