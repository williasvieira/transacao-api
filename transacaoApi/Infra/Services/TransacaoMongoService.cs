using Domain.Models;
using Infra.DataCollections;
using Infra.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class TransacaoMongoService: ITransacaoInfraService
    {
        private readonly IMongoCollection<Transacao> TransacaoCollection;

        
        public TransacaoMongoService()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TransacaoInfra");
            TransacaoCollection = database.GetCollection<Transacao>("Transacao");
        }
        private async Task<List<Transacao>> GetListTransacao(string idUsuario) =>
            await TransacaoCollection.Find(x => x.IdUsuario == idUsuario).ToListAsync();

        private async Task<Transacao> GetTransacaoId(ObjectId idTransacao) =>
                await TransacaoCollection.Find(x => x.IdTransacao.Equals(idTransacao)).FirstOrDefaultAsync();
        private async Task CreateTransacao(Transacao transacao) =>
            await TransacaoCollection.InsertOneAsync(transacao);

        public async Task RegistarTransacaoAsync(Transacao transacao)
        {
            await CreateTransacao(transacao);
        }

        public async Task<double> GetValorTransacao(ObjectId idTransacao)
        {
            var transacao = await GetTransacaoId(idTransacao);
            if (transacao != null)
            {
                return transacao.Valor;
            }

            throw new Exception("Falhow");
        }

        public async Task<double> SaldoRecargaCompletaAsync(string idUsuario)
        {
            var transacoesUsuario = await GetListTransacao(idUsuario);
            var saldoCompleto = transacoesUsuario.Sum(x => x.Valor);
            return saldoCompleto;
        }

        
    }
    
}
