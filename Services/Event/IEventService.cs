using Domain.Models;

namespace Services.Event;

public interface IEventService
{
    Task <Domain.Entities.Event> CreateEvent(EventCreationRequest creationRequest);
    Task<List<Domain.Entities.Event>> GetAllEvent();
    Task<Domain.Entities.Event?> DeleteById(int id);
    Task<Domain.Entities.Event?> UpdateById(int id,EventCreationRequest creationRequest);
    
}