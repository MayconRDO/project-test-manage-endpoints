﻿using ManageEndpoints.Services;
using System;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Classe de visualização do objeto Endpoint
    /// </summary>
    public static class View
    {
        /// <summary>
        /// Formulário de detalhes do endpoint
        /// </summary>
        public static void FormDetail()
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Endpoint Cadastrado\r");
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
