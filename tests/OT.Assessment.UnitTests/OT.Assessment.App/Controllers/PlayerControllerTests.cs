using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moq;

using RabbitMQ.Client;
using Xunit;
using OT.Assessment.App.Controllers;
using OT.Assessment.App.Models;
using OT.Assessment.App.Models.CasinoWagers.Dtos;
using OT.Assessment.App.Infrastructure;

namespace OT.Assessment.Tests.Controllers
{
    public class PlayerControllerTests
    {
        private readonly Mock<IConnection> _mockConnection;
        private readonly PlayerController _controller;

        public PlayerControllerTests()
        {
            _mockConnection = new Mock<IConnection>();
            _controller = new PlayerController(_mockConnection.Object);
        }

        [Fact]
        public async Task CreateCasinoWagerAsync_ShouldReturnOkResult()
        {
            // Arrange
            var casinoWager = new CasinoWager
            {
                WagerId = "aa6700eb-1a06-483e-9739-d293dc7a9383",
                Theme = "adventure",
                Provider = "Ergonomic Soft Fish",
                GameName = "Ergonomic Granite Cheese",
                TransactionId = "410b7161-3473-4d74-85c3-a533d050a9d3",
                BrandId = "8a2016f8-c4c4-471f-9a9c-337a54664650",
                AccountId = "5ac75fec-23e9-27d1-b660-179eee70003d",
                Username = "Jay.Bernhard67",
                ExternalReferenceId = "0267dbca-2760-4a9e-ab42-5ce766fa8ca0",
                TransactionTypeId = "8aaece0c-5d53-4225-a937-adb454c4da31",
                Amount = 38273.974454660885,
                CreatedDateTime = DateTime.Parse("2024-05-04T02:25:05.9906387+02:00"),
                NumberOfBets = 3,
                CountryCode = "BS",
                SessionData = "Central Chile Awesome Cotton Gloves cross-platform Handmade Rubber Shoes portals leading-edge Coordinator Data Producer end-to-end encoding Gorgeous Clothing View Health, Outdoors & Music embrace Metrics Facilitator morph",
                Duration = 1827254
            };

            var channelMock = new Mock<IModel>();
            _mockConnection.Setup(c => c.CreateModel()).Returns(channelMock.Object);

            // Act
            var result = await _controller.CreateCasinoWagerAsync(casinoWager);

            // Assert
            Assert.IsType<OkResult>(result);
            channelMock.Verify(c => c.BasicPublish(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IBasicProperties>(), It.IsAny<byte[]>()), Times.Once);
        }

        [Fact]
        public async Task GetAllPlayerCasinoWagersAsync_ShouldReturnOkResultWithPaginatedItems()
        {
            // Arrange
            var playerId = Guid.NewGuid();

            // Act
            var result = await _controller.GetAllPlayerCasinoWagersAsync(playerId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var paginatedItems = Assert.IsType<PaginatedItems<CasinoWager>>(okResult.Value);
            Assert.Empty(paginatedItems.Data);
        }

        [Fact]
        public async Task GetTopSpendersAsync_ShouldReturnOkResultWithTopSpenders()
        {
            // Arrange
            var count = 10;

            // Act
            var result = await _controller.GetTopSpendersAsync(count);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var topSpenders = Assert.IsType<List<PlayerCasinoWagerDto>>(okResult.Value);
            Assert.Empty(topSpenders);
        }
    }
}
