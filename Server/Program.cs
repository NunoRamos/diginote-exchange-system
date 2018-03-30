using Server.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DiginoteSystemContext())
            {
                var diginote = new Diginote { Id = 0, FacialValue = 1.0f };
                db.diginotes.Add(diginote);
                db.SaveChanges();

                var query = from d in db.diginotes
                            select d;

                foreach(var item in query)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }
    }
}
