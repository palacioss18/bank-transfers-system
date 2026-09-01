using Microsoft.Data.SqlClient;

namespace BankTransfers.Infrastructure.Data;

public class DatabaseConnection
{
    private readonly string _connectionString =
        "Server=localhost;Database=BankTransfersDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}