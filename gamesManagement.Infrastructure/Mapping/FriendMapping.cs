using gamesManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gamesManagement.Infrastructure.Mapping
{
    public class FriendMapping : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("Friend");

            builder.HasKey(x => x.Id)
                .HasName("FriendId");

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
