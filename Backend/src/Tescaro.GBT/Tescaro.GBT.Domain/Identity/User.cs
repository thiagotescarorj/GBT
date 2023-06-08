using Microsoft.AspNetCore.Identity;

namespace Tescaro.GBT.Domain.Identity
{
    public class User : IdentityUser<long>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

    }
}
