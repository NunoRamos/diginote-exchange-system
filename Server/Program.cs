using Server.models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DiginoteSystemContext())
            {
                var user = new User {
                    Name = "Bernardo Belchior", Nickname = "bernardobelchior", Password = "password", Id = 1, Diginotes = new List<Diginote>(), Orders = new List<Order>() };

                var diginote = new Diginote { Id = 0, FacialValue = 1.0f, Owner = user };

                db.Users.Add(user);
                db.Diginotes.Add(diginote);
                db.SaveChanges();

                var query = from d in db.Diginotes
                            select d;

                foreach(var item in query)
                {
                    Console.WriteLine(item.FacialValue);
                }

                Console.ReadLine();
            }
        }
    }
}
