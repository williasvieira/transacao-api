using Domain.Models;
using Domain.Models.Dtos;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class TransacaoService : ITransacaoService
    {
        public Task<int> EfetuarTransacao(TransacaoDto dadosTransacao)
        {
            Transacao transacao = new Transacao(dadosTransacao.IdUsuario, dadosTransacao.Valor);
            transacao.Estado = new EstadoAndamento();
             return transacao.ExecutarOperacao();
            
        }
    }
}
