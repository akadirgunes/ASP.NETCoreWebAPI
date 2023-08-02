using CityAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<CityEntity> CityEntities { get; set; }
        public DbSet<UserEntity> userEntities { get; set; }
    }
}
