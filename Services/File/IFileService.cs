using Microsoft.AspNetCore.Http;

public interface IFileService
{
    Task<string> SaveFileToDiskAsync(IFormFile file, string path);
    Task<string> SaveWithRandomName(IFormFile file, string? path);
}
