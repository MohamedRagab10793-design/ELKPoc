namespace ELKPocApi.Common;

[Serializable]
public class ElasticSearchPagedResultRequestDto
{
    public int SkipCount { get; set; }
    public virtual int MaxResultCount { get; set; } = 10;
}
