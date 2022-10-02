using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Event
{
    public int Id { get; set; }
    [Required] 
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string PathIMG1 { get; set; }
    public string? PathIMG2 { get; set; }
    public string? PathIMG3 { get; set; }
    
}