using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Infrastructure.Repositories.Interfaces;
using Moq;

namespace friendsManagement.UnitTest.Service
{
    public class FriendServiceUnitTest
    {
        private readonly Mock<IFriendService> _friendServiceMock;
        private readonly Mock<IFriendRepository> _friendRepositoryMock;
        private static IFriendService _friendService;

        public FriendServiceUnitTest()
        {
            var mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new gamesManagement.Application.AutoMapper.AutoMapper());
            });
            var mapper = mapperMock.CreateMapper();

            _friendRepositoryMock = new Mock<IFriendRepository>();
            _friendServiceMock = new Mock<IFriendService>();
            _friendService = new FriendService(_friendRepositoryMock.Object, mapper);
        }

        [Fact]
        public async void Should_Save_Friend()
        {
            // arrange
            FriendRequestDto friendRequestDto = new FriendRequestDto
            {
                Name = "name",
                Description = "description",
                IsActive = true
            };
            _friendServiceMock.Setup(m => m.PostAsync(friendRequestDto).Result).Returns(true);

            //act
            var resultMock = await _friendServiceMock.Object.PostAsync(friendRequestDto);
            var result = await _friendService.PostAsync(friendRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Not_Save_Friend()
        {
            // arrange
            FriendRequestDto friendRequestDto = new FriendRequestDto
            {
                Description = "description",
                IsActive = true
            };
            _friendServiceMock.Setup(m => m.PostAsync(friendRequestDto).Result).Returns(false);

            //act
            var resultMock = await _friendServiceMock.Object.PostAsync(friendRequestDto);
            var result = await _friendService.PostAsync(friendRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Update_Friend()
        {
            // arrange
            FriendRequestDto friendRequestDto = new FriendRequestDto
            {
                Name = "name",
                Description = "description",
                IsActive = true
            };
            _friendServiceMock.Setup(m => m.UpdateAsync(friendRequestDto).Result).Returns(true);

            //act
            var resultMock = await _friendServiceMock.Object.UpdateAsync(friendRequestDto);
            var result = await _friendService.UpdateAsync(friendRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Not_Update_Friend()
        {
            // arrange
            FriendRequestDto friendRequestDto = new FriendRequestDto
            {
                Description = "description",
                IsActive = true
            };
            _friendServiceMock.Setup(m => m.UpdateAsync(friendRequestDto).Result).Returns(false);

            //act
            var resultMock = await _friendServiceMock.Object.UpdateAsync(friendRequestDto);
            var result = await _friendService.UpdateAsync(friendRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Delete_Friend()
        {
            // arrange
            int id = 2;
            //act
            await _friendService.Delete(id);

            //Assert
            _friendRepositoryMock.Verify(r => r.Remove(null), Times.AtMostOnce());
        }

        [Fact]
        public async void Should_Get_Friend()
        {
            // arrange
            int id = 2;
            //act
            await _friendService.Get(id);

            //Assert
            _friendRepositoryMock.Verify(g => g.Get(id), Times.AtMostOnce());
        }

        [Fact]
        public async void Should_GetAll_Friend()
        {
            // arrange
            int id = 2;
            //act
            await _friendService.GetAsync();

            //Assert
            _friendRepositoryMock.Verify(g => g.GetAllAsync(It.IsAny<CancellationToken>()), Times.AtMostOnce());
        }
    }
}
