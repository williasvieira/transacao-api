using Domain.Models;
using Domain.StateClasses;
using Infra.Services;
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
        
        private readonly SaldoRedisService SaldoRedisService= new SaldoRedisService();
        public  Task<int> ExecutarOperacao(Transacao transacao)
        {
            try
            {
                Usuario usuario = new Usuario(transacao.IdUsuario, transacao.Valor);

                SaldoRedisService.AtualizarConta(usuario);

                retryPolicy.ExecuteAsync(() => Task.FromResult(false));
            }
            catch (Exception e)
            {
                var transacaoDesfazimento = new Transacao(transacao.IdUsuario, transacao.IdTransacao);
                transacaoDesfazimento.Estado = new EstadoAndamento();
                return transacaoDesfazimento.ExecutarOperacao();
            }

            return Task.FromResult(200);
        }
    }
}
