namespace Backend.WebApi.Data
{
    using Backend.WebApi.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class DataContext : DbContext
    {
        public DbSet<Books> Books { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }                
    }
}
