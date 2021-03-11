using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Classe de objetos referente a funcionalidae de sair da aplicação
    /// </summary>
    public static class ViewExit
    {
        /// <summary>
        /// Formulário de Saída da aplicação
        /// </summary>
        public static void FormExit()
        {
            Console.WriteLine("\n----------------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints - Sair\r");
            Console.WriteLine("----------------------------------------------------------------\n\n");

            Console.WriteLine($"\nDeseja realmente sair da aplicação'?\n");
            Console.WriteLine("\t1 - Sim");
            Console.WriteLine("\t2 - Não");

            Console.Write("\nInforme aqui o código da opção desejada: ");
            var option = Console.ReadLine();

            if (option.Equals("1"))
            {
                Environment.Exit(0);
            }
            else if (option.Equals("2"))
            {
                Console.Clear();
                ViewMenu.FormMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n################################################################");
                Console.WriteLine("Opção inválida!\r");
                Console.WriteLine("################################################################");
                FormExit();
            }


            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu!");

            Console.ReadKey();

            Console.Clear();
            ViewMenu.FormMenu();
        }
    }
}
