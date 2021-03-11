using ManageEndpoints.Services;
using ManageEndpoints.Services.Interfaces;
using System;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Objeto de visualização de todos os Endpoints
    /// </summary>
    public static class ViewAll
    {
        static int tableWidth = 115;
        private static readonly IEndpointService _endpointService = new EndpointService();

        /// <summary>
        /// Forulários de visualização de todos os cadastros
        /// </summary>
        public static void FormList()
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Endpoints Cadastrados\r");
            Console.WriteLine("----------------------------------------------------------------\n\n");

            RenderLine();
            RenderRow("Num. Série do terminal", "Modelo do medidor", "Número do medidor", "Versão firmware", "Estado");
            RenderLine();

            var endpoints = _endpointService.Get();            

            foreach (var endpoint in endpoints)
            {
                RenderRow(endpoint.TerminalSerialNumber
                        , Helpers.GetMeterModelDescription(endpoint.IdMeterModel)
                        , endpoint.MeterNumber.ToString()
                        , endpoint.MeterFirmwareVersion
                        , Helpers.GetChangeStateDescription(endpoint.ChangeState));
            }

            if (endpoints.Count == 0)
            {
                Console.WriteLine("\rNão existem dados para apresentar!");
            }

            RenderLine();

            Console.WriteLine("\rPressione qualquer tecla para voltar ao menu!");

            Console.ReadKey();

            Console.Clear();
            ViewMenu.FormMenu();
        }

        #region Rendereziação da tabela  

        /// <summary>
        /// Renderizar linha
        /// </summary>
        private static void RenderLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        private static void RenderRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCenter(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        /// <summary>
        /// Centralizar textto
        /// </summary>
        /// <param name="text">Texto</param>
        /// <param name="width">Largura</param>
        /// <returns></returns>
        private static string AlignCenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        #endregion

    }
}
