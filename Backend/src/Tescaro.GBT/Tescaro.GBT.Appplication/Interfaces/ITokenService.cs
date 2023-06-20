using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tescaro.GBT.Appplication.DTOs;

namespace Tescaro.GBT.Appplication.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDTO userUpdateDTO);
    }
}
