using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{ 
    public abstract class IServer: MarshalByRefObject
    {
        public abstract bool Login(string nickname, string password);

        public abstract Tuple<int?, Exception> Register(string name, string nickname, string password);
    }
}
