namespace ELKPocApi.Common;
public class BaseElasticSearchDocument<TKey>
{
    public TKey Id { get; set; }
    public DateTime CreationTime { get; set; }
}
