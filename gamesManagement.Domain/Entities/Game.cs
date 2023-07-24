using System.ComponentModel.DataAnnotations;

namespace gamesManagement.Domain.Entities
{
    public class Game : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BorrowedGame> BorrowedGames { get; set; }
    }
}
