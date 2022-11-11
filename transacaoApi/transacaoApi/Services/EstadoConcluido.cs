using Domain.Models;
using Domain.StateClasses;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;

namespace transacaoApi.Services
{
    public class EstadoConcluido : IEstadosTransacao
    {
        public Task<int> ExecutarOperacao(Transacao transacao)
        {
            Console.WriteLine("Oi EstadoConcluido");
            return null;
        }
    }
}
