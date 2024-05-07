using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{   
    /// <summary>
    /// This code solves the scaffold error when creating controllers with views
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<SpareInventoryDbContext>
    {
 
        public SpareInventoryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpareInventoryDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-JQK5P3D\\SQLEXPRESS;Initial Catalog=SpareInventory;Integrated Security=True ;Encrypt=False");

            return new SpareInventoryDbContext(optionsBuilder.Options);
        }
    }
}
