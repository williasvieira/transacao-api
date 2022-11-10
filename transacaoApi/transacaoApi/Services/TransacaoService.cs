using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;
using transacaoApi.Models;
using transacaoApi.Models.Dtos;

namespace transacaoApi.Services
{
    public class TransacaoService : ITransacaoService
    {
        public Task<int> EfetuarTransacao(TransacaoDto dadosTransacao)
        {
            Transacao transacao = new Transacao(dadosTransacao.IdUsuario, dadosTransacao.Valor);

             return transacao.ExecutarOperacao();
            
        }
    }
}
