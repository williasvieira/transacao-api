using Domain.Models;
using Domain.StateClasses;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class EstadoProcessado : IEstadosTransacao
    {
        public async Task<int> ExecutarOperacao(Transacao transacao)
        {
            //Aqui ele vai criar o acesso ao redis e tentar gravar na cache.

            if (transacao.IdTransacaoRelacionada != null)
            {
                //Chama o saldo recarga completa
                try
                {
                    var saldoAtualizado = await Task.FromResult(8675309);
                    //Using redis... pipipipopopo;
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
