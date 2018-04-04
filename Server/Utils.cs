using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Utils
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        public static string generateToken()
        {
            byte[] randomBytes = new byte[32];
            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }
    }
}
