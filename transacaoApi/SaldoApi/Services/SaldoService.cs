using Microsoft.Extensions.Caching.Memory;
using SaldoApi.Interfaces;
using System.Threading.Tasks;
using System;
using Infra.Interfaces;
using Domain.Models;
using Infra.Services;

namespace SaldoApi.Services
{
    public class SaldoService : ISaldoService
    {
        private readonly TransacaoMongoService TransacaoInfraService = new TransacaoMongoService();
        private readonly IMemoryCache MemoryCache;
       private readonly SaldoRedisService SaldoRedisService = new SaldoRedisService();
        public SaldoService(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
            
        }

        public Task<double> EfetuarSaldo(string idUsuario)
        {
           if(MemoryCache.TryGetValue(idUsuario, out double saldo))
            {
                return Task.FromResult(saldo);
            }
            var usuario = GetSaldo(idUsuario).Result;

            if( usuario != null)
            {
                MemoryCache.Set(idUsuario, usuario.Saldo);
                return Task.FromResult(usuario.Saldo);
            }
            else
            {
                var valor = SaldoRecargaCompleta(idUsuario).Result ;

                Usuario user = new Usuario(idUsuario, valor);
                AtualizarConta(user);
                MemoryCache.Set(idUsuario, valor);
                return Task.FromResult(valor);
            }
  
             
           
        }
        private Task<double> SaldoRecargaCompleta(string id)
        {
          return  Task.FromResult(TransacaoInfraService.SaldoRecargaCompletaAsync(id)).Result;

            
        }
        private Task<Usuario> GetSaldo(string idUsuario)
        {
            return Task.FromResult(SaldoRedisService.GetSaldo(idUsuario)).Result;
        }
        private void AtualizarConta(Usuario usuario)
        {
            SaldoRedisService.AtualizarConta(usuario);
        }
    }
}