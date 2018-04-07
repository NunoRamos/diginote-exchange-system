namespace Server.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DiginoteSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DiginoteSystemContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var user = new User
            {
                Name = "Administrador",
                Nickname = "admin",
                Password = "admin",
                Id = 1,
                Diginotes = new List<Diginote>(),
                Orders = new List<Order>()
            };

            var diginote = new Diginote { Id = 0, FacialValue = 1.0f, Owner = user };

            db.Users.Add(user);
            db.Diginotes.Add(diginote);
            db.SaveChanges();

        }
    }
}
