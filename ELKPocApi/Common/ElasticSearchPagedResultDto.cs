namespace ELKPocApi.Common;

[Serializable]
public class ElasticSearchPagedResultDto<T> where T : BaseElasticSearchDocument
{
    public ElasticSearchPagedResultDto(long totalCount,List<T> items)
    {
        Items = items;
        TotalCount = totalCount;
    }
    public IReadOnlyList<T> Items { get; set; }
    public long TotalCount { get; set; }
}