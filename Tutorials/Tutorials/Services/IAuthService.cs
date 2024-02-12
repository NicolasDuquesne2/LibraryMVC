using Tutorials.Model;

namespace Tutorials.Services
{
    public class IAuthService
    {
        User? CheckUser(UserDTORequest userDto);

        string GenerateJWT(User user);
    }
}
