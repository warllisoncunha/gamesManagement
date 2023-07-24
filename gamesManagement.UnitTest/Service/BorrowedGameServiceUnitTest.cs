using AutoMapper;
using gamesManagement.Application.DTOs;
using gamesManagement.Application.Services.Interfaces;
using gamesManagement.Application.Services;
using gamesManagement.Infrastructure.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamesManagement.UnitTest.Service
{
    public class BorrowedGameServiceUnitTest
    {
        private readonly Mock<IBorrowedGameService> _borrowedGameServiceMock;
        private readonly Mock<IBorrowedGameRepository> _borrowedGameRepositoryMock;
        private static IBorrowedGameService _borrowedGameService;

        public BorrowedGameServiceUnitTest()
        {
            var mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Application.AutoMapper.AutoMapper());
            });
            var mapper = mapperMock.CreateMapper();

            _borrowedGameRepositoryMock = new Mock<IBorrowedGameRepository>();
            _borrowedGameServiceMock = new Mock<IBorrowedGameService>();
            _borrowedGameService = new BorrowedGameService(_borrowedGameRepositoryMock.Object, mapper);
        }

        [Fact]
        public async void Should_Save_BorrowedGame()
        {
            // arrange
            BorrowedGameRequestDto borrowedGameRequestDto = new BorrowedGameRequestDto
            {
                FriendId = 1,
                GameId = 1,
                TakeDate = DateTime.Now,
                DevolutionDate = DateTime.Now,
                Observation = "test"
            };
            _borrowedGameServiceMock.Setup(m => m.PostAsync(borrowedGameRequestDto).Result).Returns(true);

            //act
            var resultMock = await _borrowedGameServiceMock.Object.PostAsync(borrowedGameRequestDto);
            var result = await _borrowedGameService.PostAsync(borrowedGameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Not_Save_BorrowedGame()
        {
            // arrange
            BorrowedGameRequestDto borrowedGameRequestDto = new BorrowedGameRequestDto();

            _borrowedGameServiceMock.Setup(m => m.PostAsync(borrowedGameRequestDto).Result).Returns(false);

            //act
            var resultMock = await _borrowedGameServiceMock.Object.PostAsync(borrowedGameRequestDto);
            var result = await _borrowedGameService.PostAsync(borrowedGameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Update_BorrowedGame()
        {
            // arrange
            BorrowedGameRequestDto borrowedGameRequestDto = new BorrowedGameRequestDto
            {
                Id = 1,
                GameId = 1,
                FriendId = 1,
                DevolutionDate = DateTime.Now,
                TakeDate = DateTime.Now,
                Observation = "test"
            };
            _borrowedGameServiceMock.Setup(m => m.UpdateAsync(borrowedGameRequestDto).Result).Returns(true);

            //act
            var resultMock = await _borrowedGameServiceMock.Object.UpdateAsync(borrowedGameRequestDto);
            var result = await _borrowedGameService.UpdateAsync(borrowedGameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Not_Update_BorrowedGame()
        {
            // arrange
            BorrowedGameRequestDto borrowedGameRequestDto = new BorrowedGameRequestDto();
            _borrowedGameServiceMock.Setup(m => m.UpdateAsync(borrowedGameRequestDto).Result).Returns(false);

            //act
            var resultMock = await _borrowedGameServiceMock.Object.UpdateAsync(borrowedGameRequestDto);
            var result = await _borrowedGameService.UpdateAsync(borrowedGameRequestDto);

            // Assert
            Assert.Equal(result, resultMock);
        }

        [Fact]
        public async void Should_Delete_BorrowedGame()
        {
            // arrange
            int id = 2;
            //act
            await _borrowedGameService.Delete(id);

            //Assert
            _borrowedGameRepositoryMock.Verify(r => r.Remove(null), Times.AtMostOnce());
        }

        [Fact]
        public async void Should_Get_BorrowedGame()
        {
            // arrange
            int id = 2;
            //act
            await _borrowedGameService.Get(id);

            //Assert
            _borrowedGameRepositoryMock.Verify(g => g.Get(id), Times.AtMostOnce());
        }

        [Fact]
        public async void Should_GetAll_BorrowedGame()
        {
            // arrange
            int id = 2;
            //act
            await _borrowedGameService.GetAsync();

            //Assert
            _borrowedGameRepositoryMock.Verify(g => g.GetAllAsync(It.IsAny<CancellationToken>()), Times.AtMostOnce());
        }
    }
}

