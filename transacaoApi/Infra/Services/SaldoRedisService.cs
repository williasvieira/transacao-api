using Domain.Models;
using Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class SaldoRedisService : ISaldoCacheService
    {
        private readonly IDistributedCache Redis;

        public SaldoRedisService(IDistributedCache redis)
        {
            Redis = redis;
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            
            await Redis.SetStringAsync(usuario.IdUsuario.ToString(), JsonSerializer.Serialize(usuario));
            return usuario;
        }

        public Task<Usuario> AtualizarConta(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
