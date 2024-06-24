using Microsoft.IdentityModel.Tokens;

namespace GenerateSecurityKey;
internal class JwtOptions
{
    public SecurityKey SecurityKey { get; set; }
}
