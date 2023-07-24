using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Domain.Entities;
using gamesManagement.Infrastructure.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.UnitTest.Service
{
    public class GameServiceUnitTest
    {
        private readonly Mock<IGameService> _gameServiceMock;
        private readonly Mock<IGameRepository> _gameRepositoryMock;
        private static IGameService _gameService;

        public GameServiceUnitTest()
        {
            var mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Application.AutoMapper.AutoMapper());
            });
            var mapper = mapperMock.CreateMapper();

            _gameRepositoryMock = new Mock<IGameRepository>();
            _gameServiceMock = new Mock<IGameService>();
            _gameService = new GameService(_gameRepositoryMock.Object, mapper);

        }

        [Fact]
        public async void Should_Save_Game()
        {
            // arrange
            GameRequestDto gameRequestDto = new GameRequestDto
            {
                Name = "name", 
                Description = "description",
                IsActive = true
            };
            _gameServiceMock.Setup(m => m.PostAsync(gameRequestDto).Result).Returns(true);

            //act
            var resultMock = await _gameServiceMock.Object.PostAsync(gameRequestDto);
            var result = await _gameService.PostAsync(gameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Not_Save_Game()
        {
            // arrange
            GameRequestDto gameRequestDto = new GameRequestDto
            {
                Description = "description",
                IsActive = true
            };
            _gameServiceMock.Setup(m => m.PostAsync(gameRequestDto).Result).Returns(false);

            //act
            var resultMock = await _gameServiceMock.Object.PostAsync(gameRequestDto);
            var result = await _gameService.PostAsync(gameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Update_Game()
        {
            // arrange
            GameRequestDto gameRequestDto = new GameRequestDto
            {
                Name = "name",
                Description = "description",
                IsActive = true
            };
            _gameServiceMock.Setup(m => m.UpdateAsync(gameRequestDto).Result).Returns(true);

            //act
            var resultMock = await _gameServiceMock.Object.UpdateAsync(gameRequestDto);
            var result = await _gameService.UpdateAsync(gameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Not_Update_Game()
        {
            // arrange
            GameRequestDto gameRequestDto = new GameRequestDto
            {
                Description = "description",
                IsActive = true
            };
            _gameServiceMock.Setup(m => m.UpdateAsync(gameRequestDto).Result).Returns(false);

            //act
            var resultMock = await _gameServiceMock.Object.UpdateAsync(gameRequestDto);
            var result = await _gameService.UpdateAsync(gameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Delete_Game()
        {
            // arrange
            int id = 2;
            //act
            await _gameService.Delete(id);

            //Assert
            _gameRepositoryMock.Verify(r => r.Remove(null),Times.AtMostOnce());
        }

        [Fact]
        public async void Should_Get_Game()
        {
            // arrange
            int id = 2;
            //act
            await _gameService.Get(id);

            //Assert
            _gameRepositoryMock.Verify(g => g.Get(id), Times.AtMostOnce());
        }

        [Fact]
        public async void Should_GetAll_Game()
        {
            // arrange
            int id = 2;
            //act
            await _gameService.GetAsync();

            //Assert
            _gameRepositoryMock.Verify(g => g.GetAllAsync(It.IsAny<CancellationToken>()), Times.AtMostOnce());
        }
    }
}
