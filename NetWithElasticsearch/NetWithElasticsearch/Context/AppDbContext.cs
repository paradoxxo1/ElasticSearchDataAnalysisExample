using Microsoft.EntityFrameworkCore;

namespace NetWithElasticsearch.Context;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-0E4KP6A\\SQLEXPRESS;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    public DbSet<Travel> Travels { get; set; }
}

public sealed class Travel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}