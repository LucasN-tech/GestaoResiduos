using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoResiduos.Models;

namespace GestaoResiduos.Services.Interfaces
{
    public interface INotificacaoService
    {
        Task<bool> EnviarNotificacaoAsync(NotificacaoDto notificacao);
        Task<IEnumerable<NotificacaoDto>> ObterNotificacoesAsync(int pagina, int tamanhoPagina);
        Task<bool> AtualizarNotificacaoAsync(int id, NotificacaoDto notificacao);
        Task<bool> ExcluirNotificacaoAsync(int id);
    }
}
