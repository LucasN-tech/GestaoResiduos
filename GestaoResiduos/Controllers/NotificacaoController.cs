using GestaoResiduos.Models;
using GestaoResiduos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoResiduos.Controllers
{
    [ApiController]
    [Route("api/notificacoes")]
    public class NotificacoesController : ControllerBase
    {
        private readonly INotificacaoService _notificacaoService;

        public NotificacoesController(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EnviarNotificacao([FromBody] NotificacaoDto notificacaoDto)
        {
            var sucesso = await _notificacaoService.EnviarNotificacaoAsync(notificacaoDto);

            if (sucesso)
            {
                return Ok(new { mensagem = "Notificação enviada com sucesso!" });
            }
            else
            {
                return BadRequest(new { mensagem = "Falha ao enviar notificação." });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ObterNotificacoes(int pagina = 1, int tamanhoPagina = 10)
        {
            var notificacoes = await _notificacaoService.ObterNotificacoesAsync(pagina, tamanhoPagina);
            return Ok(notificacoes);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> AtualizarNotificacao(int id, [FromBody] NotificacaoDto notificacaoDto)
        {
            var sucesso = await _notificacaoService.AtualizarNotificacaoAsync(id, notificacaoDto);

            if (sucesso)
            {
                return Ok(new { mensagem = "Notificação atualizada com sucesso!" });
            }
            else
            {
                return NotFound(new { mensagem = $"Notificação com Id {id} não encontrada." });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> ExcluirNotificacao(int id)
        {
            var sucesso = await _notificacaoService.ExcluirNotificacaoAsync(id);

            if (sucesso)
            {
                return Ok(new { mensagem = "Notificação excluída com sucesso!" });
            }
            else
            {
                return NotFound(new { mensagem = $"Notificação com Id {id} não encontrada." });
            }
        }
    }
}
