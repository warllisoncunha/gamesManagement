using gamesManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gamesManagement.Infrastructure.Mapping
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");

            builder.HasKey(x => x.Id)
                .HasName("GameId");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnType("varchar(80)")
                   .HasColumnName("Name");

            builder.Property(x => x.Description)
                   .IsRequired(false)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("Description");

            builder.Property(x => x.IsActive)
                   .IsRequired()
                   .HasColumnType("bit")
                   .HasDefaultValue(true)
                   .HasColumnName("IsActive");
        }
    }
}
