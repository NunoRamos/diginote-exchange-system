namespace Server.Migrations
{
    using global::Server.models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiginoteSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DiginoteSystemContext context)
        {
            User user = new User
            {
                Name = "admin",
                Nickname = "admin",
                Password = "admin",
            };

            context.Users.AddOrUpdate(user);

            for (int i = 1; i <= 10000; i++)
            {
                context.Diginotes.AddOrUpdate(new Diginote
                {
                    FacialValue = 1.0f,
                    Owner = user,
                    Order = null
                });
            }
        }
    }
}
