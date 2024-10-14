using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoResiduos.Data;
using GestaoResiduos.Models;
using GestaoResiduos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoResiduos.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly ApplicationDbContext _context;

        public NotificacaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EnviarNotificacaoAsync(NotificacaoDto notificacao)
        {
            _context.Notificacoes.Add(notificacao);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<NotificacaoDto>> ObterNotificacoesAsync(int pagina, int tamanhoPagina)
        {
            return await _context.Notificacoes
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();
        }

        public async Task<bool> AtualizarNotificacaoAsync(int id, NotificacaoDto notificacao)
        {
            var notificacaoExistente = await _context.Notificacoes.FindAsync(id);

            if (notificacaoExistente == null) return false;

            notificacaoExistente.Titulo = notificacao.Titulo;
            notificacaoExistente.Mensagem = notificacao.Mensagem;
            notificacaoExistente.DataEnvio = notificacao.DataEnvio;
            notificacaoExistente.Enviada = notificacao.Enviada;

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> ExcluirNotificacaoAsync(int id)
        {
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao == null) return false;

            _context.Notificacoes.Remove(notificacao);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
