using System.ComponentModel.DataAnnotations;

namespace CoursWebApiEF.DTO
{
    public class UserDTOResponse
    {
        public string Id { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        public string Role { get; set; } = null!;
    }
}
