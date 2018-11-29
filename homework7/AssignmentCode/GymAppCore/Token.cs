using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymAppCore
{
    public class Token
    {
        public string UserId { get; set; }
        public string AuthToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
