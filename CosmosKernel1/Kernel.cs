using Cosmos.System.Audio;
using IL2CPU.API.Attribs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.HAL.Audio;
namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        private const string Value = "Bienvenido a Lluiso";
        private const string Value2 = "Con el comando 'help' podras ver mas informacion";
        private static readonly Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        //[ManifestResourceStream(ResourceName = "CosmosKernel1.AudioCosmos.wav")] public static byte[] AudioCosmos;
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.WriteLine(Value);
            Console.WriteLine(Value2);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());
        }

        protected static void Menu(string input){
            //var mixer = new AudioMixer();
            //var audioStream = new MemoryAudioStream(new SampleFormat(AudioBitDepth.Bits16, 2, true), 48000, AudioCosmos);
            //var driver = AC97.Initialize(bufferSize: 4096);
            //mixer.Streams.Add(audioStream);

            //var audioManager = new AudioManager()
            //{
            //    Stream = mixer,
            //    Output = driver
            //};
            if (input == "help") {
                Help();
            } else if (input == "about") {
                About();
            } else if (input == "shutdown") {
                Shutdown();
            } else if (input == "restart") {
                Reboot();
            } else if (input == "diskspace") {
                Diskspace();
            } else if (input == "typefile") {
                Typefiles();
            } else if (input == "fileslist") {
                Fileslist();
            } else if (input == "listdirectory") {
                Listdirectory();
            } else if (input == "readdirectory") {
                Readdirectory();
            } else if (input == "createfiles") {
                Createfiles();
            } else if (input == "createdirectory") {
                Createdirectory();
            } else if (input == "delete") {
                Delete();
            } else if (input == "writefiles") {
                Writeinfiles();
            } else if (input == "movefiles") {
                MoveFiles();
            } else if (input == "readfile") {
                ReadFile();
            } else if (input == "readbytes") {
                Readbytes();
            } else if (input == "sumar") {
                Suma();
            } else if (input == "resta") {
                Resta();
            } else if (input == "divisio") {
                Divisio();
            }else if (input == "multiplicacio"){
                Multiplicacio();
            } else if (input == "potencia"){
                Potencia();
            } else if (input == "raiz"){
                RaizCuadrada();
            } else if (input == "cls") {
                Cls();
            //} else if (input == "music"){

            //    audioManager = new AudioManager();
                    
                
            //
            } else
            {
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
            Console.WriteLine("Con el comando 'readdirectory' podras leer los ficheros de la carpeta payaso");
            Console.WriteLine("Con el comando 'createfiles' podras crear ficheros");
            Console.WriteLine("Con el comando 'createdirectory' podras crear carpetas");
            Console.WriteLine("Con el comando 'delete' podras borrar ficheros");
            Console.WriteLine("Con el comando 'writefiles' podras escribir en ficheros");
            Console.WriteLine("Con el comando 'movefiles' podras mover ficheros");
            Console.WriteLine("Con el comando 'readfile' podras leer el texto dentro de un fichero");
            Console.WriteLine("Con el comando 'readbytes' podras leer los bytes del fichero");
            Console.WriteLine("Con el comando 'sumar' pues que va a hacer tonto bailar?");
            Console.WriteLine("Con el comando 'resta' enserio hace falta?");
            Console.WriteLine("Con el comando 'divisio' supongo que no hace falta que no puedes dividir entre cero no?");
            Console.WriteLine("Con el comando 'multiplicacio' estoy cansansado jefe");
            Console.WriteLine("Con el comando 'potencia' siete letras esencia");
            Console.WriteLine("Con el comando 'raiz' si alguien lee esto zzzzz");
            Console.WriteLine("Con el comando 'cls' podras limpiar tu pantalla cerdo");
            Console.WriteLine("Con el comando 'music' podras escuchar musica");


        }

        protected static void About(){
            Console.WriteLine("Este es mi sistema operativo cutre");
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
        static void Readdirectory(){
            Console.WriteLine("Escribe el nombre de la carpeta que deseas explorar (por ejemplo, 'nombre_carpeta'):");
            string folderName = Console.ReadLine();

            string directoryPath = @"0:\" + folderName;

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Error: La carpeta no existe - " + directoryPath);
                return;
            }

            var directoryList = Directory.GetFiles(directoryPath);

            if (directoryList.Length == 0)
            {
                Console.WriteLine("No hay archivos en la carpeta.");
                return;
            }

            try
            {
                foreach (var file in directoryList)
                {
                    var fileInfo = new FileInfo(file); 
                    Console.WriteLine("Nombre del archivo: " + fileInfo.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }

        static void Createdirectory(){
            Console.WriteLine("Escribe el nombre del directorio que deseas crear (ejemplo: 'testdirectory'):");
            string directoryName = Console.ReadLine();
            
            string directoryPath = @"0:\" + directoryName;

            try
            {               
                if (Directory.Exists(directoryPath))
                {
                    Console.WriteLine("Error: El directorio ya existe - " + directoryPath);
                    return;
                }

                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directorio creado: " + directoryPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }


        static void Createfiles(){

            try
            {
                Console.WriteLine("Escribe el nombre del fichero");
                string Nom = "";
                Nom = Console.ReadLine();
                var file_stream = File.Create(@"0:\" + Nom );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        static void Delete(){

            try
            {
                Console.WriteLine("Quierres borrar un 'fichero' o una 'carpeta'");
                string Opcion = "";
                Opcion = Console.ReadLine();
                if (Opcion == "fichero"){
                    Console.WriteLine("Escribe el nombre del fichero");
                    string Nom = "";
                    Nom = Console.ReadLine();
                    File.Delete(@"0:\" + Nom);
                }
                else{
                    Console.WriteLine("Escribe el nombre del directory");
                    string Nom = "";
                    Nom = Console.ReadLine();
                    Directory.Delete(@"0:\"+Nom+"\\");
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Writeinfiles(){

            try{
                Console.WriteLine("Escribe el nombre del fichero");
                string Nom = "";
                Nom = Console.ReadLine();
                Console.WriteLine("Escribe el el texto que quieres poner");
                string Texto = "";
                Texto = Console.ReadLine();
                File.WriteAllText(@"0:\"+Nom, Texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void MoveFiles()
        {
            try
            {
                Console.WriteLine("Escribe el nombre del fichero que deseas mover (ejemplo: 'testing.txt'):");
                string fileName = Console.ReadLine();

                // Construir la ruta completa del archivo
                string filePath = @"0:\" + fileName;

                Console.WriteLine("Escribe el nombre de la carpeta donde deseas mover el archivo (ejemplo: 'testdirectory'):");
                string folderName = Console.ReadLine();

                // Construir la nueva ruta usando la carpeta y el nombre del archivo original
                string newDirectoryPath = @"0:\" + folderName;
                string newFilePath = Path.Combine(newDirectoryPath, fileName);

                // Verificar si el archivo de origen existe
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: El archivo de origen no existe - " + filePath);
                    return;
                }

                // Verificar si el directorio de destino existe
                if (!Directory.Exists(newDirectoryPath))
                {
                    Console.WriteLine("Error: El directorio de destino no existe - " + newDirectoryPath);
                    return;
                }

                // Mover el archivo
                File.Copy(filePath, newFilePath, true);
                File.Delete(filePath);
                Console.WriteLine("Archivo movido de " + filePath + " a " + newFilePath);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Error de entrada/salida: " + ioEx.Message);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine("Error de permisos: " + uaEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static void ReadFile(){
            try{
                Console.WriteLine("Escribe el nombre del fichero");
                string Nom = "";
                Nom = Console.ReadLine();
                Console.WriteLine(File.ReadAllText(@"0:\"+Nom));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Readbytes()
        {
            try
            {
                Console.WriteLine("Escribe el nombre del fichero");
                string Nom = Console.ReadLine(); 

                var filePath = @"0:\" + Nom;

                byte[] bytes = File.ReadAllBytes(filePath);
                Console.WriteLine("Bytes del archivo:");
                foreach (byte b in bytes)
                {
                    Console.Write(b + " "); 
                }
                Console.WriteLine(); 
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("Error: Archivo no encontrado - " + fnfEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        protected static void Suma(){
            float num1 = 0;
            float num2 = 0;
            Console.WriteLine("Introdeix el primer numero");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Introdeix el segon numero");
            num2 = float.Parse(Console.ReadLine());
            float resultado = num1 + num2;
            Console.WriteLine(resultado.ToString("0.00"));
        }

        protected static void Resta(){
            float num1 = 0;
            float num2 = 0;
            Console.WriteLine("Introdeix el primer numero");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Introdeix el segon numero");
            num2 = float.Parse(Console.ReadLine());
            float resultado = num1 - num2;
            Console.WriteLine(resultado.ToString("0.00"));
        }

        protected static void Divisio()
        {
            float num1 = 0;
            float num2 = 0;
            Console.WriteLine("Introdeix el primer numero");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Introdeix el segon numero");
            num2 = float.Parse(Console.ReadLine());
            if (num2 == 0){
                Console.WriteLine("Eres tonto?");
            }else{
                float resultado = num1 / num2;
                Console.WriteLine(resultado.ToString("0.00"));
            }
        }

        protected static void Multiplicacio()
        {
            float num1 = 0;
            float num2 = 0;
            Console.WriteLine("Introdeix el primer numero");
            num1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Introdeix el segon numero");
            num2 = float.Parse(Console.ReadLine());
            if (num2 == 0){
                Console.WriteLine("Eres tonto?");
            }else
            {
                float resultado = num1 * num2;
                Console.WriteLine(resultado.ToString("0.00"));
            }
        }

        protected static void Potencia()
        {
            double baseNumber = 0;
            double exponent = 0;

            try
            {
                Console.WriteLine("Introduce la base (numero decimal permitido):");
                baseNumber = double.Parse(Console.ReadLine());

                Console.WriteLine("Introduce el exponente (numero decimal permitido):");
                exponent = double.Parse(Console.ReadLine());

                double resultado = Math.Pow(baseNumber, exponent);
                Console.WriteLine($"El resultado de {baseNumber} elevado a {exponent} es: {resultado:F2}"); // Formato con dos decimales
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debes introducir un número válido.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        protected static void RaizCuadrada()
        {
            double number = 0;

            try
            {
                Console.WriteLine("Introduce el numero para calcular la raiz cuadrada:");
                number = double.Parse(Console.ReadLine());

                if (number < 0)
                {
                    Console.WriteLine("Error: No se puede calcular la raiz cuadrada de un numero negativo.");
                }
                else
                {
                    double resultado = Math.Sqrt(number);
                    Console.WriteLine($"La raiz cuadrada de {number} es: {resultado}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debes introducir un numero valido.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        protected static void Cls(){
            Console.Clear();
        }


        protected override void Run(){
            string input = "";
            input = Console.ReadLine();
            Menu(input);
        }

    }
}
