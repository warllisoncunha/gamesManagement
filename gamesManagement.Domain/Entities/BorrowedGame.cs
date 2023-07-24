namespace gamesManagement.Domain.Entities
{
    public class BorrowedGame : BaseEntity
    {
        public int FriendId { get; set; }
        public int GameId { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime DevolutionDate { get; set; }
        public string? Observation { get; set; }

        public virtual Friend Friend { get; set; }
        public virtual Game Game { get; set; }
    }
}
