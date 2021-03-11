using System;
using ManageEndpoints.Models;
using ManageEndpoints.Services;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Classe de objetos do formulário de cadastro
    /// </summary>
    public static class ViewInsert
    {
        /// <summary>
        /// Visualização do formulário de cadastro
        /// </summary>
        public static void FormInsert()
        {
            try
            {
                Console.WriteLine("\n----------------------------------------------------------------");
                Console.WriteLine("Gerenciador de Endpoints - Cadastro\r");
                Console.WriteLine("----------------------------------------------------------------");

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
                newEndpoint.IdMeterModel = Helpers.ValidateNumber();

                Console.Write("\n\nNúmero do medidor: ");
                newEndpoint.MeterNumber = Helpers.ValidateNumber();

                Console.Write("\n\nVersão do firmware do medidor: ");
                newEndpoint.MeterFirmwareVersion = Console.ReadLine();

                Console.WriteLine("\nSelecione o estado:\n");
                Console.WriteLine("\t0 - Desconectado");
                Console.WriteLine("\t1 - Conectado");
                Console.WriteLine("\t2 - Armado\n");

                Console.Write("Informe aqui o código do estado desejado: ");
                newEndpoint.ChangeState = Helpers.ValidateNumber();

                var message = Validate(newEndpoint);

                if (!string.IsNullOrEmpty(message))
                {
                    Console.Clear();
                    Console.WriteLine("\n\n################################################################");
                    Console.WriteLine("Não foi possível realizar o cadastro, revise os campos abaixo:\r");
                    Console.WriteLine("################################################################");
                    Console.WriteLine(message);
                    FormInsert();
                }
                else
                {
                    var endpointService = new EndpointService();
                    endpointService.Save(newEndpoint);

                    Console.Clear();
                    Console.WriteLine("\n\n################################################################");
                    Console.WriteLine("Cadastro realizado com sucesso\r");
                    Console.WriteLine("################################################################");
                    ViewMenu.FormMenu();
                }

                Console.WriteLine($"\n{newEndpoint}");
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro no cadastro: {ex.Message}");
                ViewMenu.FormMenu();
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
            else
            {
                var endpointService = new EndpointService();
                var endpointCache = endpointService.Get(endpoint.TerminalSerialNumber);

                if (endpointCache != null)
                {
                    message += "\n\t* Número de série já existe na base de dados";
                }
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
    }
}
