namespace PagosPolimorfismo
{
    /// <summary>
    /// Implementación de pago con Bitcoin.
    /// </summary>
    public class PagoBitcoin : IPagoService
    {
        /// <inheritdoc />
        public bool ProcesarPago(decimal monto)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"[BITCOIN] Conectando con la red de Bitcoin...");
            Console.WriteLine($"[BITCOIN] Debitando {monto} en BTC de tu wallet.");
            Console.ResetColor();
            return true;
        }
    }
}
