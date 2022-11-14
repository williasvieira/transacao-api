using System.Threading.Tasks;

namespace SaldoApi.Interfaces
{
    public interface ISaldoService
    {
        public Task<double> EfetuarSaldo(string idUsuario);
    }
}
