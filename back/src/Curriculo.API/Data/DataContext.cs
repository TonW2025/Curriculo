using Microsoft.EntityFrameworkCore;
using Curriculo.API.Models;

namespace Curriculo.API.Data
{
    public class DataContext : DbContext   
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)    
        {
        }  

        public DbSet<Candidato> Candidatos { get; set; }
    }
}
