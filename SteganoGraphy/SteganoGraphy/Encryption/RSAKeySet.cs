using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganoGraphy.Encryption
{
    public class RSAKeySet
    {
        public long N { get; set; }
        public long E { get; set; }
        public long D { get; set; }
    }
}
