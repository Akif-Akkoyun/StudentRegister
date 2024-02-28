using Microsoft.EntityFrameworkCore;
using OgrenciBilgi.Api.Data.Entities;

namespace OgrenciBilgi.Api.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext>options):base(options) { }

    }
}
