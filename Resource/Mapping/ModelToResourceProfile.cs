using AutoMapper;
using MindWell_ResourcesServices.Resource.Domain.Models;
using MindWell_ResourcesServices.Resource.Resources.GET;

namespace MindWell_ResourcesServices.Resource.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Resource, ResourceResource>();
        CreateMap<UserResource, UserResourceResource>();
    }
}