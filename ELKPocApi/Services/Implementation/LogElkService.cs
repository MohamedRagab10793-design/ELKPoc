using Elastic.Clients.Elasticsearch;
using ELKPocApi.Common;
using ELKPocApi.Constants;
using ELKPocApi.Documents;
using ELKPocApi.Services.Contract;

namespace ELKPocApi.Services.Implementation;

public class LogElkService : BaseElasticSearchService<LogELKDocument>, ILogElkService
{
    #region CTOR
    public LogElkService(IBaseElasticSearchClient baseElasticSearchClient)
    {
        _elasticsearchClient = baseElasticSearchClient.CreateElasticSearchClient();
        _defaultIndex = ElasticSearchIndices.LogIndex;
    }
    #endregion CTOR

    #region Methods
    public async Task<ElasticSearchPagedResultDto<LogELKDocument>> Get(ElasticSearchPagedResultRequestDto requestDto)
    {
        var totalCount = await GetCount(new CountRequestDescriptor<LogELKDocument>().Indices(_defaultIndex));

        requestDto.MaxResultCount = requestDto.MaxResultCount > ListingConstants.MaxResultCount ? ListingConstants.MaxResultCount : requestDto.MaxResultCount;

        var searchRequestDescriptor = new SearchRequestDescriptor<LogELKDocument>()
                                    .Index(_defaultIndex)
                                    .Sort(s => s.Field(f => f.CreationTime, new FieldSort { Order = SortOrder.Desc }))
                                    .From(requestDto.SkipCount)
                                    .Size(requestDto.MaxResultCount);

        var searchResponse = await Get(searchRequestDescriptor);

        return new ElasticSearchPagedResultDto<LogELKDocument>(totalCount.Count, searchResponse.IsValidResponse ? searchResponse.Documents.ToList() : []);
    }
    public async Task<LogELKDocument> GetLog(Guid id)
    {
        var searchResponse = await Get(new SearchRequestDescriptor<LogELKDocument>()
                                     .Index(_defaultIndex)
                                     .Sort(s => s.Field(f => f.CreationTime, new FieldSort { Order = SortOrder.Desc }))
                                     .Query(q => q.QueryString(c => c.Query(id.ToString()).DefaultField(c => c.Id))));
        return searchResponse?.Documents?.FirstOrDefault();
    }
    public async Task<bool> Create(LogELKDocument document)
    {
        var insertResponse = await Insert(document);
        return insertResponse.IsValidResponse;
    }
    #endregion Methods
}
