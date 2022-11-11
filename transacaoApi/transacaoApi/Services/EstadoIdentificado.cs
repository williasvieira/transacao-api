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

       

        public Task<int> ExecutarOperacao(Transacao transacao)
        {
            transacao.IdTransacao = Guid.NewGuid().ToString(); 
            try
            {
                TransacaoInfraService.RegistarTransacao(transacao);

                return Task.FromResult(200);
            }
            catch (Exception e)
            {
                return Task.FromResult(503);
            }
            
            transacao.Estado = new EstadoProcessado();

            return transacao.ExecutarOperacao();
        }
    }
}
