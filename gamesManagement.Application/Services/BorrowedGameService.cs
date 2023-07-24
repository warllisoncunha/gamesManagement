using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Domain.Entities;
using gamesManagement.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace gamesManagement.Application.Services
{
    public class BorrowedGameService : IBorrowedGameService
    {
        private readonly IBorrowedGameRepository _borrowedGameRepository;
        private readonly IMapper _mapper;

        public BorrowedGameService(IBorrowedGameRepository borrowedGameRepository, IMapper mapper)
        {
            _borrowedGameRepository = borrowedGameRepository;
            _mapper = mapper;
        }

        public async Task<bool> PostAsync(BorrowedGameRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<BorrowedGame>(request);

                if (entity.FriendId > 0 && entity.GameId > 0)
                {
                    await _borrowedGameRepository.AddAsync(entity);
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

        public async Task<bool> UpdateAsync(BorrowedGameRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<BorrowedGame>(request);

                if (entity.FriendId > 0 && entity.GameId > 0)
                {
                    _borrowedGameRepository.Update(entity);
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
        public async Task<BorrowedGameResponseDto> Get(int id)
        {
            try
            {
                return _mapper.Map<BorrowedGameResponseDto>(_borrowedGameRepository.Get(id));
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BorrowedGameResponseDto>> GetAsync()
        {
            try
            {
                return _mapper.Map<List<BorrowedGameResponseDto>>(await _borrowedGameRepository.GetAllAsync());
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
                BorrowedGame entity = _borrowedGameRepository.Get(id);

                _borrowedGameRepository.Remove(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
