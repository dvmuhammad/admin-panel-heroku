using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Domain.Models;

public class EventUpdateRequest
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Description { get; set; }
    
    public IFormFile? File1 { get; set; }
    public IFormFile? File2 { get; set; }
    public IFormFile? File3 { get; set; }
}