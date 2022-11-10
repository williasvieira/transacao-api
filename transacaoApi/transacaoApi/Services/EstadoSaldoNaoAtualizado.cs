using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;
using transacaoApi.Models;

namespace transacaoApi.Services
{
    public class EstadoSaldoNaoAtualizado : IEstadosTransacao
    {
        public Task<int> ExecutarOperacao(Transacao transacao)
        {
            Console.WriteLine("Oi EstadoSaldoNaoAtualizado");
            return null;
        }
    }
}
