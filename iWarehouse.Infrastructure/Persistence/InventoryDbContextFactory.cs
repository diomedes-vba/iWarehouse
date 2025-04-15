using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace iWarehouse.Infrastructure;

public class InventoryDbContextFactory : IDesignTimeDbContextFactory<InventoryDbContext>
{
    public InventoryDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../iWarehouse.WebApi"))
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
        var connectionString = configuration.GetConnectionString("InventoryConnectionString");
        
        optionsBuilder.UseSqlServer(connectionString);
        
        return new InventoryDbContext(optionsBuilder.Options);
    }
}