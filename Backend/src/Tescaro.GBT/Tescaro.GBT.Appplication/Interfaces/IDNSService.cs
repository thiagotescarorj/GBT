using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface IDNSService
    {
        Task<DNS> AdicionarDNS(DNS dns);
        Task<DNS> AtualizarDNS(long dnsId, DNS model);
        Task<bool> ExcluirDNS(long dnsId);
        Task<List<DNS>> GetTodosDNS();
        Task<DNS> GetDNSById(long dnsId);
        Task<List<DNS>> GetTodosDNSByCliente(long dnsId);
        Task<List<DNS>> GetTodosDNSByNome(string nome);
    }
}
