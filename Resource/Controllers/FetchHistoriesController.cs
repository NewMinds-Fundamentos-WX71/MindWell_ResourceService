using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Resource.Resources.GET;
using MindWell_ResourcesServices.Resource.Resources.PUT;

namespace MindWell_ResourcesServices.Resource.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class FetchHistoriesController : ControllerBase
{
    private readonly IFetchHistoryService _fetchHistoryService;
    private readonly IMapper _mapper;

    public FetchHistoriesController(IFetchHistoryService fetchHistoryService, IMapper mapper)
    {
        _fetchHistoryService = fetchHistoryService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<FetchHistoryResource> GetFetchHistory()
    {
        var fetchHistorie = await _fetchHistoryService.GetFetchHistory();
        var fetchHistoriesResource = _mapper.Map<Domain.Models.FetchHistory, FetchHistoryResource>(fetchHistorie);
        return fetchHistoriesResource;
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFetchHistory([FromBody] UpdateFetchHistoryResource fetchHistoryResource)
    {
        var fetchHistory = _mapper.Map<UpdateFetchHistoryResource, Domain.Models.FetchHistory>(fetchHistoryResource);
        await _fetchHistoryService.UpdateFetchHistory(fetchHistory);
        return Ok();
    }
}