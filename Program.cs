// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

const string privateKey =
    "{\"D\":\"sGE5oR1/6FVQSdibU6lFMtf6GEqUMspumEftk8ez8Eu7fk36Dw/hf2FYZPh7rPQJfev+vIFyjaI6OgkgTL2YpodBw/5eSTraT7KGyOUM942hRI8BGibMDAll2ZsG/cnPXE4ffVdjFxFqm6SSSLi/gTQKVqjbLxVRqCEiecfCZlk=\",\"DP\":\"5QajaOuDVDpnB4z/ngrCC0dhy45EAnjBWnGe0qrbao/V7IvfZYFqOr6eng4jwegtGkdDjTfaSbm2AgRhnl5lIQ==\",\"DQ\":\"xeUkeJQK5MfEkaU7W69fRShvcOK7uMtGYpi75nOvEgIx/1BkggcaX0qTYAvLpVGohba57OSa+29TOOXg39hNKQ==\",\"Exponent\":\"AQAB\",\"InverseQ\":\"EZ4oc+OEXm4MUPOD3ZRcXhLWIrnH2i2o1wU5tRnATQb5gi0VxbGFAAfRZo7qCGh/dQAwWi2ImQgbGkmXZN9iNg==\",\"Modulus\":\"425OSJX7DZNE1B0oqxznyzM/wc8gHIWAiuMbtgGCdoYt2FZu5S8OeNY+bXbH6E40Fx3FUFZ3h01f3yL/UHee6zX9iJuwxtqJqgQZlJGIJ9tI6IKT9mtaZaHzhoHD3+FRbNd1QvhH/Wh50y1TLwOeQOSW0WJi5sOjavFwtHOQmQ0=\",\"P\":\"/GHV6ra0CEFFXP7cKjHdPsidHIN56G59BI7zaiywrpJs8Oyyuw/W73CUD+VJAVwlwLmIqa7DMTE+LHe3a4Kqqw==\",\"Q\":\"5rDoHGFHh98cgvfO5hf7uNqp6F4wLJ7AOPhJ33e1250m25B5UTu+h+/D3mjI3u3Upb7T/iwBPR53VxY/X/nLJw==\"}\n\n";

const string publicKey =
    "\n{\"D\":null,\"DP\":null,\"DQ\":null,\"Exponent\":\"AQAB\",\"InverseQ\":null,\"Modulus\":\"425OSJX7DZNE1B0oqxznyzM/wc8gHIWAiuMbtgGCdoYt2FZu5S8OeNY+bXbH6E40Fx3FUFZ3h01f3yL/UHee6zX9iJuwxtqJqgQZlJGIJ9tI6IKT9mtaZaHzhoHD3+FRbNd1QvhH/Wh50y1TLwOeQOSW0WJi5sOjavFwtHOQmQ0=\",\"P\":null,\"Q\":null}\n\n";

Console.WriteLine("Hello, World!");
//KeyProvider();
var p = Encrypt("plainText");
var res = Decrypt(p);

Console.WriteLine("response is : " + res);


static string Encrypt(string plainText)
{
    RSACryptoServiceProvider rsa = new();
    var pubKey = JsonConvert.DeserializeObject<RSAParameters>(publicKey);
    rsa.ImportParameters(pubKey);

    var bytePlainText = Encoding.UTF8.GetBytes(plainText);

   var encrypted = rsa.Encrypt(bytePlainText,false);

   return Convert.ToBase64String(encrypted);
}

static string Decrypt(string cypherText)
{
    RSACryptoServiceProvider rsa = new();
    var priKey = JsonConvert.DeserializeObject<RSAParameters>(privateKey);
    rsa.ImportParameters(priKey);

    var cy = Convert.FromBase64String(cypherText);

    var decrypt = rsa.Decrypt(cy,false);

    return Encoding.UTF8.GetString(decrypt);
}

// static void KeyProvider()
// {
//     RSACryptoServiceProvider rsa = new();
//
//     var privateKey = rsa.ExportParameters(true);
//     var publicKey = rsa.ExportParameters(false);
//
//     var privateKeyJson = JsonConvert.SerializeObject(privateKey);
//     var publicKeyJson = JsonConvert.SerializeObject(publicKey);
// }