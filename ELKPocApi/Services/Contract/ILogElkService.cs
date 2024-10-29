using ELKPocApi.Common;
using ELKPocApi.Documents;

namespace ELKPocApi.Services.Contract;

public interface ILogElkService
{
    Task<ElasticSearchPagedResultDto<LogELKDocument>> Get(ElasticSearchPagedResultRequestDto requestDto);
    Task<LogELKDocument> GetLog(Guid id);
    Task<bool> Create(LogELKDocument document);
}
