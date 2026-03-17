namespace PagosPolimorfismo
{
    /// <summary>
    /// Procesa pedidos usando cualquier método de pago que implemente IPagoService.
    /// </summary>
    public class ProcesadorDePedidos
    {
        private readonly IPagoService _servicioDePago;

        /// <summary>
        /// Inyección de dependencias por constructor.
        /// </summary>
        /// <param name="servicioDePago">El servicio de pago a utilizar.</param>
        public ProcesadorDePedidos(IPagoService servicioDePago)
        {
            _servicioDePago = servicioDePago;
        }

        /// <summary>
        /// Finaliza el pedido procesando el pago por el total indicado.
        /// </summary>
        /// <param name="total">Monto total del pedido.</param>
        public void FinalizarPedido(decimal total)
        {
            Console.WriteLine($"Iniciando proceso de compra por un total de ${total}...");

            bool resultado = _servicioDePago.ProcesarPago(total);

            if (resultado)
                Console.WriteLine("Pedido enviado al almacén. ¡Gracias por tu compra!");
            else
                Console.WriteLine("Pedido pendiente de pago. Por favor, intenta nuevamente.");
        }
    }
}
