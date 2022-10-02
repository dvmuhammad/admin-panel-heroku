using System.Security.AccessControl;
using AdminPanel.DataBase;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Services.Event;

public class EventService:IEventService
{
    private DataContext _context;
    private readonly IFileService _service;

    public EventService(DataContext context, IFileService service)
    {
        _context = context;
        _service = service;
    }

    private async Task<string?> SaveFile(IFormFile? file, string? name)
    {
        if (file == null) return null;

        return await _service.SaveWithRandomName(file, name);
    }
    
    public async Task<Domain.Entities.Event> CreateEvent(EventCreationRequest request)
    {
        var file1Path = await SaveFile(request.File1, request.File1?.Name);
        var file2Path = await SaveFile(request.File2, request.File2?.Name);
        var file3Path = await SaveFile(request.File3, request.File3?.Name);
        
        Domain.Entities.Event events =
            new()
            {
                Title = request.Title,
                Year = request.Year,
                Description = request.Description,
                PathIMG1 = file1Path,
                PathIMG2 = file2Path,
                PathIMG3 = file3Path
            };
        await _context.AddAsync(events);
        await _context.SaveChangesAsync();
        return events;
    }

    public Task<List<Domain.Entities.Event>> GetAllEvent()
    {
        return _context.Events.ToListAsync();
    }

    public async Task<Domain.Entities.Event?> DeleteById(int id)
    {
        var even = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

        if (even == null)
            throw new Exception();
        _context.Remove(even);
        await _context.SaveChangesAsync();
        return even;
    }

    public async Task<Domain.Entities.Event?> UpdateById(int id, EventUpdateRequest request)
    {
        var eventItem = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
        
        if (eventItem == null)
            throw new Exception();
        var file1Path = await SaveFile(request.File1, request.File1?.Name);
        var file2Path = await SaveFile(request.File2, request.File2?.Name);
        var file3Path = await SaveFile(request.File3, request.File3?.Name);
        eventItem.Title = request.Title;
        eventItem.Year = request.Year;
        eventItem.Description = request.Description;
        if (file1Path is not null)
            eventItem.PathIMG1 = file1Path;
        if (file2Path is not null)
            eventItem.PathIMG2 = file2Path;
        if (file3Path is not null)
            eventItem.PathIMG3 = file3Path;
        
        await _context.SaveChangesAsync();
        return eventItem;
    }
}