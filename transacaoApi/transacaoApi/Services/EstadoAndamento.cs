
using Domain.Models;
using Domain.StateClasses;
using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;


namespace transacaoApi.Services
{
    public class EstadoAndamento : IEstadosTransacao
    {
        public async Task<int> ExecutarOperacao(Transacao transacao)
        {
            Console.WriteLine("OI EstadoAndamento");
            //var usarioValido = await Task.FromResult(casss.BuscarUsario(transacao.IdUsuario));

            //Aqui vai ter que ter um trycatch...
            var usuarioValido = await Task.FromResult(true);

            if (!usuarioValido)
            {
                return 401;
            }

            if (transacao.IdTransacaoRelacionada != null)
            {
                //Aqui também teria que ter um trycatch...
                //Obter o valor da transacao original para inverter o valor
            }

            
            transacao.Estado = new EstadoIdentificado();

            return transacao.ExecutarOperacao().Result;
        }
    }
}
