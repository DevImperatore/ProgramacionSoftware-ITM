namespace PagosPolimorfismo
{
    /// <summary>
    /// Contrato: Cualquier cosa que quiera procesar un pago debe implementar esta interfaz.
    /// </summary>
    public interface IPagoService
    {
        /// <summary>
        /// Procesa el pago por el monto indicado.
        /// </summary>
        /// <param name="monto">Monto total a cobrar.</param>
        /// <returns>True si el pago fue exitoso, false en caso contrario.</returns>
        bool ProcesarPago(decimal monto);
    }
}
