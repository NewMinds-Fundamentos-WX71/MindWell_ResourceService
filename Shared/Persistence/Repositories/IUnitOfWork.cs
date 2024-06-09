namespace MindWell_ResourcesServices.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}