using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Program
    {
        private static bool running = true;

        static void Main()
        {
            while (running)
            {
                GameLoop();
            }
        }
        
        private static void GameLoop()
        {
            Console.Clear();
            Console.WriteLine(" -- TORRES DE HANOI --\n");

            // Menu pick
            int pickedOption = ShowMenu();
            if (pickedOption == 3)
            {
                running = false;
                return;
            }

            // Specify number of discs
            Console.WriteLine("Introduzca el número de discos, por favor: ");
            string keyStroke = Console.ReadLine();
            uint numDiscos;
            while (!UInt32.TryParse(keyStroke, out numDiscos) && keyStroke != "0")
            {
                Console.WriteLine("\nIntroduzca un número válido");
                keyStroke = Console.ReadLine();
            }
            Console.WriteLine("Has escogido " + numDiscos.ToString() + " discos");

            // Initialize stacks (rods)
            Pila ini = new Pila(numDiscos);
            Pila aux = new Pila();
            Pila fin = new Pila();

            // Hanoi solver
            Hanoi hanoiGame = new Hanoi();
            uint numMovements = 0;
            switch (pickedOption)
            {
                case 1:
                    numMovements = hanoiGame.iterativo(numDiscos, ini, aux, fin);
                    break;
                case 2:
                    numMovements = hanoiGame.recursivo(numDiscos, ini, aux, fin);
                    break;
                default:
                    break;
            }

            Console.WriteLine("Se ha resuelto en " + numMovements.ToString() + " movimientos");
            Console.ReadKey();  // Restart game upon hitting any key
        }

        private static int ShowMenu()
        {
            Console.WriteLine("1) Algoritmo iterativo.");
            Console.WriteLine("2) Algoritmo recursivo.");
            Console.WriteLine("3) Salir.");
            Console.Write("\r\nEscoja una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                default:
                    return 0;
            }
        }
    }
}