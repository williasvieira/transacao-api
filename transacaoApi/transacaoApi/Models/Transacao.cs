using System;
using System.Threading.Tasks;
using transacaoApi.Interfaces;
using transacaoApi.Services;

namespace transacaoApi.Models
{
    public class Transacao
    {
        public IEstadosTransacao Estado { get; set; }
        public int IdUsuario { get; set; }
        public double Valor { get; set; }
        public Guid IdTransacao { get; set; }
        public Guid IdTransacaoRelacionada { get; set; }

        public Transacao(IEstadosTransacao estado, int idUsuario, double valor, Guid idTransacao, Guid idTransacaoRelacionada)
        {
            Estado = estado;
            IdUsuario = idUsuario;
            Valor = valor;
            IdTransacao = idTransacao;
            IdTransacaoRelacionada = idTransacaoRelacionada;
        }

        public Transacao(int idUsuario, double valor )
        {
            IdUsuario = idUsuario;
            Valor = valor;
            Estado = new EstadoAndamento();
        }
        public Task<int> ExecutarOperacao()
        {
            return  Estado.ExecutarOperacao(this);

        }
    }
}
