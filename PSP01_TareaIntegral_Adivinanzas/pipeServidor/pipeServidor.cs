using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Xml;

//enlace al video de youtube: https://youtu.be/q4zK7Rw_ldk 

namespace pipeServidor
{
    class PipeServidor
    {
        static void Main(string[] args)
        {
            try
            {
                //inicializar variables a usar en la logica del programa
                string fichero = @"..\..\..\..\adivinanzas.xml";
                List<Adivinanza> listaAdivinanzas = new List<Adivinanza>();
                Adivinanza adivinanza1 = null;
                string pregunta = string.Empty;
                string respuesta = string.Empty;
                string cliente = string.Empty;
                bool seguirJugando = true;

                //conexion del servidor
                var server = new NamedPipeServerStream("PSP01_TareaIntegral_NamedPipe");
                server.WaitForConnection();
                Console.WriteLine("Conexión a servidor establecida.");
                Console.WriteLine("Pipe Servidor esperando datos.\n");

                //crear buffers
                StreamReader sr = new StreamReader(server);
                StreamWriter sw = new StreamWriter(server);

                //cargar fichero en la lista
                listaAdivinanzas = CargarFicheroXml(fichero);

                while(seguirJugando)
                {
                    //obtenemos lo que ha enviado el cliente, y nos quedamos con el primer caracter del buffer
                    //las opciones son J (jugar) o R (respuesta) 
                    //se va a usar el caracter para saber si el usuario esta solicitando jugar o si está enviando una respuesta a una adivinanza
                    cliente = sr.ReadLine();

                    switch (cliente[0])
                    {
                        //este caso elige una adivinanza aleatoria para presentar al cliente
                        //aprovecha ese metodo para hacer un control de cuantas quedan en la lista
                        //si la adivinanza es null significa que se han acabado los acertijos y se cierra el programa, manda F (fin) al cliente
                        //si la adivinanza tiene un valor significa que todavia quedan, manda P (pregunta) al cliente y el enunciado
                        case 'J':
                            adivinanza1 = ElegirAdivinanzaRandom(listaAdivinanzas);
                            if(adivinanza1 != null)
                            {
                                pregunta = adivinanza1.Enunciado;
                                pregunta = "P " + pregunta;
                                sw.WriteLine(pregunta);
                                sw.Flush();
                                Console.WriteLine("Enviado:" + pregunta);
                                break;
                            }
                            else
                            {
                                seguirJugando = false;
                                pregunta = "F ";
                                sw.WriteLine(pregunta);
                                sw.Flush();
                                Console.WriteLine("Finalizando programa, se han acabado las adivinanzas");
                                break;
                            }

                        //este caso obtiene la respuesta del usuario y la compara con la respuesta acertada
                        //si acierta devuelve "R OK", si no devuelve "R KO"
                        case 'R':
                            respuesta = cliente.Substring(2, cliente.Length - 2);
                            Console.WriteLine("Recibido:\n" + respuesta);
                            Console.WriteLine("RespuestaReal:" + adivinanza1.Respuesta);

                            if (String.Equals(respuesta.ToLower(), adivinanza1.Respuesta.ToLower()))
                            {
                                pregunta = "R " + "OK";
                                sw.WriteLine(pregunta);
                                sw.Flush();
                                Console.WriteLine("Enviado:" + pregunta);
                                Console.WriteLine("Borrando adivinanza de la lista:" + adivinanza1.Enunciado);
                                listaAdivinanzas.Remove(adivinanza1);
                                Console.WriteLine("Número de adivinanzas disponibles en la lista:{0}\n", listaAdivinanzas.Count);
                                break;
                            }
                            else
                            {
                                pregunta = "R " + "KO";
                                sw.WriteLine(pregunta);
                                sw.Flush();
                                Console.WriteLine("Enviado:" + pregunta);
                                break;
                            }

                        //se usa el caso default para tratar otras opciones, se avisa y se cambia el valor de seguirJugando a false y eso cierra el programa
                        default:
                            Console.WriteLine("La opcion no es valida. Se cerrará el programa");
                            seguirJugando = false;
                            cliente = null;
                            break;
                    }
                }
                //cierre de buffers
                sr.Close();
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Apagando servidor por un error: " + ex.Message);
            }
        }

        //metodo para cargar un fichero xml a una lista de objetos Adivinanza
        private static List<Adivinanza> CargarFicheroXml(string rutaFichero)
        {
            //inicializar lista que queremos devolver
            List<Adivinanza> lista = new List<Adivinanza>();
            
            //crear objeto XmlDocument para guardar el contenido del xml del que tenemos la ruta
            XmlDocument fichero = new XmlDocument();
            fichero.Load(rutaFichero);

            //obtener los nodos que nos interesan
            XmlNodeList nodos = fichero.SelectNodes("/adivinanzas/adivinanza");

            //recorrer la lista de nodos para obtener los datos, crear un obj Adivinanza por cada nodo y añadirlo a la lista
            foreach (XmlNode nodo in nodos)
            {
                int numero = int.Parse(nodo.Attributes["numero"].Value);
                string enunciado = nodo.SelectSingleNode("enunciado").InnerText;
                string respuesta = nodo.SelectSingleNode("respuesta").InnerText;

                Adivinanza adivinanza1 = new Adivinanza(numero, enunciado, respuesta);
                lista.Add(adivinanza1);
            }
            return lista;
        }

        //metodo para elegir y devolver una adivinanza aleatoria de la lista y controlar cuantas quedan para resolver
        //si ya no quedan devuelve un obj Adivinanza con valor null
        private static Adivinanza ElegirAdivinanzaRandom(List<Adivinanza> lista)
        {
            //inicializar el obj Adivinanza que queremos devolver y el indice que vamos a usar
            Adivinanza adivinanza1 = null;
            int indice = 0;

            //crear obj Random para generar un numero aleatorio
            Random azar = new Random();

            if (lista.Count != 0)
            {
                indice = azar.Next(lista.Count);
                Console.WriteLine(indice);
                adivinanza1 = lista[indice];
            }
            else
            {
                adivinanza1 = null;
            }

            return adivinanza1;
        }
    }

    class Adivinanza
    {
        public int Numero { get; set; }
        public string Enunciado { get; set; }
        public string Respuesta { get; set; }

        public Adivinanza(int numero, string enunciado, string respuesta)
        {
            Numero = numero;
            Enunciado = enunciado;
            Respuesta = respuesta;
        }

        public override string ToString()
        {
            return "Adivinanza " + Numero + ": " + Enunciado + " - " + Respuesta; 
        }
    }
}