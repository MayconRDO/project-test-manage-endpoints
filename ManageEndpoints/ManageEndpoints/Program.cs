using ManageEndpoints.Models;
using ManageEndpoints.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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
            try
            {
                Views.ViewMenu.FormMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n################################################################");
                Console.WriteLine($"Ocorreu um erro na aplicação: {ex.Message}\r");
                Console.WriteLine("################################################################");
            }
        }
    }
}
