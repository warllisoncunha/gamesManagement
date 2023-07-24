using gamesManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.Infrastructure.Mapping
{
    public class BorrowedGameMapping : IEntityTypeConfiguration<BorrowedGame>
    {
        public void Configure(EntityTypeBuilder<BorrowedGame> builder)
        {
            builder.ToTable("BorrowedGame");

            builder.HasKey(x => x.Id)
                .HasName("BorrowedGameId");

            builder.Property(x => x.FriendId)
                   .IsRequired()
                   .HasColumnType("int")
                   .HasColumnName("FriendId");

            builder.Property(x => x.GameId)
                   .IsRequired()
                   .HasColumnType("int")
                   .HasColumnName("GameId");

            builder.Property(x => x.TakeDate)
                   .IsRequired()
                   .HasColumnType("DateTime")
                   .HasColumnName("TakeDate");

            builder.Property(x => x.DevolutionDate)
                   .IsRequired()
                   .HasColumnType("DateTime")
                   .HasColumnName("DevolutionDate");

            builder.Property(x => x.Observation)
                   .IsRequired(false)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("Observation");

            builder.HasOne(x => x.Friend)
             .WithMany(y => y.BorrowedGames)
             .HasForeignKey(x => x.FriendId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Game)
             .WithMany(y => y.BorrowedGames)
             .HasForeignKey(x => x.GameId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
