using Server.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class DiginoteSystemContext : DbContext
    {
        public DbSet<Diginote> diginotes { get; set; }
    }
}
