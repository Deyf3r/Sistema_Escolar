﻿using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Exceptions;
using Sistema_Escolar.Data.Repositories.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace Sistema_Escolar.Data.Repositories.Mocks
{
    public class MockUsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext context;
        public MockUsuarioRepository(UsuariosContext context) {

            this.context = context;
            this.CargarDatos();
        }
        public void Actualizar(Usuarios usuarios)
        {
            if (usuarios is null)

                throw new UsuarioIsNullExecption("El usuario no puede ser null");

            Usuarios UsuarioToUpdate = this.context.Usuarios.Find(usuarios.IdUsuario);

            if (UsuarioToUpdate is null)
                throw new UsurioToRemoveExecption("El asiento a actualizar no puede ser null");

            UsuarioToUpdate.IdUsuario=(usuarios.IdUsuario);
            UsuarioToUpdate.Name=(usuarios.Name);
            UsuarioToUpdate.Email=(usuarios.Email);
            UsuarioToUpdate.Password=(usuarios.Password);
            UsuarioToUpdate.Phone=(usuarios.Phone);

            this.context.Usuarios.Update(UsuarioToUpdate);
            this.context.SaveChanges();
        }

        public void Agregar(Usuarios usuarios)
        {
            if (usuarios is null)

                throw new UsuarioIsNullExecption("El usuario no puede ser null");

            if (ExisteUsuario(usuarios.IdUsuario))
            {
                throw new UsuarioDuplicateExepction("El usuario ya existe");
            }

            Usuarios UsuarioToAdd = new Usuarios()
            {
                IdUsuario = usuarios.IdUsuario,
                Name = usuarios.Name,
                Email = usuarios.Email,
                Password = usuarios.Password,
                Phone = usuarios.Phone

            };

            this.context.Usuarios.Add(UsuarioToAdd);
            this.context.SaveChanges();
        }

        public Usuarios ObtenerPorId(int IdUsuario)
        {
            return this.context.Usuarios.Find(IdUsuario);
        }

        public void Remover(Usuarios usuarios)
        {
            if(usuarios is null)
            
                throw new UsuarioIsNullExecption("El usuario no puede ser null");
            
            Usuarios UsuarioToRemove = this.context.Usuarios.Find(usuarios.IdUsuario);

            if (UsuarioToRemove is null)
                throw new UsurioToRemoveExecption("El usuario a remover no puede ser nulo");
        }

        private bool ExisteUsuario(int UsuarioId)
        {
            return this.context.Usuarios.Any(cd => cd.IdUsuario == UsuarioId);
        }

        public List<Usuarios> TraerTodos()
        {
            throw new NotImplementedException();
        }

        private void CargarDatos()
        {
            Usuarios usuarios = new Usuarios()
            {
               IdUsuario = 1,
               Name="Pedro",
               Password="Contraseña",
                Email = "Email",
               Phone= 8081231234

            };

            this.context.Usuarios.AddRange(usuarios);
            this.context.SaveChanges();
        }

    }
}
