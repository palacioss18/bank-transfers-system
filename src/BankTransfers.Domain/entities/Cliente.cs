namespace BankTransfers.Domain.Entities;

public class Cliente
{
    public int IdCliente { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Documento { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public List<Cuenta> Cuentas { get; set; } = new();
}