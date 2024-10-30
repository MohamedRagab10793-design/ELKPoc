using ELKPocApi.Common;
using ELKPocApi.Documents;
using ELKPocApi.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ELKPocApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LogElkController : ControllerBase
{
    private readonly ILogElkService<Guid> _logElkService;

    public LogElkController(ILogElkService<Guid> logElkService)
    {
        _logElkService = logElkService;
    }

    [HttpGet]
    public async Task<ElasticSearchPagedResultDto<LogDocument, Guid>> Get([FromQuery] ElasticSearchPagedResultRequestDto requestDto)
        => await _logElkService.Get(requestDto);

    [HttpGet("{id}")]
    public async Task<LogDocument> GetLog([FromRoute] Guid id)
        => await _logElkService.GetLog(id);

    [HttpPost]
    public async Task<bool> Create()
        => await _logElkService.Create(new LogDocument { Id = Guid.NewGuid(), CreationTime = DateTime.Now });
}
