using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Resource.Resources.GET;
using MindWell_ResourcesServices.Resource.Resources.POST;
using MindWell_ResourcesServices.Resource.Services;

namespace MindWell_ResourcesServices.Resource.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ResourcesController : ControllerBase
{
    private readonly IResourceService _resourceService;
    private readonly NhsApiService _nhsApiService;
    private readonly IMapper _mapper;

    public ResourcesController(IResourceService resourceService, IMapper mapper, NhsApiService nhsApiService)
    {
        _resourceService = resourceService;
        _mapper = mapper;
        _nhsApiService = nhsApiService;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ResourceResource>> GetAllResources()
    {
        var resources = await _resourceService.ListAsync();
        var resourcesResource = _mapper.Map<IEnumerable<Domain.Models.Resource>, IEnumerable<ResourceResource>>(resources);
        return resourcesResource;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ResourceResource> GetResourceById(int id)
    {
        var resource = await _resourceService.GetResourceById(id);
        var resourceResource = _mapper.Map<Domain.Models.Resource, ResourceResource>(resource);
        return resourceResource;
    }

    [HttpPost("category")]
    public async Task<IActionResult> GetAllResourceByCategory([FromBody] ListAllResourcesByCategoryResource resource)
    {
        var resources = await _resourceService.ListAllResourcesByCategoryAsync(resource.Category);
        var resourcesResource = _mapper.Map<IEnumerable<Domain.Models.Resource>, IEnumerable<ResourceResource>>(resources);
        return Ok(resourcesResource);
    }
    
    [HttpPost("fetch-resources")]
    public async Task<IActionResult> FetchResources()
    {
        await _nhsApiService.FetchAndStoreResourcesAsync();
        return Ok();
    }
}