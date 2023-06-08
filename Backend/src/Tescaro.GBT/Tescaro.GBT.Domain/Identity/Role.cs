using Microsoft.AspNetCore.Identity;

namespace Tescaro.GBT.Domain.Identity
{
    public class Role : IdentityRole<long>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
