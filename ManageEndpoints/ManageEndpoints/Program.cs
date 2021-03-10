using ManageEndpoints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEndpoints
{
    class Program
    {
        /// <summary>
        /// Método principal
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------------------");
            Console.WriteLine("Gerenciador de Endpoints\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Escolha uma operação para ser realizada:\n");
            Console.WriteLine("\t1 - Cadastrar");
            Console.WriteLine("\t2 - Editar");
            Console.WriteLine("\t3 - Excluir");
            Console.WriteLine("\t4 - Listar todos");
            Console.WriteLine("\t5 - Listar por número de série");

            Console.Write("\nInforme o número referente a operação desejada: ");

            // Use a switch statement to do the math.
            switch (Console.ReadLine())
            {
                case "1":
                    Insert();
                    break;
                case "2":
                    Console.WriteLine($"Editar");
                    break;
                case "3":
                    Console.WriteLine($"Excluir");
                    break;
                case "4":
                    Console.WriteLine($"Listar todos");
                    break;
                case "5":
                    Console.WriteLine($"Listar por número de série");
                    break;
                default:
                    Console.WriteLine("Operação inválida!");
                    break;
            }
            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();
        }

        /// <summary>
        /// Cadastrar endpoint
        /// </summary>
        private static void Insert()
        {
            Console.Clear();
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Cadastro\r");
            Console.WriteLine("--------------------------------------");

            var newEndPoint = new Endpoint();

            Console.WriteLine("\nPor favor, preencha abaixo os campos solicitados:");

            Console.Write("\nNúmero da série do terminal: ");
            newEndPoint.TerminalSerialNumber = Console.ReadLine();

            Console.Write("\nID do modelo medidor: ");
            newEndPoint.IdMeterModel = int.Parse(Console.ReadLine());

            Console.Write("\nNúmero do medidor: ");
            newEndPoint.MeterNumber = int.Parse(Console.ReadLine());

            Console.Write("\nVersão do firmware do medidor: ");
            newEndPoint.MeterFirmwareVersion = Console.ReadLine();

            Console.Write("\nMudança de estado: ");
            newEndPoint.ChangeState = int.Parse(Console.ReadLine());

            Validate(newEndPoint);
        }

        private static string Validate(Endpoint enpoint)
        {
            return string.Empty;
        }
    }
}
