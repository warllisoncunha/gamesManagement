using gamesManagement.Application.DTOs;

namespace gamesManagement.Application.Services.Interfaces
{
    public interface IGameService
    {
        Task<bool> PostAsync(GameRequestDto request);
        Task<bool> UpdateAsync(GameRequestDto request);
        Task<GameResponseDto> Get(int id);
        Task<List<GameResponseDto>> GetAsync();
        Task Delete(int id);
    }
}
