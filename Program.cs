Console.Title = "Calculadora Segura ITM";
var colorOriginal = Console.ForegroundColor;

try
{
    Console.WriteLine("--- CALCULADORA SEGURA ITM v1.0 ---");
    Console.WriteLine();

    // Leer y validar primer número
    Console.Write("Ingrese el primer número: ");
    var input1 = Console.ReadLine();
    if (!double.TryParse(input1, out var numeroUno))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: La entrada no es un número válido.");
        return;
    }

    // Leer y validar segundo número
    Console.Write("Ingrese el segundo número: ");
    var input2 = Console.ReadLine();
    if (!double.TryParse(input2, out var numeroDos))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: La entrada no es un número válido.");
        return;
    }

    // Leer operación
    Console.Write("Ingrese la operación (+, -, *, /): ");
    var operacionInput = Console.ReadLine();
    var operacion = string.IsNullOrWhiteSpace(operacionInput)
        ? '\0'
        : operacionInput.Trim()[0];

    double resultado;
    switch (operacion)
    {
        case '+':
            resultado = numeroUno + numeroDos;
            break;
        case '-':
            resultado = numeroUno - numeroDos;
            break;
        case '*':
            resultado = numeroUno * numeroDos;
            break;
        case '/':
            if (numeroDos == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operación no permitida: No se puede dividir entre cero.");
                return;
            }
            resultado = numeroUno / numeroDos;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Opción no válida. Reinicie el programa.");
            return;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine($"RESULTADO: {numeroUno} {operacion} {numeroDos} = {resultado}");
}
finally
{
    Console.ForegroundColor = colorOriginal;
    Console.WriteLine();
    Console.WriteLine("Presione cualquier tecla para salir...");
    Console.ReadKey(intercept: true);
}
