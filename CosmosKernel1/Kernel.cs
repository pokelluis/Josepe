using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        private const string Value = "Bienvenido a Lluiso";

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine(Value);
        }

        protected static void Menu(string input){
            if (input == "help")
            {
                Help();
            }
            else if (input == "about")
            {
                About();
            }else if (input == "shutdown")
            {
                Shutdown();
            }else if (input == "restart"){
                Reboot();
            }
            else
            {
                Console.WriteLine("Comando deconocido.");
            }
        }
        protected static void Help()
        {
            Console.WriteLine("Con el comando de about podras ver de que va el sistema operativo");
            Console.WriteLine("Con el comando de close podras cerrar el dichoso sistema opertaivo");
            Console.WriteLine("Con el comando de restart podras reiniciar el sistema operativo");
        }

        protected static void About(){
            Console.WriteLine("Este es un sistema operativo para autistas como el nombre indica");
        }

        static void Reboot()
        {
            Console.WriteLine("Reiniciant el sistema...");
            Cosmos.System.Power.Reboot();
        }

        static void Shutdown()
        {
            Console.WriteLine("Apagant el sistema...");
            Cosmos.System.Power.Shutdown();
        }        
        protected override void Run()
        {
            string input = "";
            Console.WriteLine("Escribe \"help\" para recibir una guia de comandos.");
            input = Console.ReadLine();
            Menu(input);
        }

    }
}
