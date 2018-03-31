using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public abstract class IServer: MarshalByRefObject
    {
        public abstract bool Login(string nickname, string password, string ip, int port);
    }
}
