using Microsoft.Data.SqlClient;
using BankTransfers.Domain.Entities;
using BankTransfers.Infrastructure.Data;

namespace BankTransfers.Infrastructure.Repositories;

public class CuentaRepository
{
    private readonly DatabaseConnection _dbConnection;

    public CuentaRepository()
    {
        _dbConnection = new DatabaseConnection();
    }

    public Cuenta? ObtenerPorId(int idCuenta)
    {
        using var connection = _dbConnection.GetConnection();
        connection.Open();

        var query = "SELECT IdCuenta, NumeroCuenta, IdCliente, Saldo, Estado, FechaCreacion FROM Cuentas WHERE IdCuenta = @IdCuenta";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@IdCuenta", idCuenta);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Cuenta(
                (int)reader["IdCuenta"],
                (string)reader["NumeroCuenta"],
                (int)reader["IdCliente"],
                (decimal)reader["Saldo"],
                (string)reader["Estado"],
                (DateTime)reader["FechaCreacion"]
            );
        }

        return null;
    }

    public void ActualizarSaldo(int idCuenta, decimal nuevoSaldo, SqlTransaction transaction, SqlConnection connection)
    {
        var query = "UPDATE Cuentas SET Saldo = @Saldo WHERE IdCuenta = @IdCuenta";
        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.AddWithValue("@Saldo", nuevoSaldo);
        command.Parameters.AddWithValue("@IdCuenta", idCuenta);
        command.ExecuteNonQuery();
    }
}