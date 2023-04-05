using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Domain.Models;

namespace Tescaro.GBT.Repository.Interfaces
{
    public  interface IGBTRepository
    {
        #region Geral
        void Adicionar<T>(T entity);
        void Atualizar<T>(T entity);
        void Excluir<T>(T entity);
        void ExcluirVarios<T>(List<T> entityList); 

        Task<bool> SalvarAlteracoesAsync();
        #endregion


    }
}
