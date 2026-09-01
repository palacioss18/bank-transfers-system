using Microsoft.Data.SqlClient;
using BankTransfers.Domain.Entities;
using BankTransfers.Infrastructure.Data;
using BankTransfers.Infrastructure.Repositories;

namespace BankTransfers.Infrastructure.Services;

public class TransferenciaService
{
    private readonly DatabaseConnection _dbConnection;
    private readonly CuentaRepository _cuentaRepository;
    private readonly TransferenciaRepository _transferenciaRepository;

    public TransferenciaService()
    {
        _dbConnection = new DatabaseConnection();
        _cuentaRepository = new CuentaRepository();
        _transferenciaRepository = new TransferenciaRepository();
    }

    public void RealizarTransferencia(int idCuentaOrigen, int idCuentaDestino, decimal monto, string? observaciones = null)
    {
        if (idCuentaOrigen == idCuentaDestino)
            throw new ArgumentException("La cuenta de origen y destino no pueden ser la misma.");

        using var connection = _dbConnection.GetConnection();
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            var cuentaOrigen = _cuentaRepository.ObtenerPorId(idCuentaOrigen)
                ?? throw new KeyNotFoundException("Cuenta origen no encontrada.");

            var cuentaDestino = _cuentaRepository.ObtenerPorId(idCuentaDestino)
                ?? throw new KeyNotFoundException("Cuenta destino no encontrada.");

            // Dominio valida saldo suficiente y estado activo
            cuentaOrigen.Debitar(monto);
            cuentaDestino.Depositar(monto);

            // Persistencia en base de datos dentro de la misma transacción
            _cuentaRepository.ActualizarSaldo(cuentaOrigen.IdCuenta, cuentaOrigen.Saldo, transaction, connection);
            _cuentaRepository.ActualizarSaldo(cuentaDestino.IdCuenta, cuentaDestino.Saldo, transaction, connection);

            var transferencia = new Transferencia
            {
                IdCuentaOrigen = idCuentaOrigen,
                IdCuentaDestino = idCuentaDestino,
                Monto = monto,
                Fecha = DateTime.Now,
                Estado = "Completada",
                Observaciones = observaciones
            };

            _transferenciaRepository.Registrar(transferencia, transaction, connection);

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}