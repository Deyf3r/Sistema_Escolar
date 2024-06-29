using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Exceptions
{
    public class UsuarioIsNullExecption: Exception
    {
        public UsuarioIsNullExecption(string message) : base(message) { }
    }
}
