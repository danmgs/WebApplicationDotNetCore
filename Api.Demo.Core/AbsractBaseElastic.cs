using log4net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Demo.Core
{
    public abstract class AbsractBaseElastic
    {
        public ElasticClient _client;

        protected static readonly ILog log = LogManager.GetLogger(typeof(AbsractBaseElastic));

        public virtual ElasticClient OpenConnection(string endPointUrl, string indexName)
        {
            // Open Connection
            var url = new Uri(endPointUrl);
            var settings = new ConnectionSettings(url).DefaultIndex(indexName);
            _client = new ElasticClient(settings);

            return _client;
        }
    }
}
