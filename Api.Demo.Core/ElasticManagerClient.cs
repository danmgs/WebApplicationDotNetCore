using Api.Demo.Core.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Demo.Core
{
    public class ElasticManagerClient :
        AbsractBaseElastic, 
        IManagerClient
    {
        private IndexSettings _indexSettings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 5 };

        public ElasticManagerClient(string endPointUrl, string indexName)
        {
            _client = OpenConnection(endPointUrl, indexName);
        }

        public bool CheckClusterHealth()
        {
            return _client.ClusterHealth().IsValid;
        }

        public bool CreateIndex(string indexName/*, IndexSettings indexSettings*/)
        {
            var indexConfig = new IndexState { Settings = _indexSettings };

            var res = _client.CreateIndex(indexName, c => c.InitializeUsing(indexConfig));
                
            return res.Acknowledged;
        }

        public bool CreateIndexWithMapping<T>(string indexName/*, IndexSettings indexSettings*/)
            where T : class
        {
            var indexConfig = new IndexState { Settings = _indexSettings };

            var res = _client.CreateIndex(indexName,
                                        c => c.InitializeUsing(indexConfig).Mappings(m => m.Map<T>(mp => mp.AutoMap())));

            return res.Acknowledged;
        }

        public bool DeleteIndex(string indexName)
        {
            var request = new DeleteIndexRequest(indexName);
            return _client.DeleteIndex(request).Acknowledged;
        }

        public bool IndexExists(string indexName)
        {
            return _client.IndexExists(indexName).Exists;
        }
    }
}
