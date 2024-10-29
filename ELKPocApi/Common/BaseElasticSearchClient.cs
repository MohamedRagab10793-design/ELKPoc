using Elastic.Clients.Elasticsearch;

namespace ELKPocApi.Common;
public class BaseElasticSearchClient : IBaseElasticSearchClient
{
    #region Props 
    private readonly ElasticsearchClient _elasticsearchClient;
    #endregion Props

    #region Ctor
    public BaseElasticSearchClient(IConfiguration configuration) => _elasticsearchClient = new ElasticsearchClient(new Uri(@$"{configuration.GetSection("ElasticSearch:Url").Value}"));
    #endregion Ctor
    public ElasticsearchClient CreateElasticSearchClient()
    => _elasticsearchClient;
}
