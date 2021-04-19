
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Entity;

namespace CinemaApp.DAL
{
    public class AppContext : DbContext
    {
        public DbSet<Film> Film { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCard { get; set; }
        
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();   // создаем базу данных при первом обращении
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=tcp:sharps.database.windows.net,1433;Initial Catalog=sharps;Persist Security Info=False;User ID=grisha;Password=g.89091259328;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
