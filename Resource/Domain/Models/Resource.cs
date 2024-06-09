namespace MindWell_ResourcesServices.Resource.Domain.Models;

public class Resource
{
    public int Id { get; set; }
    public string Link { get; set; }
    public string Category { get; set; }
    
    public List<UserResource> UserResources { get; set; }
}