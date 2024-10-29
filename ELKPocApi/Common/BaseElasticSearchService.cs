using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;

namespace ELKPocApi.Common;
public class BaseElasticSearchService<T> where T : BaseElasticSearchDocument
{
    #region Props
    protected string _defaultIndex;
    protected ElasticsearchClient _elasticsearchClient;
    #endregion Props

    #region Get
    protected async Task<GetResponse<T>> Get(Guid id) => await _elasticsearchClient.GetAsync<T>(_defaultIndex, id);
    protected async Task<SearchResponse<T>> Get(SearchRequestDescriptor<T> descriptor) => await _elasticsearchClient.SearchAsync(descriptor);
    #endregion Get

    #region Count
    protected async Task<CountResponse> GetCount(CountRequestDescriptor<T> countRequestDescriptor) => await _elasticsearchClient.CountAsync(countRequestDescriptor);
    #endregion Count

    #region Insert
    protected async Task<IndexResponse> Insert(T t) => await _elasticsearchClient.IndexAsync(t, _defaultIndex);
    protected async Task<BulkResponse> Insert(List<T> list) => await _elasticsearchClient.IndexManyAsync(list, _defaultIndex);
    #endregion Insert

    #region Delete
    protected async Task<DeleteResponse> Remove(Guid id) => await _elasticsearchClient.DeleteAsync(_defaultIndex, id);
    protected async Task<DeleteByQueryResponse> Remove(DeleteByQueryRequestDescriptor<T> deleteRequest) => await _elasticsearchClient.DeleteByQueryAsync(deleteRequest);
    protected async Task<DeleteIndexResponse> RemoveAllDocAtIndex() => await _elasticsearchClient.Indices.DeleteAsync(_defaultIndex);
    #endregion Delete

}
