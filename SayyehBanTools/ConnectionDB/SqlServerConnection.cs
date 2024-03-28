using SayyehBanTools.Encryptor;

namespace SayyehBanTools.ConnectionDB;

public class SqlServerConnection
{
    public static string ConnectionString(string DataSource,string InitialCatalog,string UserId,string Password, string initVector, string passPhrase)
    {
        string dataSource = StringEncryptor.Decrypt(DataSource, initVector, passPhrase);
        string initialCatalog = StringEncryptor.Decrypt(InitialCatalog, initVector, passPhrase);
        string userId = StringEncryptor.Decrypt(UserId, initVector, passPhrase);
        string password = StringEncryptor.Decrypt(Password, initVector, passPhrase);
        string connectionString = $"Data Source={dataSource};" +
                                 $"Initial Catalog={initialCatalog};" +
                                 $"User ID={userId};" +
                                 $"Password={password};" +
                                 "Connect Timeout=0;" +
                                 "Max Pool Size=20000;" +
                                 "Integrated Security=False;" +
                                 "Trust Server Certificate=True;";

        return connectionString;
    }
    public static string ConnectionString(string DataSource,string InitialCatalog,string UserId,string Password,short ConnectTimeout,int MaxPoolSize,bool IntegratedSecurity,bool TrustServerCertificate, string initVector, string passPhrase)
    {
        string dataSource = StringEncryptor.Decrypt(DataSource, initVector, passPhrase);
        string initialCatalog = StringEncryptor.Decrypt(InitialCatalog, initVector, passPhrase);
        string userId = StringEncryptor.Decrypt(UserId, initVector, passPhrase);
        string password = StringEncryptor.Decrypt(Password, initVector, passPhrase);
        string connectionString = $"Data Source={dataSource};" +
                                 $"Initial Catalog={initialCatalog};" +
                                 $"User ID={userId};" +
                                 $"Password={password};" +
                                 $"Connect Timeout={ConnectTimeout};" +
                                 $"Max Pool Size={MaxPoolSize};" +
                                 $"Integrated Security={IntegratedSecurity};" +
                                 $"Trust Server Certificate={TrustServerCertificate};";

        return connectionString;
    }
}
