using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataCollections
{
    public class TransacaoDatabaseSettings : ITransacaoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TransacaoCollectionName { get; set; }

    }
}
