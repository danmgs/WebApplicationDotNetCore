using Api.Demo.Core.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Api.Demo.Core
{
    public class ElasticSearchClient<T> : 
        AbsractBaseElastic,
        ISearchClient<T> where T : class
    {
        public ElasticSearchClient(string endPointUrl, string indexName)
        {
            _client = OpenConnection(endPointUrl, indexName);
        }

        // add new record into elastic
        public bool Add(T item)
        {
            try
            {
                return _client.Index(item).Created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // add new record into elastic in an asynchronous manner
        public async Task<bool> AddAsync(T item)
        {
            try
            {
                var response = await _client.IndexAsync(item);
                return response.Created;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // add multiple records into elastic
        public long Add(List<T> items)
        {
            try
            {
                return _client.IndexMany(items).Took;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // add multiple records into elastic in an asynchronous manner
        public async Task<int> AddAsync(List<T> items)
        {
            try
            {
                var response = await _client.IndexManyAsync(items);
                return response.Items.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // get record from elastic using id
        public T Get(string id)
        {
            try
            {
                return _client.Get<T>(id).Source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // get record from elastic using id in an asynchronous manner
        public async Task<T> GetAsync(string id)
        {
            try
            {
                var response = await _client.GetAsync<T>(id);
                return response.Source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // update record into elastic
        public bool Update(T item)
        {
            try
            {
                var response = _client.Update(new DocumentPath<T>(item), u => u.Doc(item));

                if (response.Version > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // update record into elastic in an asynchronous manner
        public async Task<bool> UpdateAsync(T item)
        {
            try
            {
                var response = await _client.UpdateAsync(new DocumentPath<T>(item), u => u.Doc(item));

                if (response.Version > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete record from elastic
        public bool Delete(string id)
        {
            try
            {
                return _client.Delete(new DeleteRequest<T>(id)).Found;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete record from elastic in an asynchronous manner
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var response = await _client.DeleteAsync(new DeleteRequest<T>(id));
                return response.Found;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete multiple records from elastic
        public int Delete(List<T> items)
        {
            try
            {
                return _client.DeleteMany(items).Items.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete multiple records from elastic in an asynchronous manner
        public async Task<int> DeleteAsync(List<T> items)
        {
            try
            {
                var response = await _client.DeleteManyAsync(items);
                return response.Items.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // search records for mentioned field from elastic
        public List<T> Search(string searchText, int from, int size, Expression<Func<T, object>> fieldToSearchFrom)
        {
            try
            {
                var response = _client.Search<T>(s => s
                                         .From(from - 1) // default index = 0
                                         .Size(size)
                                         .Query(q => q.Match(mq => mq.Field(fieldToSearchFrom).Query(searchText)))
                                         );

                var debug = response.DebugInformation;
                log.Info(debug);

                return response.Documents.ToList(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // search records for mentioned field from elastic in an asynchronous manner
        public async Task<List<T>> SearchAsync(string searchText, int from, int size, Expression<Func<T, object>> fieldToSearchFrom)
        {
            try
            {
                var response = await _client.SearchAsync<T>(s => s
                                         .From(from - 1) // default index = 0
                                         .Size(size)
                                         .Query(q => q.Match(mq => mq.Field(fieldToSearchFrom).Query(searchText.ToLower())))
                                         );

                return response.Documents.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // search records for any field from elastic
        public List<T> Search(string searchText, int from, int size)
        {
            try
            {
                var response = _client.Search<T>(s => s
                                      .From(from - 1) // default index = 0
                                      .Take(size)
                                      .Query(qry => qry.Bool(b => b.Must(m => m.QueryString(qs => qs.DefaultField("_all").Query(searchText)))))
                                       );

                return response.Documents.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // search records for any field from elastic in an asynchronous manner
        public async Task<List<T>> SearchAsync(string searchText, int from, int size)
        {
            try
            {
                var response = await _client.SearchAsync<T>(s => s
                                           .From(from - 1) // default index = 0
                                           .Take(size)
                                           .Query(qry => qry.Bool(b => b.Must(m => m.QueryString(qs => qs.DefaultField("_all").Query(searchText)))))
                                           );

                return response.Documents.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
