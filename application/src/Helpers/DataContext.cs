using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Phrase.Entities;


namespace Phrase.Helpers
{
    public class DataContext : DbContext
    {
     // protected readonly IConfiguration Configuration;


        public DataContext(DbContextOptions<DataContext>opt) : base(opt)
        {

        }

        public DbSet<Palindrom> Palindroms { get; set; }
    }
}