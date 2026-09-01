using BankTransfers.Infrastructure.Services;

Console.WriteLine("=== SISTEMA DE TRANSFERENCIAS BANCARIAS ===");

var servicio = new TransferenciaService();

try
{
    Console.Write("Ingrese ID Cuenta Origen: ");
    int origen = int.Parse(Console.ReadLine()!);

    Console.Write("Ingrese ID Cuenta Destino: ");
    int destino = int.Parse(Console.ReadLine()!);

    Console.Write("Ingrese Monto a transferir: ");
    decimal monto = decimal.Parse(Console.ReadLine()!);

    Console.WriteLine("\nProcesando transferencia en base de datos...");
    servicio.RealizarTransferencia(origen, destino, monto, "Transferencia desde consola C#");

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("¡Transferencia realizada con éxito!");
    Console.ResetColor();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nError en la operación: {ex.Message}");
    Console.ResetColor();
}

Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadKey();