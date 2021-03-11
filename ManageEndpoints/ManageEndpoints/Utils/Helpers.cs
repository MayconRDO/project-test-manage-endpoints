using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEndpoints
{
    /// <summary>
    /// Classe de métodos reutilizáveis
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Permitir input de apenas números inteiros
        /// </summary>
        /// <returns></returns>
        public static int ValidateNumber()
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

        /// <summary>
        /// Obter a descrição do modelo medidor
        /// </summary>
        /// <param name="idMeterModel">ID do modelo medidor</param>
        /// <returns>Descrição</returns>

        public static string GetMeterModelDescription(int idMeterModel)
        {
            var message = string.Empty;

            switch (idMeterModel)
            {
                case 16:
                    message = "NSX1P2W";
                    break;
                case 17:
                    message = "NSX1P3W";
                    break;
                case 18:
                    message = "NSX2P3W";
                    break;
                case 19:
                    message = "NSX3P4W";
                    break;
                default:
                    message = "Outros";
                    break;
            }

            return message;
        }

        /// <summary>
        /// Obter a descrição da mudança de estado
        /// </summary>
        /// <param name="changeState">ID da mudança de estado</param>
        /// <returns>Descrição</returns>
        public static string GetChangeStateDescription(int changeState)
        {
            var message = string.Empty;

            switch (changeState)
            {
                case 0:
                    message = "Desconectado";
                    break;
                case 1:
                    message = "Conectado";
                    break;
                case 2:
                    message = "Armado";
                    break;
                default:
                    message = "Outros";
                    break;
            }

            return message;
        }

    }
}
