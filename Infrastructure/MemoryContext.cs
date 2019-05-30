namespace teste_api.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using item_api.Models;

    public class MemoryContext : DbContext
    {
        public MemoryContext(){            
        }
        
        public MemoryContext(DbContextOptions<MemoryContext> options)
            : base(options)
        {
        }
 
        public DbSet<Item> Item { get; set; }
    }
}