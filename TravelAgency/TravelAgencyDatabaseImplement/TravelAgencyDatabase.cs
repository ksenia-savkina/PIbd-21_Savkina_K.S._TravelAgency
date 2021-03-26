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
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0372C8K\SQLEXPRESS01;Initial Catalog=TravelAgencyDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Travel> Travels { set; get; }

        public virtual DbSet<TravelComponent> TravelComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
    }
}
