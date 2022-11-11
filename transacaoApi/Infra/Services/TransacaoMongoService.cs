using Domain.Models;
using Infra.DataCollections;
using Infra.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class TransacaoMongoService: ITransacaoInfraService
    {
        private readonly IMongoCollection<Transacao> TransacaoCollection;

        public TransacaoMongoService()
        {

        }
        public TransacaoMongoService(IOptions<TransacaoDatabaseSettings> transacaoService)
        {
            var mongoClient = new MongoClient(transacaoService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(transacaoService.Value.DatabaseName);
            
            TransacaoCollection = mongoDatabase.GetCollection<Transacao>(transacaoService.Value.TransacaoCollectionName);

            


        }
        public async Task<List<Transacao>> GetListTransacao(int idUsuario) =>
            await TransacaoCollection.Find(x => x.IdUsuario == idUsuario).ToListAsync();

        public async Task<Transacao> GetTransacaoId(string idTransacao) =>
                await TransacaoCollection.Find(x => x.Equals(idTransacao)).FirstOrDefaultAsync();
        public async Task CreateTransacao(Transacao transacao) =>
            await TransacaoCollection.InsertOneAsync(transacao);

        public void RegistarTransacao(Transacao transacao)
        {
            CreateTransacao(transacao);
        }

        public double GetValorTransacao(string idTransacao)
        {
            throw new NotImplementedException();
        }

        public double SaldoRecargaCompleta(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
    
}
