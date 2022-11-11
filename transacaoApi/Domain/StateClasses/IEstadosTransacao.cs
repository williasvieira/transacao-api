using System.Threading.Tasks;
using Domain.Models;

namespace Domain.StateClasses
{
    public interface IEstadosTransacao
    {

        public  Task<int> ExecutarOperacao(Transacao transacao);
    }
}
