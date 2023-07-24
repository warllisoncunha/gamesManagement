using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Domain.Entities;
using gamesManagement.Infrastructure.Repositories;
using gamesManagement.Infrastructure.Repositories.Interfaces;

namespace gamesManagement.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<bool> PostAsync(GameRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<Game>(request);

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    await _gameRepository.AddAsync(entity);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateAsync(GameRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<Game>(request);

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    _gameRepository.Update(entity);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
                throw;
            }
        }

        public async Task<GameResponseDto> Get(int id)
        {
            try
            {
                return _mapper.Map<GameResponseDto>(_gameRepository.Get(id));
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<GameResponseDto>> GetAsync()
        {
            try
            {
                return _mapper.Map<List<GameResponseDto>>(await _gameRepository.GetAllAsync());
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Game entity = _gameRepository.Get(id);

                _gameRepository.Remove(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
