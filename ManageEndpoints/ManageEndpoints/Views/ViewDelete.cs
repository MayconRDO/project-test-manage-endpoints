using ManageEndpoints.Services;
using ManageEndpoints.Services.Interfaces;
using System;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Classe de objetos referente a funcionalidae de Delete
    /// </summary>
    public static class ViewDelete
    {
        private static readonly IEndpointService _endpointService = new EndpointService();

        /// <summary>
        /// Formulário de Delete
        /// </summary>
        public static void FormDelete()
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Excluir\r");
            Console.WriteLine("----------------------------------------------------------------\n\n");

            Console.Write("Informe aqui o número de série do terminal que deseja excluir: ");

            var idTerminalSerialNumber = Console.ReadLine();

            var endpoint = _endpointService.Get(idTerminalSerialNumber);

            if (endpoint != null)
            {
                Console.WriteLine("\nSegue abaixo os detalhes do Endpoint\n");

                Console.WriteLine($"\tNúmero de série do terminal: {endpoint.TerminalSerialNumber}");
                Console.WriteLine($"\tModelo do medidor: {Helpers.GetMeterModelDescription(endpoint.IdMeterModel)}");
                Console.WriteLine($"\tNúmero do medidor: {endpoint.MeterNumber}");
                Console.WriteLine($"\tVersão do firmware do medidor: {endpoint.MeterFirmwareVersion}");
                Console.WriteLine($"\tMudança de estado: {Helpers.GetChangeStateDescription(endpoint.ChangeState)}");

                Console.WriteLine($"\nDeseja realmente excluir o registro '{endpoint.TerminalSerialNumber}'?\n");
                Console.WriteLine("\t1 - Sim");
                Console.WriteLine("\t2 - Não");

                Console.Write("\nInforme aqui o código da opção desejada: ");
                var option = Console.ReadLine();

                if (option.Equals("1") || option.Equals("2"))
                {
                    _endpointService.Delete(endpoint);

                    Console.Clear();
                    Console.WriteLine("\n\n################################################################");
                    Console.WriteLine("Registro excluído com sucesso\r");
                    Console.WriteLine("################################################################");
                    ViewMenu.FormMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n################################################################");
                    Console.WriteLine("Opção inválida!\r");
                    Console.WriteLine("################################################################");
                    FormDelete();
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
