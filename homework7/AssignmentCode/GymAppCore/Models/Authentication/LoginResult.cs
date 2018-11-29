using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymAppCore.Models.Authentication
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public List<LoginError> Errors { get; set; }
        public Token Token { get; set; }
    }
}
