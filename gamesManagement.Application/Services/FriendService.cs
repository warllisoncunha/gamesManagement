using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Domain.Entities;
using gamesManagement.Infrastructure.Repositories.Interfaces;

namespace gamesManagement.Application.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IMapper _mapper;

        public FriendService(IFriendRepository friendRepository, IMapper mapper)
        {
            _friendRepository = friendRepository;
            _mapper = mapper;
        }

        public async Task<bool> PostAsync(FriendRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<Friend>(request);

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    await _friendRepository.AddAsync(entity);
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

        public async Task<bool> UpdateAsync(FriendRequestDto request)
        {
            try
            {
                var entity = _mapper.Map<Friend>(request);

                if (!string.IsNullOrEmpty(entity.Name))
                {
                    _friendRepository.Update(entity);
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
        public async Task<FriendResponseDto> Get(int id)
        {
            try
            {
                return _mapper.Map<FriendResponseDto>(_friendRepository.Get(id));
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<FriendResponseDto>> GetAsync()
        {
            try
            {
                return _mapper.Map<List<FriendResponseDto>>(await _friendRepository.GetAllAsync());
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
                Friend entity = _friendRepository.Get(id);

                _friendRepository.Remove(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}