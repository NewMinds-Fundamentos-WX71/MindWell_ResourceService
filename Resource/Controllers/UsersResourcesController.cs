using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Resource.Resources.GET;

namespace MindWell_ResourcesServices.Resource.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersResourcesController : ControllerBase
{
    private readonly IUserResourceService _userResourceService;
    private readonly IMapper _mapper;

    public UsersResourcesController(IUserResourceService userResourceService, IMapper mapper)
    {
        _userResourceService = userResourceService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<UserResourceResource>> GetAllUserResources()
    {
        var resources = await _userResourceService.ListAsync();
        var resourcesResource = _mapper.Map<IEnumerable<Domain.Models.UserResource>, IEnumerable<UserResourceResource>>(resources);
        return resourcesResource;
    }
    
    [HttpGet("{id:int}")]
    public async Task<UserResourceResource> GetUserResourceById(int id)
    {
        var resource = await _userResourceService.GetUserResourceById(id);
        var resourceResource = _mapper.Map<Domain.Models.UserResource, UserResourceResource>(resource);
        return resourceResource;
    }
    
    [HttpGet("user/{userId:int}")]
    public async Task<IEnumerable<UserResourceResource>> GetAllUserResourcesByUserId(int userId)
    {
        var resources = await _userResourceService.ListAllUserResourcesByUserIdAsync(userId);
        var resourcesResource = _mapper.Map<IEnumerable<Domain.Models.UserResource>, IEnumerable<UserResourceResource>>(resources);
        return resourcesResource;
    }
    
    [HttpGet("resource/{resourceId:int}")]
    public async Task<IEnumerable<UserResourceResource>> GetAllUserResourcesByResourceId(int resourceId)
    {
        var resources = await _userResourceService.ListAllUserResourcesByResourceIdAsync(resourceId);
        var resourcesResource = _mapper.Map<IEnumerable<Domain.Models.UserResource>, IEnumerable<UserResourceResource>>(resources);
        return resourcesResource;
    }
}