using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ISaldoCacheService
    {
        public Task<Usuario> AtualizarConta(Usuario usuario);
        public Task<Usuario> Add(Usuario usuario);
        public Task<Usuario> getSaldo(string usuario);
    }
}
