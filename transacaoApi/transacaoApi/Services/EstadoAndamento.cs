
using Domain.Models;
using Domain.StateClasses;
using Infra.Services;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class EstadoAndamento : IEstadosTransacao
    {
        private readonly TransacaoMongoService TransacaoInfraService = new TransacaoMongoService();
        private readonly SaldoRedisService  SaldoRedisService = new SaldoRedisService();
        public async Task<int> ExecutarOperacao(Transacao transacao)
        {
            var usuarioValido = SaldoRedisService.BuscarUsuario(transacao.IdUsuario);

            if (!usuarioValido)
            {
                return 401;
            }

            if (transacao.IdTransacaoRelacionada != null)
            {
                try
                {
                    var valorDaTransacao = await TransacaoInfraService.GetValorTransacao(transacao.IdTransacaoRelacionada.Value);
                    transacao.Valor = (valorDaTransacao * -1);
                }
                catch
                {
                    return 503;
                }
            }


            transacao.Estado = new EstadoIdentificado();

            return transacao.ExecutarOperacao().Result;
        }
    }
}
