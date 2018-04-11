using Server.Models;
using System.Data.Entity;

namespace Server
{
    class DiginoteSystemContext : DbContext
    {
        public DbSet<Diginote> Diginotes { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public DiginoteSystemContext() : base("diginotes")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasRequired(c => c.PurchaseOrder)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasRequired(c => c.SellOrder)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SellOrder>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("SellOrders");
            });

            modelBuilder.Entity<PurchaseOrder>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("PurchaseOrders");
            });

            modelBuilder.Entity<SellOrder>()
                .HasRequired(o => o.Diginote)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);
        }
    }
}
