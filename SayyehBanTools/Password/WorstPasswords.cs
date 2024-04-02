using System.Security.Cryptography;
using System.Text;

namespace SayyehBanTools.Password;

public class WorstPasswords
{

    public List<string> CommonPassword { get; set; }
    public WorstPasswords()
    {
        CommonPassword = new List<string>();
    }

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
/*
 طریقه استفاده از دستورمورد نظر
public class MyPasswordValidator : IPasswordValidator<User>
{
    private readonly IWebHostEnvironment _environment;
    private WorstPasswords worstPasswords;

    public MyPasswordValidator(IWebHostEnvironment environment)
    {
        _environment = environment;
        worstPasswords = new WorstPasswords();
    }


    public async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
    {
        string filePath = Path.Combine(_environment.WebRootPath, "file", "worst-passwords.txt");
        await worstPasswords.LoadCommonPasswords(filePath);

        string hashedPassword = worstPasswords.ComputeSha256Hash(password);

        if (worstPasswords.CommonPassword.Contains(hashedPassword))
        {
            return GetFailedIdentityResult();
        }

        return IdentityResult.Success;
    }

    private IdentityResult GetFailedIdentityResult()
    {
        return IdentityResult.Failed(new IdentityError
        {
            Code = "CommonPassword",
            Description = "پسورد شما قابل شناسایی توسط ربات های هکر است! لطفا یک پسورد قوی انتخاب کنید",
        });
    }
}
 */