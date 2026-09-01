namespace BankTransfers.Domain.Entities;

public class Transferencia
{
    public int IdTransferencia { get; set; }
    public int IdCuentaOrigen { get; set; }
    public int IdCuentaDestino { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Estado { get; set; } = "Completada";
    public string? Observaciones { get; set; }
}