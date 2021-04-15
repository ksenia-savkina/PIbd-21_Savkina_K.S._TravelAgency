using Microsoft.EntityFrameworkCore;
using TravelAgencyDatabaseImplement.Models;

namespace TravelAgencyDatabaseImplement
{
    public class TravelAgencyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-7MR3DNA6\SQLEXPRESS;Initial Catalog=TravelAgencyNewDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Travel> Travels { set; get; }

        public virtual DbSet<TravelComponent> TravelComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Client> Clients { set; get; }

        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}
