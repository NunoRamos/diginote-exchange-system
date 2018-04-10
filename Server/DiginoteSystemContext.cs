using Server.Models;
using System.Data.Entity;

namespace Server
{
    class DiginoteSystemContext : DbContext
    {
        public DbSet<Diginote> Diginotes { get; set; }
        public DbSet<Order> Orders { get; set; }
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

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Diginote)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Diginote)
                .WithMany(d => d.Orders);
        }
    }
}
