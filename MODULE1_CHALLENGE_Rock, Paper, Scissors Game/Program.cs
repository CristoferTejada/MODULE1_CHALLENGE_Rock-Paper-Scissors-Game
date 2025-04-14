namespace MODULE1_CHALLENGE_Rock__Paper__Scissors_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            string[] historial = new string[100];
            int contadorHistorial = 0;

            do
            {
                MostrarMenu();
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        AdivinaNumero(historial, ref contadorHistorial);
                        break;
                    case 2:
                        JuegoPiedraPapelTijera(historial, ref contadorHistorial);
                        break;
                    case 3:
                        VerHistorial(historial, contadorHistorial);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresiona una tecla para volver al menú...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (opcion != 4);
        }

        static void AdivinaNumero(string[] historial, ref int contador)
        {
            Console.Clear();
            Console.WriteLine("🎯 Adivina el número (1 al 10)");

            Random rnd = new Random();
            int numeroSecreto = rnd.Next(1, 11);
            int intento, intentos = 0;

            do
            {
                Console.Write("Ingresa tu intento: ");
                while (!int.TryParse(Console.ReadLine(), out intento) || intento < 1 || intento > 10)
                {
                    Console.Write("Número inválido. Ingresa un número entre 1 y 10: ");
                }

                intentos++;

                if (intento < numeroSecreto)
                    Console.WriteLine("🔼 Muy bajo");
                else if (intento > numeroSecreto)
                    Console.WriteLine("🔽 Muy alto");
                else
                    Console.WriteLine($"✅ ¡Correcto! Lo lograste en {intentos} intentos");

            } while (intento != numeroSecreto);

            GuardarHistorial(historial, ref contador, $"Adivina el número: {intentos} intentos");
        }

    }
}
