using System.Security.Cryptography;
using System.Text;

namespace SayyehBanTools.Password;

public class WorstPasswords
{
    public List<string> CommonPassword { get; set; }

    public async Task LoadCommonPasswords(string directFile)
    {
        if (CommonPassword.Count == 0)
        {
            using (StreamReader reader = new StreamReader(directFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    string hashedLine = ComputeSha256Hash(line);
                    CommonPassword.Add(hashedLine);
                }
            }
        }
    }

    public string ComputeSha256Hash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = sha256.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                builder.Append(hashedBytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
