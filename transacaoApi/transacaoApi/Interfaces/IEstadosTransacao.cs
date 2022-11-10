using System.Threading.Tasks;
using transacaoApi.Models;

namespace transacaoApi.Interfaces
{
    public interface IEstadosTransacao
    {

        public  Task<int> ExecutarOperacao(Transacao transacao);
    }
}
