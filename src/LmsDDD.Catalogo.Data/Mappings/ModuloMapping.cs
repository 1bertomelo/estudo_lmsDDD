using LmsDDD.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LmsDDD.Catalogo.Data.Mappings
{
    public class ModuloMapping : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Icone)
            .IsRequired()
            .HasColumnType("varchar(250)");

            // 1 : N => Modulos : Aulas
            builder.HasMany(mo => mo.Aulas)
                .WithOne(a => a.Modulo)
                .HasForeignKey(a => a.ModuloId);

            builder.ToTable("Modulos");

        }
    }
}
