namespace MODULE1_CHALLENGE_Rock__Paper__Scissors_Game    
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            string[] historial = new string[100];
            string[,] ranking = new string[100, 3];
            int contadorHistorial = 0;
            int contadorRanking = 0;

            do
            {
                MostrarMenu();
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case 1:
                        AdivinaNumero(historial, ranking, ref contadorHistorial, ref contadorRanking);
                        break;
                    case 2:
                        JuegoPiedraPapelTijera(historial, ranking, ref contadorHistorial, ref contadorRanking);
                        break;
                    case 3:
                        VerHistorial(historial, contadorHistorial);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    case 5:
                        VerRanking(ranking, contadorRanking);
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

        static void MostrarMenu()
        {
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1. Jugar Adivina el número");
            Console.WriteLine("2. Jugar Piedra, Papel o Tijera");
            Console.WriteLine("3. Ver historial de partidas");
            Console.WriteLine("4. Salir");
            Console.WriteLine("5. Ver ranking de partidas");
            Console.Write("Elige una opción: ");
        }

        static int LeerOpcionMenu()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 1 || valor > 5)
            {
                Console.Write("Entrada inválida. Ingresa una opción válida (1-5): ");
            }
            return valor;
        }

        static void AdivinaNumero(string[] historial, string[,] ranking, ref int contador, ref int contadorRank)
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

            string mensaje = $"Adivina el número: {intentos} intentos";
            GuardarHistorial(historial, ref contador, mensaje);
            GuardarRanking(ranking, ref contadorRank, "Adivina el número", "Ganaste", $"{intentos} intentos");
        }

        static void JuegoPiedraPapelTijera(string[] historial, string[,] ranking, ref int contador, ref int contadorRank)
        {
            Console.Clear();
            Console.WriteLine("✊✋✌️ Piedra, Papel o Tijera");

            string[] opciones = { "Piedra", "Papel", "Tijera" };
            Random rnd = new Random();
            int eleccionPC = rnd.Next(0, 3);

            Console.WriteLine("Elige tu opción:");
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i]}");
            }

            int eleccionUsuario;
            while (!int.TryParse(Console.ReadLine(), out eleccionUsuario) || eleccionUsuario < 1 || eleccionUsuario > 3)
            {
                Console.Write("Opción inválida. Elige 1, 2 o 3: ");
            }

            string jugador = opciones[eleccionUsuario - 1];
            string pc = opciones[eleccionPC];

            Console.WriteLine($"Tú elegiste: {jugador}");
            Console.WriteLine($"La PC eligió: {pc}");

            string resultado = "";

            if (jugador == pc)
                resultado = "Empate";
            else if ((jugador == "Piedra" && pc == "Tijera") ||
                     (jugador == "Papel" && pc == "Piedra") ||
                     (jugador == "Tijera" && pc == "Papel"))
                resultado = "Ganaste";
            else
                resultado = "Perdiste";

            Console.WriteLine($"Resultado: {resultado}");

            GuardarHistorial(historial, ref contador, $"Piedra/Papel/Tijera: {resultado}");
            GuardarRanking(ranking, ref contadorRank, "Piedra/Papel/Tijera", resultado, "");
        }


        static void GuardarHistorial(string[] historial, ref int contador, string mensaje)
        {
            if (contador < historial.Length)
            {
                historial[contador] = mensaje;
                contador++;
            }
        }

        static void GuardarRanking(string[,] ranking, ref int contador, string juego, string resultado, string detalle)
        {
            if (contador < ranking.GetLength(0))
            {
                ranking[contador, 0] = juego;
                ranking[contador, 1] = resultado;
                ranking[contador, 2] = detalle;
                contador++;
            }
        }

        static void VerHistorial(string[] historial, int contador)
        {
            Console.Clear();
            Console.WriteLine("📜 Historial de partidas:");
            if (contador == 0)
            {
                Console.WriteLine("No hay partidas registradas.");
            }
            else
            {
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"- {historial[i]}");
                }
            }
        }

        static void VerRanking(string[,] ranking, int contador)
        {
            Console.Clear();
            Console.WriteLine("🏆 Ranking de partidas:");

            if (contador == 0)
            {
                Console.WriteLine("No hay datos en el ranking.");
            }
            else
            {
                Console.WriteLine("Juego		Resultado	Detalle");
                Console.WriteLine("-----------------------------------------");
                for (int i = 0; i < contador; i++)
                {
                    Console.WriteLine($"{ranking[i, 0]}	{ranking[i, 1]}		{ranking[i, 2]}");
                }
            }
        }
    }
}
