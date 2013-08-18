using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFrameworkTest.Models.Mapping;

namespace EntityFrameworkTest.Models
{
    public partial class パズルドラゴンズContext : DbContext
    {
        static パズルドラゴンズContext()
        {
            Database.SetInitializer<パズルドラゴンズContext>(null);
        }

        public パズルドラゴンズContext()
            : base("Name=パズルドラゴンズContext")
        {
        }

        public DbSet<モンスター> モンスター { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new モンスターMap());
        }
    }
}
