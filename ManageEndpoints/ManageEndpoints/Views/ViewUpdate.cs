using ManageEndpoints.Services;
using System;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Classe de objetos referente a funcionalidae de update
    /// </summary>
    public static class ViewUpdate
    {
        /// <summary>
        /// Formulário de update
        /// </summary>
        public static void FormUpdate()
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Update\r");
            Console.WriteLine("----------------------------------------------------------------\n\n");

            Console.Write("Informe o número de série do terminal: ");

            var endpointService = new EndpointService();
            var idTerminalSerialNumber = Console.ReadLine();

            var endpoint = endpointService.Get(idTerminalSerialNumber);

            if (endpoint != null)
            {
                Console.WriteLine("\nSegue abaixo os detalhes do Endpoint\n");

                Console.WriteLine($"\tNúmero de série do terminal: {endpoint.TerminalSerialNumber}");
                Console.WriteLine($"\tModelo do medidor: {Helpers.GetMeterModelDescription(endpoint.IdMeterModel)}");
                Console.WriteLine($"\tNúmero do medidor: {endpoint.MeterNumber}");
                Console.WriteLine($"\tVersão do firmware do medidor: {endpoint.MeterFirmwareVersion}");
                Console.WriteLine($"\tMudança de estado: {Helpers.GetChangeStateDescription(endpoint.ChangeState)}");

                Console.WriteLine("\nSelecione o novo estado:\n");
                Console.WriteLine("\t0 - Desconectado");
                Console.WriteLine("\t1 - Conectado");
                Console.WriteLine("\t2 - Armado\n");

                Console.Write("Informe aqui o código do estado desejado: ");
                endpoint.ChangeState = Helpers.ValidateNumber();

                if (endpoint.ChangeState > 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n################################################################");
                    Console.WriteLine("Não foi possível realizar o update, revise os campos abaixo:\r");
                    Console.WriteLine("################################################################");
                    Console.WriteLine("\n\t* Mudança de estado");
                    FormUpdate();
                }
                else
                {
                    endpointService.Save(endpoint);

                    Console.Clear();
                    Console.WriteLine("\n\n################################################################");
                    Console.WriteLine("Update realizado com sucesso\r");
                    Console.WriteLine("################################################################");
                    ViewMenu.FormMenu();
                }

            }
            else
            {
                Console.WriteLine($"\nEndpoint '{idTerminalSerialNumber}' não encontrado!");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");

            Console.ReadKey();

            Console.Clear();
            ViewMenu.FormMenu();
        }
    }
}
