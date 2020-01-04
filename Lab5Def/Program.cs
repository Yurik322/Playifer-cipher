//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="My Company">
//    Created by yurik_322 on 19/11/13.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Def
{
    /// <summary>
    /// main class for execution
    /// </summary>
    class Program
    {
        /// <summary>
        /// main class
        /// </summary>
        static void Main()
        {
            // for UA encoding:
            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                string Text = Functions.ReadFile("Text.txt");
                Console.WriteLine("Введений текст:\r\n" + Text + "\n");

                string enStr = Functions.EncryptionStr(Text.ToLower());
                Console.WriteLine("\nЗашифрований: {0}", enStr);

                string denStr = Functions.DecryptionStr(enStr);
                Console.WriteLine("\nРозшифрований: {0}", denStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }
    }
}
