using ELKPocApi.Common;
using ELKPocApi.Documents;

namespace ELKPocApi.Services.Contract;

public interface ILogElkService<TKey>
{
    Task<ElasticSearchPagedResultDto<LogDocument, Guid>> Get(ElasticSearchPagedResultRequestDto requestDto);
    Task<LogDocument> GetLog(TKey id);
    Task<bool> Create(LogDocument document);
}