namespace PagosPolimorfismo
{
    /// <summary>
    /// Implementación de pago con tarjeta de crédito.
    /// </summary>
    public class PagoTarjetaCredito : IPagoService
    {
        /// <inheritdoc />
        public bool ProcesarPago(decimal monto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[TARJETA] Conectando con Visa/MasterCard...");
            Console.WriteLine($"[TARJETA] Debitando {monto} de la cuenta terminada en **** 1234.");
            Console.ResetColor();
            return true;
        }
    }
}
