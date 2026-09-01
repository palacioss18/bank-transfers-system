namespace BankTransfers.Domain.Entities;

public class Cuenta
{
    public int IdCuenta { get; set; }
    public string NumeroCuenta { get; set; } = string.Empty;
    public int IdCliente { get; set; }
    public decimal Saldo { get; private set; }
    public string Estado { get; set; } = "Activa";
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto a depositar debe ser mayor a cero.");

        if (Estado != "Activa")
            throw new InvalidOperationException("La cuenta no está activa.");

        Saldo += monto;
    }

    public void Debitar(decimal monto)
    {
        if (monto <= 0)
            throw new ArgumentException("El monto a debitar debe ser mayor a cero.");

        if (Estado != "Activa")
            throw new InvalidOperationException("La cuenta no está activa.");

        if (Saldo < monto)
            throw new InvalidOperationException("Saldo insuficiente para realizar la operación.");

        Saldo -= monto;
    }
}