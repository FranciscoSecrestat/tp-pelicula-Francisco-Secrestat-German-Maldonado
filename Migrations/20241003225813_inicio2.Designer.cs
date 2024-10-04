﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tp_pelicula_Francisco_Secrestat.Models;

#nullable disable

namespace tp_pelicula_Francisco_Secrestat.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241003225813_inicio2")]
    partial class inicio2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FechaNacimiento")
                        .HasColumnType("int");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("actor");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("generos");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("FechaEstreno")
                        .HasColumnType("int");

                    b.Property<int>("GeneroID")
                        .HasColumnType("int");

                    b.Property<string>("Portada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resumen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("GeneroID");

                    b.ToTable("peliculas");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.PeliculaActores", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("ActoresId")
                        .HasColumnType("int");

                    b.HasKey("PeliculaId", "ActoresId");

                    b.HasIndex("ActoresId");

                    b.ToTable("peliculasActores");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.Pelicula", b =>
                {
                    b.HasOne("tp_pelicula_Francisco_Secrestat.Models.Actor", null)
                        .WithMany("pelicula")
                        .HasForeignKey("ActorId");

                    b.HasOne("tp_pelicula_Francisco_Secrestat.Models.Genero", "genero")
                        .WithMany()
                        .HasForeignKey("GeneroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("genero");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.PeliculaActores", b =>
                {
                    b.HasOne("tp_pelicula_Francisco_Secrestat.Models.Actor", "actores")
                        .WithMany()
                        .HasForeignKey("ActoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tp_pelicula_Francisco_Secrestat.Models.Pelicula", "peliculas")
                        .WithMany("peliculasActores")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("actores");

                    b.Navigation("peliculas");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.Actor", b =>
                {
                    b.Navigation("pelicula");
                });

            modelBuilder.Entity("tp_pelicula_Francisco_Secrestat.Models.Pelicula", b =>
                {
                    b.Navigation("peliculasActores");
                });
#pragma warning restore 612, 618
        }
    }
}
