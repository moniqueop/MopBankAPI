using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Client> Clients => Set<Client>();
    }
}
