using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Domain.Entities;

namespace gamesManagement.Application.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<FriendResponseDto, Friend>().ReverseMap();
            CreateMap<FriendRequestDto, Friend>().ReverseMap();

            CreateMap<GameResponseDto, Game>().ReverseMap();
            CreateMap<GameRequestDto, Game>().ReverseMap();

            CreateMap<BorrowedGameResponseDto, BorrowedGame>().ReverseMap();
            CreateMap<BorrowedGameRequestDto, BorrowedGame>().ReverseMap();

        }
    }
}
