using System;
using System.Data.Entity;

namespace Server
{
    class DiginoteSystemContext : DbContext
    {
        public DbSet<Diginote> Diginotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> Users { get; set; }

        public DiginoteSystemContext() : base(Environment.GetEnvironmentVariable("DATABASE_URL")) {
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
        }
    }
}
