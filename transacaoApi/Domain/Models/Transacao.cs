
using Domain.StateClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Threading.Tasks;



namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Transacao
    {

        [BsonId]
        public ObjectId IdTransacao { get; set; }

        [BsonElement("idUsario")]
        public string IdUsuario { get; set; }

        [BsonElement("valor")]
        public double Valor { get; set; }

        [BsonElement("idTransacaoRelacionada")]
        public ObjectId? IdTransacaoRelacionada { get; set; }

        [BsonIgnore]
        public IEstadosTransacao Estado { get; set; }
        public Transacao(string idUsuario, double valor)
        {
            IdUsuario = idUsuario;
            Valor = valor;
        }

        public Transacao(string idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Transacao(string idUsuario, ObjectId transacaoRelacionada)
        {
            IdUsuario = idUsuario;
            IdTransacaoRelacionada = transacaoRelacionada;
        }

        public Task<int> ExecutarOperacao()
        {
            return Estado.ExecutarOperacao(this);

        }
    }
}
