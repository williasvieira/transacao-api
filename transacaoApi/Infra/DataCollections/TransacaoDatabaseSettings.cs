using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataCollections
{
    public class TransacaoDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TransacaoCollectionName { get; set; }

    }
}
