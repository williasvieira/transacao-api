using Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ITransacaoInfraService
    {
        public Task RegistarTransacaoAsync(Transacao transacao);
        public Task<double> GetValorTransacao(ObjectId idTransacao);

        public Task<double> SaldoRecargaCompletaAsync(string idUsuario);

    }
}
