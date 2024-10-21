using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        private const string Value = "Bienvenido a Lluiso";
        private static readonly Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.WriteLine(Value);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());
        }

        protected static void Menu(string input){
            if (input == "help"){
                Help();
            }
            else if (input == "about"){
                About();
            }else if (input == "shutdown"){
                Shutdown();
            }else if (input == "restart"){
                Reboot();
            }else if (input == "diskspace"){
                Diskspace();
            }else if (input == "typefile"){
                Typefiles();
            }else if (input == "fileslist"){
                Fileslist();
            }else if (input == "listdirectory"){
                Listdirectory();    
            }else if (input == "readfiles"){
                Readfiles();
            }
            else{
                Console.WriteLine("Comando deconocido.");
            }
        }
        protected static void Help(){
            Console.WriteLine("Con el comando 'about' podras ver la información del sistema operativo tontito");
            Console.WriteLine("Con el comando 'shutdown' podrás apagar el sistema opertaivo de una puñetera vez");
            Console.WriteLine("Con el comando 'restart' podrás reiniciar el sistema operativo de los cojones");
            Console.WriteLine("Con el comando 'diskspace' podras saber el espacio libre de tu disco pocho");
            Console.WriteLine("Con el comando 'typefile' podras saber el tipo de documento de tu archivo de mierda");
            Console.WriteLine("Con el comando 'fileslist' podras ver la lista de tus ficheros asquerosos");
            Console.WriteLine("Con el comando 'listdirectory' podras ver la lista de tus ptos directorios");
        }

        protected static void About(){
            Console.WriteLine("Este es un sistema operativo para autistas como el nombre indica");
        }

        static void Reboot(){
            Console.WriteLine("Reiniciant el sistema...");
            Cosmos.System.Power.Reboot();
        }

        static void Shutdown(){
            Console.WriteLine("Apagant el sistema...");
            Cosmos.System.Power.Shutdown();
        }
        static void Diskspace(){
            var available_space = fs.GetAvailableFreeSpace(@"0:\");
            Console.WriteLine("Espacio disponible: " + available_space);
        }

        static void Typefiles(){
            var fs_type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("Tipo del fichero: " + fs_type);
        }

        static void Listdirectory(){
            var files_list = Directory.GetFiles(@"0:\");
            var directory_list = Directory.GetDirectories(@"0:\");

            foreach (var file in files_list){
                Console.WriteLine(file);
            }
            foreach (var directory in directory_list){
                Console.WriteLine(directory);
            }
        }

        static void Fileslist()
        {
            var files_list = Directory.GetFiles(@"0:\");
            foreach (var file in files_list)
            {
                Console.WriteLine(file);
            }
        }
        static void Readfiles(){

            var directory_list = Directory.GetFiles(@"0:\");

            try{
                foreach (var file in directory_list){
                    var content = File.ReadAllText(file);

                    Console.WriteLine("File name: " + file);
                    Console.WriteLine("File size: " + content.Length);
                    Console.WriteLine("Content: " + content);
                }
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
        }

        protected override void Run(){
            string input = "";
            Console.WriteLine("Escribe \"help\" para recibir una guia de comandos.");
            input = Console.ReadLine();
            Menu(input);
        }

    }
}
