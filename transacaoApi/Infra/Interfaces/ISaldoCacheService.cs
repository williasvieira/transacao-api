using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ISaldoCacheService
    {
        public void AtualizarConta(Usuario usuario);
        public Task<Usuario> GetSaldo(string usuario);
    }
}
