/// <summary>
/// Encapsula la lógica de selección del notificador según la opción ingresada por el usuario.
/// </summary>
public sealed class NotificadorSelector
{
    /// <summary>
    /// Selecciona el notificador apropiado basado en la entrada del usuario.
    /// </summary>
    /// <param name="opcion">La opción seleccionada por el usuario.</param>
    /// <returns>Una instancia de INotificador o null si la opción es inválida.</returns>
    public INotificador? Seleccionar(string? opcion)
    {
        return opcion switch
        {
            "1" => new NotificadorEmail(),
            "2" => new NotificadorWhatsApp(),
            "3" => new NotificadorSMS(),
            _ => null
        };
    }
}
