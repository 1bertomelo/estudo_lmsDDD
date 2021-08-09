using LmsDDD.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LmsDDD.Catalogo.Data.Mappings
{
    public class OpcaoMapping : IEntityTypeConfiguration<Opcao>
    {
        public void Configure(EntityTypeBuilder<Opcao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            // 1 : N => Questões : Opções
            builder.HasOne(o => o.Questao)
                    .WithMany(q => q.Opcoes);

        }
    }
}
