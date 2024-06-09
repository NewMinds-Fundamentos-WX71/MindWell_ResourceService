namespace MindWell_ResourcesServices.Resource.Domain.Models;

public class UserResource
{
    public int Id { get; set; }
    public int User_Id { get; set; }
    
    public int Resource_Id { get; set; }
    public Resource Resource { get; set; }
}