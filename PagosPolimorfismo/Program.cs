using PagosPolimorfismo;

decimal totalCompra = 150000m;

Console.WriteLine("--- BIENVENIDO AL E-COMMERCE ITM ---");
Console.WriteLine("Seleccione su método de pago:");
Console.WriteLine("1. Tarjeta de Crédito");
Console.WriteLine("2. Nequi");
Console.WriteLine("3. Efectivo");
Console.WriteLine("4. Bitcoin");
Console.Write("Opción: ");

string? opcion = Console.ReadLine();

IPagoService metodoSeleccionado = opcion switch
{
    "1" => new PagoTarjetaCredito(),
    "2" => new PagoNequi(),
    "3" => new PagoEfectivo(),
    "4" => new PagoBitcoin(),
    _   => new PagoEfectivo()
};

if (opcion is not ("1" or "2" or "3" or "4"))
    Console.WriteLine("Opción no válida. Se usará Efectivo por defecto.");

Console.WriteLine("\n--- PROCESANDO ---");

var procesador = new ProcesadorDePedidos(metodoSeleccionado);
procesador.FinalizarPedido(totalCompra);
