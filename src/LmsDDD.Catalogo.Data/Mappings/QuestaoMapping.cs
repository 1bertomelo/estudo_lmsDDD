using LmsDDD.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LmsDDD.Catalogo.Data.Mappings
{
    public class QuestaoMapping : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Enunciado)
                .IsRequired()
                .HasColumnType("varchar(500)");

            // 1 : N => Avaliacao : Questoes
            builder.HasOne(q => q.Avaliacao)
                    .WithMany(av => av.Questoes);

            //1  : N => Questoes : Opcoes    
            builder.HasMany(q => q.Opcoes)
                .WithOne(op => op.Questao)
                .HasForeignKey(op => op.QuestaoId);

            builder.ToTable("Questoes");
        }
    }
}
