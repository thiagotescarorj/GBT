﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tescaro.GBT.Appplication.DTOs
{
    public class UserUpdateDTO
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Perfil { get; set; }
    }
}
