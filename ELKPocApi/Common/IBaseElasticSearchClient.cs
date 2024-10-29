using Elastic.Clients.Elasticsearch;

namespace ELKPocApi.Common;
public interface IBaseElasticSearchClient
{
    ElasticsearchClient CreateElasticSearchClient();
}
