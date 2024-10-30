using ELKPocApi.Common;
using ELKPocApi.Services.Contract;
using ELKPocApi.Services.Implementation;

namespace ELKPocApi;

public static class ElasticSearchDependencyInjection
{
    public static IServiceCollection AddElasticSearchConfigurations(this IServiceCollection services)
    {
        #region Elk
        services.AddSingleton<IBaseElasticSearchClient, BaseElasticSearchClient>();
        services.AddScoped<ILogElkService<Guid>, LogElkService>();
        #endregion Elk
        return services;
    }
}
