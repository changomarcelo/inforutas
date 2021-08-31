﻿// <auto-generated />
using System;
using InfoRutas.Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfoRutas.Backend.Repository.Migrations
{
    [DbContext(typeof(InfoRutasDbContext))]
    partial class InfoRutasDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("InfoRutas.Backend.Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("pk_categoria");

                    b.ToTable("categoria");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Localidades"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Estaciones de Servicio"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Paradores"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Áreas de descanso"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Restaurantes"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Miradores"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Sitios turísticos"
                        },
                        new
                        {
                            Id = 8,
                            Nombre = "Baños"
                        },
                        new
                        {
                            Id = 9,
                            Nombre = "Alojamientos"
                        },
                        new
                        {
                            Id = 10,
                            Nombre = "Peajes"
                        },
                        new
                        {
                            Id = 11,
                            Nombre = "Aportes"
                        });
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("fecha");

                    b.Property<int?>("PdiId")
                        .HasColumnType("integer")
                        .HasColumnName("pdi_id");

                    b.Property<string>("Texto")
                        .HasColumnType("text")
                        .HasColumnName("texto");

                    b.Property<int?>("TramoId")
                        .HasColumnType("integer")
                        .HasColumnName("tramo_id");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id")
                        .HasName("pk_comentario");

                    b.HasIndex("PdiId")
                        .HasDatabaseName("ix_comentario_pdi_id");

                    b.HasIndex("TramoId")
                        .HasDatabaseName("ix_comentario_tramo_id");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_comentario_usuario_id");

                    b.ToTable("comentario");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Pdi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer")
                        .HasColumnName("categoria_id");

                    b.Property<bool>("EsAporte")
                        .HasColumnType("boolean")
                        .HasColumnName("es_aporte");

                    b.Property<bool>("Fin")
                        .HasColumnType("boolean")
                        .HasColumnName("fin");

                    b.Property<bool>("Inicio")
                        .HasColumnType("boolean")
                        .HasColumnName("inicio");

                    b.Property<decimal>("Latitud")
                        .HasColumnType("numeric")
                        .HasColumnName("latitud");

                    b.Property<decimal>("Longitud")
                        .HasColumnType("numeric")
                        .HasColumnName("longitud");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nombre");

                    b.Property<int>("TramoId")
                        .HasColumnType("integer")
                        .HasColumnName("tramo_id");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id")
                        .HasName("pk_pdi");

                    b.HasIndex("CategoriaId")
                        .HasDatabaseName("ix_pdi_categoria_id");

                    b.HasIndex("TramoId")
                        .HasDatabaseName("ix_pdi_tramo_id");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_pdi_usuario_id");

                    b.ToTable("pdi");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<string>("Jurisdiccion")
                        .HasColumnType("text")
                        .HasColumnName("jurisdiccion");

                    b.Property<int>("Longitud")
                        .HasColumnType("integer")
                        .HasColumnName("longitud");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nombre");

                    b.Property<int>("Numero")
                        .HasColumnType("integer")
                        .HasColumnName("numero");

                    b.HasKey("Id")
                        .HasName("pk_ruta");

                    b.HasIndex("Numero", "Jurisdiccion")
                        .IsUnique()
                        .HasDatabaseName("ix_ruta_numero_jurisdiccion");

                    b.ToTable("ruta");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "La Ruta Nacional Nº 40 «Libertador General Don José de San Martín»1 es una carretera de Argentina cuyo recorrido se extiende desde el cabo Vírgenes, Santa Cruz hasta el límite con Bolivia en la ciudad de La Quiaca, en Jujuy.",
                            Jurisdiccion = "AR",
                            Longitud = 5194,
                            Nombre = "Ruta Nacional 40",
                            Numero = 40
                        });
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Tramo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("FechaInforme")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("fecha_informe");

                    b.Property<string>("Informe")
                        .HasColumnType("text")
                        .HasColumnName("informe");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nombre");

                    b.Property<int>("Orden")
                        .HasColumnType("integer")
                        .HasColumnName("orden");

                    b.Property<int>("RutaId")
                        .HasColumnType("integer")
                        .HasColumnName("ruta_id");

                    b.HasKey("Id")
                        .HasName("pk_tramo");

                    b.HasIndex("RutaId")
                        .HasDatabaseName("ix_tramo_ruta_id");

                    b.ToTable("tramo");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean")
                        .HasColumnName("activo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<int>("Nivel")
                        .HasColumnType("integer")
                        .HasColumnName("nivel");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.HasKey("Id")
                        .HasName("pk_usuario");

                    b.ToTable("usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activo = true,
                            Email = "marce@centraldev.com.ar",
                            Nivel = 1,
                            Nombre = "Marce",
                            PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92"
                        });
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Comentario", b =>
                {
                    b.HasOne("InfoRutas.Backend.Domain.Pdi", "Pdi")
                        .WithMany()
                        .HasForeignKey("PdiId")
                        .HasConstraintName("fk_comentario_pdi_pdi_id");

                    b.HasOne("InfoRutas.Backend.Domain.Tramo", "Tramo")
                        .WithMany()
                        .HasForeignKey("TramoId")
                        .HasConstraintName("fk_comentario_tramo_tramo_id");

                    b.HasOne("InfoRutas.Backend.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_comentario_usuario_usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pdi");

                    b.Navigation("Tramo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Pdi", b =>
                {
                    b.HasOne("InfoRutas.Backend.Domain.Categoria", "Categoria")
                        .WithMany("Pdis")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("fk_pdi_categoria_categoria_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfoRutas.Backend.Domain.Tramo", "Tramo")
                        .WithMany("PDIs")
                        .HasForeignKey("TramoId")
                        .HasConstraintName("fk_pdi_tramo_tramo_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfoRutas.Backend.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_pdi_usuario_usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Tramo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Tramo", b =>
                {
                    b.HasOne("InfoRutas.Backend.Domain.Ruta", "Ruta")
                        .WithMany("Tramos")
                        .HasForeignKey("RutaId")
                        .HasConstraintName("fk_tramo_users_ruta_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ruta");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Categoria", b =>
                {
                    b.Navigation("Pdis");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Ruta", b =>
                {
                    b.Navigation("Tramos");
                });

            modelBuilder.Entity("InfoRutas.Backend.Domain.Tramo", b =>
                {
                    b.Navigation("PDIs");
                });
#pragma warning restore 612, 618
        }
    }
}
