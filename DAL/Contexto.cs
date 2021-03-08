using Microsoft.EntityFrameworkCore;
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
                    new Tareas() { TareaId = 1, TipoTarea = "Analisis"},
                    new Tareas() { TareaId = 2, TipoTarea = "Diseño" },
                    new Tareas() { TareaId = 3, TipoTarea = "Programación" },
                    new Tareas() { TareaId = 4, TipoTarea = "Prueba" }
                );
        }
    }
}
