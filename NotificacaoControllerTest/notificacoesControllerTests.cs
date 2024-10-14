using GestaoResiduos.Controllers;
using GestaoResiduos.Models;
using GestaoResiduos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GestaoResiduos.Tests
{
    public class NotificacoesControllerTests
    {
        [Fact]
        public async Task EnviarNotificacao_DeveRetornarOk()
        {
            // Arrange
            var mockService = new Mock<INotificacaoService>();
            mockService.Setup(service => service.EnviarNotificacaoAsync(It.IsAny<NotificacaoDto>())).ReturnsAsync(true);
            var controller = new NotificacoesController(mockService.Object);
            var notificacaoDto = new NotificacaoDto();

            // Act
            var result = await controller.EnviarNotificacao(notificacaoDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }

    public class ObterNotificacoesControllerTests
    {
        [Fact]
        public async Task ObterNotificacoes_DeveRetornarOk()
        {
            // Arrange
            var mockService = new Mock<INotificacaoService>();
            var notificacoesMock = new List<NotificacaoDto>
            {
                new NotificacaoDto { Id = 1, Titulo = "Notificação 1", Mensagem = "Mensagem 1" },
                new NotificacaoDto { Id = 2, Titulo = "Notificação 2", Mensagem = "Mensagem 2" }
            };
            mockService.Setup(service => service.ObterNotificacoesAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(notificacoesMock);
            var controller = new NotificacoesController(mockService.Object);

            // Act
            var result = await controller.ObterNotificacoes() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var model = result.Value as IEnumerable<NotificacaoDto>;
            Assert.NotNull(model);
            Assert.Equal(2, model.Count());
        }

    }
    public class AtualizarNotificacoesControllerTests
    {
        [Fact]
        public async Task AtualizarNotificacao_DeveRetornarOk()
        {
            // Arrange
            var mockService = new Mock<INotificacaoService>();
            mockService.Setup(service => service.AtualizarNotificacaoAsync(It.IsAny<int>(), It.IsAny<NotificacaoDto>())).ReturnsAsync(true);
            var controller = new NotificacoesController(mockService.Object);
            var id = 1;
            var notificacaoDto = new NotificacaoDto();

            // Act
            var result = await controller.AtualizarNotificacao(id, notificacaoDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
    public class ExcluirNotificacoesControllerTests
    {
        [Fact]
        public async Task ExcluirNotificacao_DeveRetornarOk()
        {
            // Arrange
            var mockService = new Mock<INotificacaoService>();
            mockService.Setup(service => service.ExcluirNotificacaoAsync(It.IsAny<int>())).ReturnsAsync(true);
            var controller = new NotificacoesController(mockService.Object);
            var id = 1;

            // Act
            var result = await controller.ExcluirNotificacao(id) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}