using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ITransacaoInfraService
    {
        public void RegistarTransacao(Transacao transacao);
        public double GetValorTransacao(string idTransacao);

        public double SaldoRecargaCompleta(int idUsuario);

    }
}
