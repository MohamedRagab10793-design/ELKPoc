using Elastic.Clients.Elasticsearch;
using ELKPocApi.Common;
using ELKPocApi.Constants;
using ELKPocApi.Documents;
using ELKPocApi.Services.Contract;

namespace ELKPocApi.Services.Implementation;
public class LogElkService : BaseElasticSearchService<LogDocument, Guid>, ILogElkService<Guid>
{
    #region CTOR
    public LogElkService(IBaseElasticSearchClient baseElasticSearchClient)
    {
        _elasticsearchClient = baseElasticSearchClient.CreateElasticSearchClient();
        _defaultIndex = ElasticSearchIndices.LogIndex;
    }
    #endregion CTOR

    #region Methods
    public async Task<ElasticSearchPagedResultDto<LogDocument, Guid>> Get(ElasticSearchPagedResultRequestDto requestDto)
    {
        var totalCount = await GetCount(new CountRequestDescriptor<LogDocument>().Indices(_defaultIndex));
        requestDto.MaxResultCount = Math.Min(requestDto.MaxResultCount, ListingConstants.MaxResultCount);

        var searchRequestDescriptor = new SearchRequestDescriptor<LogDocument>()
                                    .Index(_defaultIndex)
                                    .Sort(s => s.Field(f => f.CreationTime, new FieldSort { Order = SortOrder.Desc }))
                                    .From(requestDto.SkipCount)
                                    .Size(requestDto.MaxResultCount);

        var searchResponse = await Get(searchRequestDescriptor);

        return new ElasticSearchPagedResultDto<LogDocument, Guid>(totalCount.Count, searchResponse.IsValidResponse ? searchResponse.Documents.ToList() : new List<LogDocument>());
    }

    public async Task<LogDocument> GetLog(Guid id)
    {
        var searchResponse = await Get(new SearchRequestDescriptor<LogDocument>()
                                     .Index(_defaultIndex)
                                     .Sort(s => s.Field(f => f.CreationTime, new FieldSort { Order = SortOrder.Desc }))
                                     .Query(q => q.QueryString(c => c.Query(id.ToString()).DefaultField(c => c.Id))));

        return searchResponse?.Documents?.FirstOrDefault();
    }

    public async Task<bool> Create(LogDocument document)
    {
        var insertResponse = await Insert(document);
        return insertResponse.IsValidResponse;
    }
    #endregion Methods
}
