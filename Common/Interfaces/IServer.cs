using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{ 
    public abstract class IServer: MarshalByRefObject
    {
        public abstract Tuple<int?, Exception> Login(string nickname, string password);

        public abstract Tuple<int?, Exception> Register(string name, string nickname, string password);

        public abstract Exception Logout(int id);
    }
}
