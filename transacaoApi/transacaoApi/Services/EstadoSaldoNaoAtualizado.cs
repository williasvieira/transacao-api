using Domain.Models;
using Domain.StateClasses;
using Polly;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class EstadoSaldoNaoAtualizado : IEstadosTransacao
    {
        private readonly IAsyncPolicy retryPolicy =
            Policy.Handle<Exception>()
            .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(i * 2));

        public Task<int> ExecutarOperacao(Transacao transacao)
        {
            try
            {
                retryPolicy.ExecuteAsync(() => Task.FromResult(true));
            }
            catch (Exception e)
            {
                var transacaoDesfazimento = new Transacao(transacao.IdUsuario, transacao.IdTransacao);
                return transacaoDesfazimento.ExecutarOperacao();
            }

            return Task.FromResult(200);
        }
    }
}
