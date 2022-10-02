using Microsoft.AspNetCore.Http;

public class FileService : IFileService
{
    public Task<string> SaveWithRandomName(IFormFile file, string? path)
    {
        var randomFileName = Path.GetRandomFileName().Replace('.', '_');
        var fileExtension = Path.GetExtension(file.FileName);

        var fileName = $"{randomFileName}{fileExtension}";

        return SaveFileToDiskAsync(file, fileName);
    }

    public async Task<string> SaveFileToDiskAsync(IFormFile file, string path)
    {
        var savingPath = GetSavingPath(path);

        await using var stream = File.Create(savingPath);
        await file.CopyToAsync(stream);

        return path;
    }

    private static string GetSavingPath(string path) => Path.Combine("wwwroot", path);
}