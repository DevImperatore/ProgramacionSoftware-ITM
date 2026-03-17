namespace PagosPolimorfismo
{
    /// <summary>
    /// Implementación de pago con Nequi.
    /// </summary>
    public class PagoNequi : IPagoService
    {
        /// <inheritdoc />
        public bool ProcesarPago(decimal monto)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[NEQUI] Conectando con Nequi...");
            Console.WriteLine($"[NEQUI] Debitando {monto} de tu cuenta Nequi.");
            Console.ResetColor();
            return true;
        }
    }
}
