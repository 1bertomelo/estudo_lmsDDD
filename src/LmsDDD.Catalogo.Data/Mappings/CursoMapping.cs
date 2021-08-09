using LmsDDD.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Catalogo.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(250)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Valor)
            .IsRequired()
            .HasColumnType("numeric(10,2)");           

            builder.Property(c => c.MediaAprovacao)
            .IsRequired()
            .HasColumnType("numeric(10,2)");


            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.CargaHoraria, ch =>
            {
                ch.Property(c => c.Hora)
                    .HasColumnName("Hora")
                    .HasColumnType("int");

                ch.Property(c => c.Minuto)
                    .HasColumnName("Largura")
                    .HasColumnType("int");
            });

            // 1 : N => Cursos : Modulos
            builder.HasMany(c => c.Modulos)
                .WithOne(mo => mo.Curso)
                .HasForeignKey(mo => mo.CursoId);


            builder.ToTable("Cursos");
        }
    }
}
