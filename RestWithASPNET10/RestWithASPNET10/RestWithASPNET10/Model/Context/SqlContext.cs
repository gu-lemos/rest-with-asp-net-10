using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET10.Model.Context
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<Person> Persons { get; set; }
    }
}
