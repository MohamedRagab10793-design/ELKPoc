using ELKPocApi.Common;
using ELKPocApi.Documents;
using ELKPocApi.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ELKPocApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogElkController : ControllerBase
{
    private readonly ILogElkService _logElkService;

    public LogElkController(ILogElkService logElkService)
    {
        _logElkService = logElkService;
    }

    [HttpGet]
    public async Task<ElasticSearchPagedResultDto<LogELKDocument>> Get(ElasticSearchPagedResultRequestDto requestDto)
        => await _logElkService.Get(requestDto);

    [HttpGet("{id}")]
    public async Task<LogELKDocument> GetLog(Guid id)
        => await _logElkService.GetLog(id);

    [HttpPost]
    public async Task<bool> Create()
        => await _logElkService.Create(new LogELKDocument { Id = Guid.NewGuid(), CreationTime = DateTime.Now });

    [HttpDelete]
    public async Task<bool> Delete(Guid id)
        => await _logElkService.Delete(id);
}
