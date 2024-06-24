using GenerateSecurityKey;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

int Keysize = 0;

do
{
    Console.Clear();
    Console.WriteLine($"Minimum size is 32. ");
    Console.Write($"Enter your key Size: ");
    string Size = Console.ReadLine()!;

    if(int.TryParse(Size, out Keysize))
    {
        if (Keysize > 31)
        {
            JwtOptions jwtOptions = new JwtOptions
            {
                SecurityKey = GenerateSecurityKey(Keysize)
            };
            Console.WriteLine($"Generated SecurityKey: {jwtOptions.SecurityKey}");
            Console.WriteLine("Whould you like to continues? YES/NO");
            string continues = Console.ReadLine();
            if (continues.Equals("YES", StringComparison.InvariantCultureIgnoreCase)) Keysize = 0;
        }
    }
} while (Keysize < 32);

static SecurityKey GenerateSecurityKey(int keySize)
{
    byte[] key = new byte[keySize];
    using RandomNumberGenerator rng = RandomNumberGenerator.Create();
    rng.GetBytes(key);
    return new SymmetricSecurityKey(key);
}
