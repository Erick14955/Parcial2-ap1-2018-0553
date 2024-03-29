﻿using Microsoft.EntityFrameworkCore;
using Parcial2_ap1_2018_0553.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_ap1_2018_0553.DAL
{
    class Contexto: DbContext
    {
        public DbSet<Proyectos> Proyectos { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/datosProyectos.Db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tareas>().HasData(
                    new Tareas() { TipoTarea = "Analisis", TareaId = 1},
                    new Tareas() { TipoTarea = "Diseño" , TareaId = 2},
                    new Tareas() { TipoTarea = "Programación" , TareaId = 3},
                    new Tareas() { TipoTarea = "Prueba" , TareaId = 4}
                );
        }
    }
}
