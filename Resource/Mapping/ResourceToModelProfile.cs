using AutoMapper;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Resource.Resources.POST;

namespace MindWell_ResourcesServices.Resource.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveResourceResource, Domain.Models.Resource>();
        CreateMap<SaveUserResourceResource, UserResource>();
    }
}