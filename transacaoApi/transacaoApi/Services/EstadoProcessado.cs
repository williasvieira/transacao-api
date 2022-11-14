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

        public async Task<int> ExecutarOperacao(Transacao transacao)
        {

            if (transacao.IdTransacaoRelacionada == null)
            {
                var saldoAtualizado = await TransacaoInfraService.SaldoRecargaCompletaAsync(transacao.IdUsuario);
                try
                {
                    //Aqui voce coloca o redis pra salvar na cache. Se der exceção, ele vai pro
                    // estado de não atualizado
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
