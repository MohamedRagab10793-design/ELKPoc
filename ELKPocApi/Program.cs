using ELKPocApi.Common;
using ELKPocApi.Services.Contract;
using ELKPocApi.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Elk
builder.Services.AddSingleton<IBaseElasticSearchClient, BaseElasticSearchClient>();
builder.Services.AddSingleton<ILogElkService, LogElkService>();
#endregion Elk


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.Run();
