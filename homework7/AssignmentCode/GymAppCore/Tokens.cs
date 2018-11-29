using GymAppCore.Models.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymAppCore
{
    public class TokenGenerator
    {
        public static async Task<Token> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions)
        {
            var token = await Generate(identity, jwtFactory, userName, jwtOptions);

            return token;
        }

        public static async Task<string> GenerateToken(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions)
        {
            var token = await Generate(identity, jwtFactory, userName, jwtOptions);
            return token.AuthToken;
        }

        private static async Task<Token> Generate(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions)
        {
            var token = new Token
            {
                UserId = identity.Claims.Single(c => c.Type == "id").Value,
                AuthToken = await jwtFactory.GenerateEncodedToken(userName, identity),
                ExpiresIn = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return token;
        }
    }
}
