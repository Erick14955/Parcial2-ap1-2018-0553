﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcial2_ap1_2018_0553.DAL;

namespace Parcial2_ap1_2018_0553.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210308184454_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Parcial2_ap1_2018_0553.Entidades.ProyectoDetalle", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimentos")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TipoId");

                    b.HasIndex("ProyectoId");

                    b.ToTable("ProyectoDetalle");
                });

            modelBuilder.Entity("Parcial2_ap1_2018_0553.Entidades.Proyectos", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionProyecto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("TiempoTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("Parcial2_ap1_2018_0553.Entidades.Tareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            TipoTarea = "Analisis"
                        },
                        new
                        {
                            TareaId = 2,
                            TipoTarea = "Diseño"
                        },
                        new
                        {
                            TareaId = 3,
                            TipoTarea = "Programación"
                        },
                        new
                        {
                            TareaId = 4,
                            TipoTarea = "Prueba"
                        });
                });

            modelBuilder.Entity("Parcial2_ap1_2018_0553.Entidades.ProyectoDetalle", b =>
                {
                    b.HasOne("Parcial2_ap1_2018_0553.Entidades.Proyectos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProyectoId");
                });

            modelBuilder.Entity("Parcial2_ap1_2018_0553.Entidades.Tareas", b =>
                {
                    b.HasOne("Parcial2_ap1_2018_0553.Entidades.Tareas", "tareas")
                        .WithMany()
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tareas");
                });

            modelBuilder.Entity("Parcial2_ap1_2018_0553.Entidades.Proyectos", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
