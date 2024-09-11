using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem.Services.Interface
{
    public interface ITokenRepo
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
