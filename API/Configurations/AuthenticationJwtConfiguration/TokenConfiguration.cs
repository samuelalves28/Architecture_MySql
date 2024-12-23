using System.Text;

namespace API.Configurations.AuthenticationJwtConfiguration;
public class TokenConfiguration
{
    public string IssuerSigningKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpirationMinutes { get; set; }

    public byte[] IssuerSigningKeyByte => Encoding.ASCII.GetBytes(IssuerSigningKey);
    public DateTime ExpiresUtcNow => DateTime.UtcNow.AddMinutes(ExpirationMinutes);
}