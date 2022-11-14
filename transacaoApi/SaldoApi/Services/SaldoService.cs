using Microsoft.Extensions.Caching.Memory;
using SaldoApi.Interfaces;
using System.Threading.Tasks;
using System;
using Infra.Interfaces;

namespace SaldoApi.Services
{
    public class SaldoService : ISaldoService
    {
        private readonly ITransacaoInfraService TransacaoInfraService;
        private readonly IMemoryCache MemoryCache;
       
        public SaldoService(IMemoryCache memoryCache, ITransacaoInfraService transacaoInfraService)
        {
            MemoryCache = memoryCache;
            TransacaoInfraService = transacaoInfraService;  
        }

        public Task<double> EfetuarSaldo(string idUsuario)
        {
           
            
  
              var valor =  SaldoRecargaCompleta(idUsuario);
            return Task.FromResult(valor).Result;
        }
        private Task<double> SaldoRecargaCompleta(string id)
        {
          return  Task.FromResult(TransacaoInfraService.SaldoRecargaCompletaAsync(id)).Result;

            
        }
    }
}