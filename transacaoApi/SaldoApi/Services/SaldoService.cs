using Microsoft.Extensions.Caching.Memory;
using SaldoApi.Interfaces;
using System.Threading.Tasks;
using System;

namespace SaldoApi.Services
{
    public class SaldoService : ISaldoService
    {
        private readonly IMemoryCache MemoryCache;
        private const string USUARIO_KEY = "USER";
        public SaldoService(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
        }

        public Task<int> EfetuarSaldo(int idUsuario)
        {
            Console.WriteLine(USUARIO_KEY + idUsuario);
            var s = USUARIO_KEY + idUsuario;
            if (MemoryCache.TryGetValue(USUARIO_KEY + idUsuario, out int saldo))
            {
                return Task.FromResult(saldo);
            }

            //var saldo = MemoryCache.GetOrCreate(USUARIO_KEY + idUsuario, entry =>
            //{
            //    entry.SlidingExpiration = TimeSpan.FromMinutes(2);
            //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            //    entry,

            //});

            return Task.FromResult(5);
        }
    }
}