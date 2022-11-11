
using Domain.Models.Dtos;
using System.Threading.Tasks;


namespace transacaoApi.Interfaces
{
    public interface ITransacaoService
    {
        public Task<int> EfetuarTransacao(TransacaoDto dadosTransacao);
    }
}
