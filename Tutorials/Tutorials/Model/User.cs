namespace Tutorials.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;

        public string Role { get; set; } = "ROLE_USER";
    }
}
