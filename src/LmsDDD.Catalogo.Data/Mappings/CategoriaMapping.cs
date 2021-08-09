using LmsDDD.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LmsDDD.Catalogo.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // 1 : N => Categorias : Cursos
            builder.HasMany(ca => ca.Cursos)
                .WithOne(c => c.Categoria)
                .HasForeignKey(c => c.CategoriaId);

            builder.ToTable("Categorias");

        }
    }
}
