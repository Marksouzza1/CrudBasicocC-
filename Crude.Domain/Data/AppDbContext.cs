
using Crud.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Crud.Service.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) 
            : base(options)
        {
            _configuration = configuration;

        }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
