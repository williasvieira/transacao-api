using Domain.Models;
using Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class SaldoRedisService : ISaldoCacheService
    {
        private string host = "localhost:6379";
        
        private readonly RedisClient Redis;

        public SaldoRedisService()
        {
            Redis = new RedisClient(host);
        }
        

        public async Task<Usuario> Add(Usuario usuario)
        {
           

            Redis.Set<Usuario>(usuario.IdUsuario, usuario);
            return usuario;
        }

        public Task<Usuario> AtualizarConta(Usuario usuario)
        {
            throw new NotImplementedException();
        }
        public Task<Usuario> getSaldo(string IdUsuario)
        {
            var client= Redis.Get<Usuario>(IdUsuario);

            return Task.FromResult(client);
        }
    }
}
