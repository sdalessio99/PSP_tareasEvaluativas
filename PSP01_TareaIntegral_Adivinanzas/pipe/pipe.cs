using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

//enlace al video de youtube: https://youtu.be/q4zK7Rw_ldk 

namespace pipe
{
    class Pipe
    {
        static void Main(string[] args)
        {
            //lanzar el proceso
            Process p = null;
            StartServer(out p);
            Task.Delay(1000).Wait();

            try
            {
                //conexion del cliente
                var client = new NamedPipeClientStream("PSP01_TareaIntegral_NamedPipe");
                client.Connect();
                Console.WriteLine("Estableciendo conexión con el servidor");

                //crear buffers
                StreamReader sr = new StreamReader(client);
                StreamWriter sw = new StreamWriter(client);

                //llamada a metodo para procesar los datos
                ProcesarDatos(sr, sw, p);

                //matar el proceso
                PararProceso(p);
            }
            catch (Exception e)
            {
                Console.WriteLine("Apagando servidor por un error: " + e.Message);
            }
        }

        //Metodo StartServer para gestionar el proceso
        static Process StartServer(out Process p1)
        {
            //declara variable interna ProcessStratInfo para la informacion del proceso a lanzar, ejemplo ruta del ejecutable y ajustes de ventana
            ProcessStartInfo info = new ProcessStartInfo(@"..\..\..\..\pipeServidor\bin\Release\net8.0\publish\pipeServidor.exe");
            info.CreateNoWindow = false;
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.UseShellExecute = true;

            //arrancar el proceso y guardar los datos de creacion en el Process p1 para matar o ver estado del proceso
            p1 = Process.Start(info);

            return p1;
        }

        //metodo para procesar los datos entre server y cliente
        private static void ProcesarDatos(StreamReader sr, StreamWriter sw, Process pr)
        {
            //inicializa las variables que se usan para procesar los datos
            string pregunta = string.Empty;
            string respuesta = string.Empty;
            bool seguirJugando = true;
            bool acertado = false;
            string servidor = string.Empty;

            try
            {
                servidor = servidor + "J ";
                sw.WriteLine(servidor);
                sw.Flush();
                Console.Write("*******************\n");
                Console.Write("*Comienza el juego*\n");
                Console.Write("*******************\n");

                while (seguirJugando)
                {
                    while (!acertado)
                    {
                        //obtenemos lo que ha enviado el servidor, y nos quedamos con el primer caracter del buffer
                        //las opciones son P (pregunta), R (respuesta) o F (fin) 
                        //se va a usar el caracter para saber si el servidor esta mandando el enunciado de la adivinanza, el resultado de la respuesta
                        //o si el programa ha finalizado
                        servidor = sr.ReadLine();
                        switch (servidor[0])
                        {
                            //en este caso, se obtiene el enunciado de la adivinanza quitandole los dos primeros caracteres al string ("P ")
                            //se pasa el enunciado al metodo que imprime la cabecera y mandamos la primera respuesta al servidor leyendola de la consola
                            //va a ir acompañada de R para que el servidor sepa que le estamos mandando 
                            case 'P':
                                pregunta = servidor.Substring(2, servidor.Length - 2);
                                ImprimirCabecera(pregunta);
                                respuesta = Console.ReadLine();
                                respuesta = "R " + respuesta;
                                sw.WriteLine(respuesta);
                                sw.Flush();
                                pregunta = string.Empty;
                                respuesta = string.Empty;
                                break;

                            //en este caso, se obtiene lo que devuelve el servidor sin los caracteres iniciales
                            //si contiene OK, se imprime el resultado en consola y se manda "J " al servidor para que sepa que queremos otra adivinanza
                            //si no contiene OK, se imprime el resultado, se saca la respuesta nueva y se envia al servidor junto a R para que sepa que es una respuesta
                            case 'R':
                                pregunta = servidor.Substring(2, servidor.Length - 2);
                                if (string.Equals(pregunta, "OK"))
                                {
                                    Console.Write("¡Enhorabuena! Has acertado.\n");
                                    Console.Write("----------***--------------\n");
                                    acertado = true;
                                    servidor = string.Empty;
                                    servidor = servidor + "J ";
                                    sw.WriteLine(servidor);
                                    sw.Flush();
                                    Console.Write("*******************\n");
                                    Console.Write("Juega otra vez:\n");
                                    Console.Write("*******************\n");
                                    break;
                                }
                                else
                                {
                                    Console.Write("No has acertado. Introduce otra respuesta:\n");
                                    respuesta = Console.ReadLine();
                                    respuesta = "R " + respuesta;
                                    sw.WriteLine(respuesta);
                                    sw.Flush();
                                    break;
                                }
                            
                            //en este caso se trata la opcion de F(fin) mandada por el servidor para cuando se acaban las adivinanzas del documento
                            //si el proceso ya esta cerrado devuelve el id a consola, si no se mata y tambien devuelve el id
                            case 'F':
                                servidor = servidor + "F ";
                                seguirJugando = false;
                                acertado = true;
                                Console.WriteLine("No quedan adivinanzas, por lo tanto cerramos el programa\n");

                                if (pr == null)
                                {
                                    Console.Write(pr.Id.ToString());
                                    Console.WriteLine("El proceso servidor ya no existe.");
                                    break;
                                }
                                else
                                {
                                    Console.Write(pr.Id.ToString());
                                    if ((sr != null) || (sw != null))
                                    {
                                        if (sr != null)
                                        {
                                            sr.Close();
                                        }
                                        else if (sw != null)
                                        {
                                            sw.Close();
                                        }
                                    }
                                    pr.Kill();
                                }
                                break;

                            default:
                                Console.WriteLine("Opción {0} no válida.");
                                seguirJugando = false;
                                acertado = true;
                                Console.WriteLine("Exit");
                                servidor = null;
                                break;
                        }
                    }
                    acertado = false;
                    servidor = servidor + "J ";
                }
            }
            catch (Exception e)
            {
               Console.WriteLine("Error al procesar datos: " + e.Message);
            }
        }

        //metodo para imprimir cabecera
        private static void ImprimirCabecera(string enunciado)
        {
            Console.Write("\n");
            Console.WriteLine("Resuelve el siguiente acertijo:\n");
            Console.Write("******************Acertijo*************************\n");
            Console.Write(enunciado + "\n");
            Console.Write("****************************************************\n");
            Console.Write("Indica una respuesta:\n");
        }
        
        //metodo para matar el proceso
        static void PararProceso(Process pr)
        {
            if (pr != null && !pr.HasExited)
            {
                pr.Kill();
                pr = null;
            }
        }
    }
}