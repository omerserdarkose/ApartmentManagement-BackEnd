using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Extensions;
using ApartmentManagement.Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace ApartmentManagement.Core.Utilities.Security.JWT
{
    public class JWTHelper : ITokenHelper
    {
        private IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public JWTHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user, List<Claim> userClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreatJwtSecurityToken(_tokenOptions, user, signingCredentials, userClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        private JwtSecurityToken CreatJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<Claim> userClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                claims: SetClaims(user, userClaims)
            );

            return jwt;
        }

        private IEnumerable<System.Security.Claims.Claim> SetClaims(User user, List<Claim> userClaims)
        {
            var claims = new List<System.Security.Claims.Claim>();

            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(userClaims.Select(x => x.Name).ToArray());

            return claims;
        }
    }
}
