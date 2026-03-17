namespace PagosPolimorfismo
{
    /// <summary>
    /// Implementación de pago en efectivo.
    /// </summary>
    public class PagoEfectivo : IPagoService
    {
        /// <inheritdoc />
        public bool ProcesarPago(decimal monto)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[EFECTIVO] Recibiendo {monto} en efectivo...");
            Console.WriteLine($"[EFECTIVO] Entregando cambio si es necesario.");
            Console.ResetColor();
            return true;
        }
    }
}
