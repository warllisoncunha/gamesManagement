using gamesManagement.Domain.Entities;
using gamesManagement.Infrastructure.Context;
using gamesManagement.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.Infrastructure.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(SqlServerContext _context) : base(_context)
        {
        }
    }
}
