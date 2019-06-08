﻿// <auto-generated />
using System;
using EzDeal.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EzDeal.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EzDeal.Domain.Anuncio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("anunciante_id");

                    b.Property<int>("costo_servicio");

                    b.Property<string>("descripcion");

                    b.Property<int>("esta_habilitado");

                    b.Property<int?>("servicioid");

                    b.Property<string>("titulo");

                    b.Property<float>("valoracion");

                    b.HasKey("id");

                    b.HasIndex("servicioid");

                    b.ToTable("AnuncioDb");
                });

            modelBuilder.Entity("EzDeal.Domain.Reseña", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("anuncioid");

                    b.Property<int?>("clienteid");

                    b.Property<string>("contenido");

                    b.Property<float>("valoracion");

                    b.HasKey("id");

                    b.HasIndex("anuncioid");

                    b.HasIndex("clienteid");

                    b.ToTable("ReseñaDb");
                });

            modelBuilder.Entity("EzDeal.Domain.Servicio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcion");

                    b.Property<string>("nombre");

                    b.HasKey("id");

                    b.ToTable("ServicioDb");
                });

            modelBuilder.Entity("EzDeal.Domain.Solicitud", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("anuncioid");

                    b.Property<string>("aprobacion");

                    b.Property<int?>("clienteid");

                    b.Property<string>("estado");

                    b.Property<string>("mensaje");

                    b.HasKey("id");

                    b.HasIndex("anuncioid");

                    b.HasIndex("clienteid");

                    b.ToTable("SolicitudDb");
                });

            modelBuilder.Entity("EzDeal.Domain.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido");

                    b.Property<string>("contraseña");

                    b.Property<string>("distrito");

                    b.Property<string>("email");

                    b.Property<string>("nombre");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("telefono");

                    b.Property<string>("url_contacto");

                    b.HasKey("id");

                    b.ToTable("UsuarioDb");
                });

            modelBuilder.Entity("EzDeal.Domain.Anuncio", b =>
                {
                    b.HasOne("EzDeal.Domain.Servicio", "servicio")
                        .WithMany()
                        .HasForeignKey("servicioid");
                });

            modelBuilder.Entity("EzDeal.Domain.Reseña", b =>
                {
                    b.HasOne("EzDeal.Domain.Anuncio", "anuncio")
                        .WithMany()
                        .HasForeignKey("anuncioid");

                    b.HasOne("EzDeal.Domain.Usuario", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid");
                });

            modelBuilder.Entity("EzDeal.Domain.Solicitud", b =>
                {
                    b.HasOne("EzDeal.Domain.Anuncio", "anuncio")
                        .WithMany()
                        .HasForeignKey("anuncioid");

                    b.HasOne("EzDeal.Domain.Usuario", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteid");
                });
#pragma warning restore 612, 618
        }
    }
}
