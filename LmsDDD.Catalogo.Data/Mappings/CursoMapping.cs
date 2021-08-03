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

            builder.Property(c => c.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.CargaHoraria , cm =>
            {
                cm.Property(c => c.Hora)
                    .HasColumnName("Hora")
                    .HasColumnType("int");

                cm.Property(c => c.Minuto)
                    .HasColumnName("Minuto")
                    .HasColumnType("int");
            });

            builder.Property(c => c.Valor)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

            builder.Property(c => c.MediaAprovacao)
            .IsRequired()
            .HasColumnType("decimal(5,2)");


            builder.ToTable("Cursos");
        }
    }
}
