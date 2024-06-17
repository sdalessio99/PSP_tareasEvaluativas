using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ErosBirt
{
    class Program
    {
        const int MAXCOLA = 10;
        const int MAXPEDIDOS = 30;

        static void Main(string[] args)
        {
            //creacion de la coleccion de objetos tipo Pedido
            //se usa el tamaño maximo de la cola como parametro al crear el BlockingCollection
            BlockingCollection<Pedido> coleccionPedidos = new BlockingCollection<Pedido>(MAXCOLA);
            Random aleatorio = new Random();
            TimeSpan tspan;

            //tarea con funcion de productor, añade elementos a la coleccion
            Task productor = Task.Run(() =>
            {
                Console.WriteLine("Comienza la generación de pedidos por el productor.");
                int contador = 0;
                bool AnadirElemento = true;
                
                //bucle para seguir añadiendo elementos hasta que llega al maximo de pedidos
                while (AnadirElemento)
                {
                    //se generan los datos aleatorios, la categoria del pedido y el tiempo de respuesta
                    int producto = aleatorio.Next(0, 2);
                    tspan = new TimeSpan(aleatorio.Next(24),aleatorio.Next(100),aleatorio.Next(1000)); 
                    
                    //se crea el objeto de tipo Pedido
                    Pedido unPedido = new Pedido(contador, producto, tspan);

                    //añadir objeto creado a la coleccion
                    coleccionPedidos.Add(unPedido);
                    Console.WriteLine("-------------");
                    Console.WriteLine("Nuevo pedido:");
                    Console.WriteLine("-------------");
                    Console.WriteLine(unPedido.ToString());

                    //duerme el hilo durante 300ms
                    Thread.Sleep(300);

                    //aumenta el contador
                    contador++;

                    //se verifica que no ha llegado al maximo, si es asi se cambia AnadirElemento a false
                    if (contador == MAXPEDIDOS)
                    {
                        AnadirElemento = false;
                    }

                }
                
                //se cierra la coleccion, no puede recibir mas elementos
                coleccionPedidos.CompleteAdding();
                Console.WriteLine("Cierre de la cola de pedidos.");

            });

            //tarea con funcion de consumidor1, consume los elementos de la BlockingCollection
            Task consumidor1 = Task.Run(() =>
            {
                Console.WriteLine("Comienza a procesar pedidos el CENTRO LOGÍSTICO1.");
                
                //analiza si la coleccion esta marcada como completada
                while (!coleccionPedidos.IsCompleted)
                {
                    Pedido pedido = null;
                    
                    //bloque try-catch para gestionar excepciones
                    //al hacer Take(), si coleccionPedidos.Count == 0 espera hasta que el valor cambie
                    try
                    {
                        pedido = coleccionPedidos.Take();
                    } catch (InvalidOperationException) { }

                    //analiza si el pedido no esta vacio, es decir que si ha cogido algo al hacer Take()
                    //añade los datos del pedido consumido a la consola
                    if (pedido != null)
                    {
                        Console.WriteLine("Cargando pedido en CENTRO LOGISTICO1");
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine(pedido.ToString());
                        Console.WriteLine("Número de pedidos que quedan en la cola para procesar por los consumidores: " + coleccionPedidos.Count);
                    }
                    
                    //duerme el hilo 1000ms
                    Thread.Sleep(1000);
                }
                
                //cuando la coleccion esta cerrada, salta este mensaje en la consola
                Console.WriteLine("CENTRO LOGÍSTICO1 no tiene material para procesar");
            });


            //mismo funcionamiento que el consumidor1, solamente cambia el tiempo que duerme el hilo a 2000ms
            Task consumidor2 = Task.Run(() =>
            {
                Console.WriteLine("Comienza a procesar pedidos el CENTRO LOGÍSTICO2.");
                while (!coleccionPedidos.IsCompleted)
                {
                    Pedido pedido = null;
                    try
                    {
                        pedido = coleccionPedidos.Take();
                    }
                    catch (InvalidOperationException) { }

                    if (pedido != null)
                    {
                        Console.WriteLine("Cargando pedido en CENTRO LOGISTICO2");
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine(pedido.ToString());
                        Console.WriteLine("Número de pedidos que quedan en la cola para procesar por los consumidores: " + coleccionPedidos.Count);
                    }
                    Thread.Sleep(2000);
                }

                Console.WriteLine("CENTRO LOGÍSTICO2 no tiene material para procesar");
            });

            //se espera a que finalicen las tareas y se usa un wait
            productor.Wait();
            consumidor1.Wait();

            //salta este mensaje una vez que todas las tareas han finalizado
            Console.WriteLine("Tanto el almacén como los centros logísticos están cerrados. Número de elementos del almacén " + coleccionPedidos.Count);
        }
    }

    //clase Pedido para crear y gestionar mas facilmente toda la informacion de los pedidos
    //override al metodo ToString para poder sacar directamente eso por consola con el formato determinado
    class Pedido
    {
        int id {  get; set; }
        string tipo { get; set; }
        TimeSpan respuesta {  get; set; }

        private string[] tipos = ["Ropa", "Juguetes", "Electronica"];

        public Pedido (int id,  int indice, TimeSpan respuesta)
        {
            this.id = id;
            this.tipo = tipos[indice];
            this.respuesta = respuesta;
        }

        public override string ToString()
        {
            string pedidoCompleto = "Pedido " + id + "\n" + tipo + "\n" + respuesta;
            return pedidoCompleto;
        }        

    }
}