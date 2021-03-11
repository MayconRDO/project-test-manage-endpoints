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
            ViewMenu();

            //var newEndpoint = new Endpoint();

            //Console.Write("\nID do modelo medidor: ");
            //newEndpoint.IdMeterModel = ValidateNumber();

            //Console.WriteLine($"\n{newEndpoint.IdMeterModel}");

            Console.ReadKey();
        }

        private static void ViewMenu()
        {
            Console.WriteLine("\n----------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints\r");
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("\nEscolha uma operação para ser realizada:\n");
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
                    Console.Clear();
                    ViewInsert();
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
                    Console.Clear();
                    Console.WriteLine("\nOperação inválida!");
                    ViewMenu();
                    break;
            }
        }

        /// <summary>
        /// Cadastrar endpoint
        /// </summary>
        private static void ViewInsert()
        {
            try
            {
                //Console.Clear();
                Console.WriteLine("\n----------------------------------------------");
                Console.WriteLine("Gerenciador de Endpoints - Cadastro\r");
                Console.WriteLine("----------------------------------------------");

                var newEndpoint = new Endpoint();

                Console.WriteLine("\nPor favor, preencha abaixo os campos solicitados:");

                Console.Write("\nNúmero da série do terminal: ");
                newEndpoint.TerminalSerialNumber = Console.ReadLine();

                Console.WriteLine("\nSelecione o modelo do medidor:\n");

                Console.WriteLine("\t16 - NSX1P2W");
                Console.WriteLine("\t17 - NSX1P3W");
                Console.WriteLine("\t18 - NSX2P3W");
                Console.WriteLine("\t19 - NSX3P4W\n");

                Console.Write("Informe aqui o código do modelo desejado: ");
                newEndpoint.IdMeterModel = ValidateNumber();

                Console.Write("\n\nNúmero do medidor: ");
                newEndpoint.MeterNumber = ValidateNumber();

                Console.Write("\n\nVersão do firmware do medidor: ");
                newEndpoint.MeterFirmwareVersion = Console.ReadLine();

                Console.WriteLine("\nSelecione o estado:\n");
                Console.WriteLine("\t0 - Desconectado");
                Console.WriteLine("\t1 - Conectado");
                Console.WriteLine("\t2 - Armado\n");

                Console.Write("Informe aqui o código do estado desejado: ");
                newEndpoint.ChangeState = ValidateNumber();

                var message = Validate(newEndpoint);

                if (!string.IsNullOrEmpty(message))
                {
                    Console.Clear();
                    Console.WriteLine("\n\nNão foi possível realizar o cadastro, revise os campos abaixo:");
                    Console.WriteLine(message);
                    ViewInsert();
                }
                else
                {
                    Console.WriteLine("\n\nFazer o insert aqui\n");
                }

                Console.WriteLine($"\n{newEndpoint}");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro no cadastro: {ex.Message}");
                ViewMenu();
            }
        }

        /// <summary>
        /// Validar informações prévias do cadastro
        /// </summary>
        /// <param name="enpoint">Objeto Endpoint</param>
        /// <returns></returns>
        private static string Validate(Endpoint endpoint)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(endpoint.TerminalSerialNumber))
            {
                message = "\n\t* Número de série do terminal";
            }

            if (endpoint.IdMeterModel < 16 || endpoint.IdMeterModel > 19)
            {
                message += "\n\t* Modelo do medidor";
            }

            if (endpoint.MeterNumber == 0)
            {
                message += "\n\t* Número do medidor";
            }

            if (string.IsNullOrEmpty(endpoint.MeterFirmwareVersion))
            {
                message += "\n\t* Versão do firmware do medidor";
            }

            if (endpoint.ChangeState > 3)
            {
                message += "\n\t* Mudança de estado";
            }

            return message;
        }

        /// <summary>
        /// Permitir input de apenas números inteiros
        /// </summary>
        /// <returns></returns>
        private static int ValidateNumber()
        {
            double val = 0;
            string num = "";

            ConsoleKeyInfo chr;

            do
            {
                chr = Console.ReadKey(true);

                if (chr.Key == ConsoleKey.Backspace && num.Length > 0)
                {
                    num += chr.KeyChar.ToString().Remove(chr.KeyChar.ToString().Length - 1);
                    num = num.Substring(0, (num.Length - 1));
                    Console.Write("\b \b");
                }
                else
                {
                    bool control = double.TryParse(chr.KeyChar.ToString(), out val);
                    if (control)
                    {
                        num += chr.KeyChar;
                        Console.Write(chr.KeyChar);
                    }
                }

            } while (chr.Key != ConsoleKey.Enter || string.IsNullOrEmpty(num));

            return int.Parse(num);
        }
    }
}
