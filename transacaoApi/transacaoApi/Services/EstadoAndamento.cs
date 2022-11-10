using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;
using transacaoApi.Models;

namespace transacaoApi.Services
{
    public class EstadoAndamento : IEstadosTransacao
    {
        public async Task<int> ExecutarOperacao(Transacao transacao)
        {
            Console.WriteLine("OI EstadoAndamento");
            //var usarioValido = await Task.FromResult(casss.BuscarUsario(transacao.IdUsuario));
            var usuarioValido = await Task.FromResult(true);

            if (!usuarioValido)
            {
                return 401;
            }
            transacao.IdTransacao = Guid.NewGuid();
            transacao.Estado = new EstadoIdentificado();

            return transacao.ExecutarOperacao().Result;  
            
           
        }
    }
}
