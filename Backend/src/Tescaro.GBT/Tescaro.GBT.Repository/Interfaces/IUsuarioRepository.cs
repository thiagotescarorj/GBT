using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IUsuarioRepository : IGBTRepository
    {        
        #region Usuario
        Task<List<Usuario>> GetTodosUsuarios();
        Task<Usuario> GetUsuarioById(long UsuarioId);

        #endregion

    }
}
