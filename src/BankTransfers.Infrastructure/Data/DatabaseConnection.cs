using Microsoft.Data.SqlClient;

namespace BankTransfers.Infrastructure.Data;

public class DatabaseConnection
{
    // Opción A: Si usás la instancia por defecto de Visual Studio (LocalDB)
    private readonly string _connectionString =
        @"Server=(localdb)\MSSQLLocalDB;Database=BankTransfersDB;Trusted_Connection=True;TrustServerCertificate=True;";

    // Opción B: Si tenés SQL Server Express instalado localmente, descomentá esta línea y comentá la de arriba:
    // private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=BankTransfersDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}