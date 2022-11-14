using Domain.Models;
using Domain.StateClasses;
using Infra.Interfaces;
using Infra.Services;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class EstadoIdentificado : IEstadosTransacao
    {
        private readonly TransacaoMongoService TransacaoInfraService = new TransacaoMongoService();

        public async Task<int> ExecutarOperacao(Transacao transacao)
        {
            try
            {
                await TransacaoInfraService.RegistarTransacaoAsync(transacao);
            }
            catch (Exception e)
            {
                return 503;
            }

            transacao.Estado = new EstadoProcessado();

            return transacao.ExecutarOperacao().Result;
        }
    }
}
