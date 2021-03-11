using ManageEndpoints.Models;
using ManageEndpoints.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Classe de visualização do objeto Endpoint
    /// </summary>
    public static class View
    {
        public static void FormDetail()
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Endpoint Cadastrado\r");
            Console.WriteLine("----------------------------------------------------------------\n\n");

            Console.Write("Informe o número de série do terminal: ");

            var endpointService = new EndpointService();
            var idTerminalSerialNumber = Console.ReadLine();

            var endpoint = endpointService.Get(idTerminalSerialNumber);

            // REMOVER DEPOIS
            //endpoint = new Endpoint()
            //{
            //    TerminalSerialNumber = "BB",
            //    IdMeterModel = 17,
            //    MeterNumber = 2,
            //    MeterFirmwareVersion = "2.3",
            //    ChangeState = 1
            //};
            // REMOVER DEPOIS

            if (endpoint != null)
            {
                Console.WriteLine("\nSegue abaixo os detalhes do Endpoint\n");

                Console.WriteLine($"\tNúmero de série do terminal: {endpoint.TerminalSerialNumber}");
                Console.WriteLine($"\tModelo do medidor: {Helpers.GetMeterModelDescription(endpoint.IdMeterModel)}");
                Console.WriteLine($"\tNúmero do medidor: {endpoint.MeterNumber}");
                Console.WriteLine($"\tVersão do firmware do medidor: {endpoint.MeterFirmwareVersion}");
                Console.WriteLine($"\tMudança de estado: {Helpers.GetChangeStateDescription(endpoint.ChangeState)}");
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
