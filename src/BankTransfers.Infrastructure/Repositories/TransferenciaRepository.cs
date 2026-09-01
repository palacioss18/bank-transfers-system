using Microsoft.Data.SqlClient;
using BankTransfers.Domain.Entities;

namespace BankTransfers.Infrastructure.Repositories;

public class TransferenciaRepository
{
    public void Registrar(Transferencia transferencia, SqlTransaction transaction, SqlConnection connection)
    {
        var query = @"INSERT INTO Transferencias (IdCuentaOrigen, IdCuentaDestino, Monto, Fecha, Estado, Observaciones) 
                      VALUES (@Origen, @Destino, @Monto, @Fecha, @Estado, @Observaciones)";

        using var command = new SqlCommand(query, connection, transaction);
        command.Parameters.AddWithValue("@Origen", transferencia.IdCuentaOrigen);
        command.Parameters.AddWithValue("@Destino", transferencia.IdCuentaDestino);
        command.Parameters.AddWithValue("@Monto", transferencia.Monto);
        command.Parameters.AddWithValue("@Fecha", transferencia.Fecha);
        command.Parameters.AddWithValue("@Estado", transferencia.Estado);
        command.Parameters.AddWithValue("@Observaciones", (object?)transferencia.Observaciones ?? DBNull.Value);

        command.ExecuteNonQuery();
    }
}