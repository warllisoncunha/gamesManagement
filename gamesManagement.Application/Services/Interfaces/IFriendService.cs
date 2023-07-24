using gamesManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.Application.Services.Interfaces
{
    public interface IFriendService 
    {
        Task<bool> PostAsync(FriendRequestDto request);
        Task<List<FriendResponseDto>> GetAsync();
        Task<FriendResponseDto> Get(int id);
        Task Delete(int id);
        Task<bool> UpdateAsync(FriendRequestDto request);
    }
}
