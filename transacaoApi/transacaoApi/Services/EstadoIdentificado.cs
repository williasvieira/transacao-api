using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;
using transacaoApi.Models;

namespace transacaoApi.Services
{
    public class EstadoIdentificado : IEstadosTransacao
    {
        public Task<int> ExecutarOperacao(Transacao transacao)
        {

            Console.WriteLine("Oi EstadoIdentificado");

            return null;
        }
    }
}
