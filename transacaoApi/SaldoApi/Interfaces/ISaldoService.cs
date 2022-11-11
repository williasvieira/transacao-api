using System.Threading.Tasks;

namespace SaldoApi.Interfaces
{
    public interface ISaldoService
    {
        public Task<int> EfetuarSaldo(int idUsuario);
    }
}
