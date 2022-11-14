using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ISaldoCacheService
    {
        Task<Usuario> AtualizarConta(Usuario usuario);
        Task<Usuario> Add(Usuario usuario);
    }
}
