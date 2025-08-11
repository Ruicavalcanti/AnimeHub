using AnimeHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AnimeHub.Infrastructure.EntityConfiguration
{
    public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Diretor).HasMaxLength(60).IsRequired();
            builder.Property(x => x.Resumo).HasMaxLength(500).IsRequired();

            builder.HasData(
                new Anime(1, "Naruto", "Hayato Date",
                "A história segue Naruto Uzumaki, um jovem ninja que busca reconhecimento e sonha em se tornar Hokage, o líder de sua vila.")
                );
        }
    }
}
