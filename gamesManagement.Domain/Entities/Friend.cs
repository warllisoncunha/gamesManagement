namespace gamesManagement.Domain.Entities
{
    public class Friend : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BorrowedGame> BorrowedGames { get; set; }
    }
}
