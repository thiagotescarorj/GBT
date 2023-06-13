using Microsoft.AspNetCore.Identity;
using Tescaro.GBT.Domain.Enumeradores;

namespace Tescaro.GBT.Domain.Identity
{
    public class User : IdentityUser<long>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool IsAtivo { get; set; }
        public EnumPefil Pefil { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

    }
}
