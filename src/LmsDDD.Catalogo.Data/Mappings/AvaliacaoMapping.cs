using LmsDDD.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LmsDDD.Catalogo.Data.Mappings
{
    public class AvaliacaoMapping : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // 1 : N => Avaliacao : Questoes
            builder.HasMany(av => av.Questoes)
                .WithOne(q => q.Avaliacao)
                .HasForeignKey(q => q.AvaliacaoId);

            builder.ToTable("Avaliacoes");

        }
    }
}
