using MapplicsEjercicio1Consola;

var input = ObtenerInput();

while (input != "S")
{
    Console.WriteLine("\n===================================\n");
    MostrarResultado(input);
    Console.WriteLine("\n===================================");
    Console.WriteLine("Ingrese S para salir");
    Console.WriteLine("===================================\n");

    input = ObtenerInput();
}

static void MostrarResultado(string input)
{
    var palabraInvertida = Metodos.InversionDePalabra(input);
    bool esCapicua = Metodos.DeterminacionDeCapicua(input);
    int cantidadDeVocales = Metodos.ContarVocales(input);

    Console.WriteLine(palabraInvertida);

    if (esCapicua)
    {
        Console.WriteLine("La palabra es capicúa");
    }
    else
    {
        Console.WriteLine("La palabra NO es capicúa");
    }

    Console.WriteLine($"Cantidad de vocales: {cantidadDeVocales}");
}

static string ObtenerInput()
{
    Console.Write("Ingrese una palabra: ");
    var input = Console.ReadLine();

    while (string.IsNullOrEmpty(input))
    {
        Console.Write("Ingrese una palabra: ");
        input = Console.ReadLine();
    }

    return input;
}