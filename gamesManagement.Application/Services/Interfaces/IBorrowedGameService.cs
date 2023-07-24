using gamesManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.Application.Services.Interfaces
{
    public interface IBorrowedGameService
    {
        Task<bool> PostAsync(BorrowedGameRequestDto request);
        Task<bool> UpdateAsync(BorrowedGameRequestDto request);
        Task<BorrowedGameResponseDto> Get(int id);
        Task<List<BorrowedGameResponseDto>> GetAsync();
        Task Delete(int id);
    }
}
