using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Interfaces
{
    public interface ITransacaoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string TransacaoCollectionName { get; set; }
    }
}
