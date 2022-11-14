using Domain.Models;
using Domain.StateClasses;
using Infra.Services;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class EstadoProcessado : IEstadosTransacao
    {
        private readonly TransacaoMongoService TransacaoInfraService = new TransacaoMongoService();
        private readonly SaldoRedisService SaldoRedisService = new SaldoRedisService();
        public async Task<int> ExecutarOperacao(Transacao transacao)
        {

            if (transacao.IdTransacaoRelacionada == null)
            {
                var saldoAtualizado = await TransacaoInfraService.SaldoRecargaCompletaAsync(transacao.IdUsuario);
                try
                {
                    Usuario usuario = new Usuario(transacao.IdUsuario, transacao.Valor);

                    SaldoRedisService.AtualizarConta(usuario);
                }
                catch
                {
                    transacao.Estado = new EstadoSaldoNaoAtualizado();
                    return transacao.ExecutarOperacao().Result;
                }
            }

            return 200;
        }
    }
}
