
using Domain.StateClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;



namespace Domain.Models
{
    public class Transacao
    {
        public IEstadosTransacao Estado { get; set; }

        [BsonElement("IdTransacao")]
        public string IdTransacao { get; set; }

        [BsonElement("idUsario")]
        public int IdUsuario { get; set; }

        [BsonElement("valor")]
        public double Valor { get; set; }

        [BsonElement("idTransacaoRelacionada")]
        public string IdTransacaoRelacionada { get; set; }

        public Transacao(IEstadosTransacao estado, int idUsuario, double valor, string idTransacao, string idTransacaoRelacionada)
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
        }
        public Transacao(int idUsuario, string idTransacao)
        {
            IdUsuario = idUsuario;
            IdTransacaoRelacionada = idTransacao;
        }
        public Task<int> ExecutarOperacao()
        {
            return  Estado.ExecutarOperacao(this);

        }
    }
}
