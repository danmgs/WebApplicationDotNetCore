using Nest;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Demo.Core.Interfaces
{
    public interface IManagerClient
    {
        bool CheckClusterHealth();

        bool CreateIndex(string indexName/*, IndexSettings indexSettings*/);

        bool CreateIndexWithMapping<T>(string indexName/*, IndexSettings indexSettings*/) where T : class;

        bool DeleteIndex(string indexName);

        bool IndexExists(string indexName);
    }
}
