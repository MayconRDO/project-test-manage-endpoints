using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEndpoints.Views
{
    /// <summary>
    /// Visualização do Menu
    /// </summary>
    public static class ViewMenu
    {
        public static void FormMenu()
        {
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("Gerenciador de Endpoints\r");
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("\nEscolha uma operação para ser realizada:\n");
            Console.WriteLine("\t1 - Cadastrar");
            Console.WriteLine("\t2 - Editar");
            Console.WriteLine("\t3 - Excluir");
            Console.WriteLine("\t4 - Listar todos");
            Console.WriteLine("\t5 - Listar por número de série");

            Console.Write("\nInforme o número referente a operação desejada: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ViewInsert.FormInsert();
                    break;
                case "2":
                    Console.WriteLine($"Editar");
                    break;
                case "3":
                    Console.WriteLine($"Excluir");
                    break;
                case "4":
                    Console.Clear();
                    ViewAll.FormList();
                    break;
                case "5":
                    Console.Clear();
                    View.FormDetail();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\n######################################################");
                    Console.WriteLine("Operação inválida!\r");
                    Console.WriteLine("######################################################");
                    FormMenu();
                    break;
            }
        }
    }
}
