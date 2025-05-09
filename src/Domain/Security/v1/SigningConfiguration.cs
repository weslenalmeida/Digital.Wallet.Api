using CrossCutting.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Domain.Security.v1
{
    public class SigningConfiguration
    {
        public SecurityKey? SecurityKey { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public SigningConfiguration()
        {
            SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.TokenConfiguration.Key!));
            SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}