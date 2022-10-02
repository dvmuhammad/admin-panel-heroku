using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.DataBase;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
    }
    public DbSet<Event>Events { get; set; }
    public DbSet<User>Users { get; set; }
}