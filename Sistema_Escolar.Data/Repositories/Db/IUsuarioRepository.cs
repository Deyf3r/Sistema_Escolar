using Sistema_Escolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Repositories.Db
{
    public interface IUsuarioRepository
    {
        void Agregar(Usuarios usuarios);
        void Actualizar(Usuarios usuarios);
        void Remover(Usuarios usuarios);
        List<Usuarios> TraerTodos();
        Usuarios ObtenerPorId(int IdUsuario);
    }
}
