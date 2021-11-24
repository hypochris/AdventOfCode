using System.Security.Cryptography;
using System.Text;

var secret = "ckczppom";

var checksum = "aaaaaa";

var count = 1;
while(checksum[..6] != "000000")
{
    checksum = GetMD5Hash(secret + count);

    if(count % 100 == 0)
        Console.WriteLine($"{count} - {checksum}");

    count++;
}
Console.WriteLine(count-1);

static string GetMD5Hash(string text)
{
    using var md5 = MD5.Create();

    byte[] computedHash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

    StringBuilder sBuilder = new();

        for (int i = 0; i < computedHash.Length; i++)
        {
            sBuilder.Append(computedHash[i].ToString("x2"));
        }
    return sBuilder.ToString();
}