using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.Application.DTOs
{
    public class BorrowedGameResponseDto : BaseEntityDto
    {
        public int FriendId { get; set; }
        public int GameId { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime DevolutionDate { get; set; }
        public string? Observation { get; set; }
    }
}
