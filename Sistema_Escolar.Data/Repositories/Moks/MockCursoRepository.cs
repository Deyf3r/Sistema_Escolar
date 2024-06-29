﻿using Sistema_Escolar.Data.Context;
using Sistema_Escolar.Data.Entities;
using Sistema_Escolar.Data.Exceptions;
using Sistema_Escolar.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Escolar.Data.Repositories.Moks
{
    public class MockCursoRepository : ICursoRepository
    {
        private readonly SistemaEscolarContext context;

        public MockCursoRepository(SistemaEscolarContext context)
        {
            this.context = context;
            this.CargarDatos();
        }
        public void Actualizar(Cursos curso)
        {
            if (EsCursoNull(curso))
                throw new CursoNullException("El Objeto asiento no debe de ser null");

            Cursos cursoToUpdate = this.context.Curso.Find(curso);

            if (cursoToUpdate is null)
                throw new CursoNotExistsException("El Objeto asiento no debe de ser null");

            cursoToUpdate.CursoId = curso.CursoId;
            cursoToUpdate.Nombre = curso.Nombre;
            cursoToUpdate.CodigoCurso = curso.CodigoCurso;
            cursoToUpdate.Descripcion = curso.Descripcion;
            cursoToUpdate.ProfesorAsig = curso.ProfesorAsig;

            this.context.Curso.Update(cursoToUpdate);
            this.context.SaveChanges();
        }

        public void Agregar(Cursos curso)
        {
            if (EsCursoNull(curso))
                throw new CursoNullException("El Objeto asiento no debe de ser null");

            if (ExisteCurso(curso.CursoId, curso.ProfesorAsig))
            {
                throw new CursoDuplicadoException($"Este curso{curso.CursoId} para este curso: {curso.ProfesorAsig} se encuentra registrado");

            }

            Cursos CursoToAdd = new Cursos()
            {
                CursoId = curso.CursoId,
                ProfesorAsig = curso.ProfesorAsig,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion,
                CodigoCurso = curso.CodigoCurso,

            };

            this.context.Curso.Add(CursoToAdd);
            this.context.SaveChanges();
        }

        public Cursos ObtenerPorId(int CursoId)
        {
            return this.context.Curso.Find(CursoId);
        }

        public void Remover(Cursos curso)
        {
            if (EsCursoNull(curso))
                throw new CursoNullException("El Objeto asiento no debe de ser null");



            Cursos cursoToRemove = this.context.Curso.Find(curso.CursoId);

            if (cursoToRemove is null)
                throw new CursoNotExistsException("El curso no se encuenta registrado");



            this.context.Curso.Remove(cursoToRemove);
            this.context.SaveChanges();
        }

        public List<Cursos> TraerTodos()
        {
            return this.context.Curso.ToList();
        }

        private void CargarDatos()
        {
            Cursos curso = new Cursos()
            {
                CursoId = 1,
                Nombre = "Ciencias Sociales",
                CodigoCurso = "001A",
                Descripcion = "Curso sobre la historia del pais",
                ProfesorAsig = 1
            };

            List<Cursos> cursos = new List<Cursos>()
            {
                new Cursos()
                {
                CursoId = 1,
                Nombre = "Ciencias Sociales",
                CodigoCurso = "001A",
                Descripcion = "Curso sobre la historia del pais",
                ProfesorAsig = 1,

                },
                new Cursos()
                {
                CursoId = 2,
                Nombre = "Ciencias Naturales",
                CodigoCurso = "001B",
                Descripcion = "Curso sobre biologia, quimica y fisica",
                ProfesorAsig =2,

                },
                 new Cursos()
                {
                CursoId = 3,
                Nombre = "Matematicas",
                CodigoCurso = "001C",
                Descripcion = "Curso sobre logica, razonamiento y numeros",
                ProfesorAsig = 3,

                },
                 new Cursos()
                {
                CursoId = 4,
                Nombre = "Ortografia",
                CodigoCurso = "001D",
                Descripcion = "Curso sobre el arte de las palabras, y su uso",
                ProfesorAsig = 4,

                },

            };

            this.context.Curso.AddRange(cursos);
            this.context.SaveChanges();


        }

        private bool EsCursoNull(Cursos curso)
        {
            bool result = false;
            if (curso == null)
            {
                result = true;

            }
            return result;
        }

        private bool ExisteCurso(int cursoId, int ProfesorAsig)
        {
            return this.context.Curso.Any(cd => cd.CursoId == cursoId && cd.ProfesorAsig == ProfesorAsig);

        }
    }
}
