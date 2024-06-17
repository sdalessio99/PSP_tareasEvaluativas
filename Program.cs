
/*
PSP05: Tarea Evaluativa
Descripción: Trabajando con Tasks. El gestión de pedidos online
             Crea BlockingCollection, una tarea productora y dos consumidoras
Fecha: 19/03/2024
 */
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace PSP02_TE01_PedidosOnline
{
    class Program
    {
        /*Tiene que haber 3 task:
            * 1. Productor: Venta on-line, 
            * 2. Consumidor : procesa pedidos de almacén (1seg)
            * 3. Consumidor: procesa pedidos de almacén (0,5seg)
        */
        const int VALOR_PEDIDOS = 30;
        const int TAMANO_COLA= 10;
        static void Main(string[] args)
        {
            //creo almacén
            BlockingCollection<Pedido> cola = new BlockingCollection<Pedido>(TAMANO_COLA);
            
            Task generoPedido = Task.Run(() =>
            {
                Pedido eskaera = null;
                int codigo = 0;
                bool maxAlmacen = false;
                Console.WriteLine("Comienza la generación de pedidos por el productor.");
                while (!maxAlmacen)
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Nuevo pedido:");
                    Console.WriteLine("-------------");
               
                    eskaera = new Pedido(codigo);
                    
                    cola.Add(eskaera);
                    
                    
                    codigo++;
                    Thread.Sleep(300);
                    if (codigo == VALOR_PEDIDOS)
                    {
                        maxAlmacen = true;
                    }
                }
                cola.CompleteAdding();
                Console.WriteLine("Cierre de la cola de pedidos.");
            });
            
            Task ProcesarPedido1 = Task.Run(() =>
            {
                Console.WriteLine("Comienza a procesar pedidos el CENTRO LOGÍSTICO1.");
                while (!cola.IsCompleted || cola.Count != 0)
                {
                    Pedido eskaera = null;

                    try
                    {

                        Thread.Sleep(1000);
                        if ((!cola.IsCompleted || cola.Count != 0))
                        {
                            eskaera = cola.Take();
                            if (eskaera == null)
                            {
                                Console.WriteLine("Ha habido un problema con el pedido, no existe o los datos son incorrectos");
                            }
                            Console.WriteLine("Cargando pedido en CENTRO LOGÍSTICO1:");
                            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
                            eskaera.Imprimir();
                            Console.WriteLine("Número de pedidos que quedan en la cola para procesar por los consumidores: {0}", cola.Count);
                        }

                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Ha habido un problema al procesar el pedido del almacén. Centro LOGÍSTICO1");
                    }

                   
                }
                Console.WriteLine("CENTRO LOGÍSTICO1 no tiene material para procesar");
            });
            Task ProcesarPedido2 = Task.Run(() =>
            {
                Console.WriteLine("Comienza a procesar pedidos el CENTRO LOGÍSTICO2.");
                while (!cola.IsCompleted || cola.Count !=0)
                {
                    Pedido eskaera = null;

                    try
                    {
                        Thread.Sleep(2000);
                        if ((!cola.IsCompleted || cola.Count != 0))
                        {
                            eskaera = cola.Take();
                            if (eskaera == null)
                            {
                                Console.WriteLine("Ha habido un problema con el pedido, no existe o los datos son incorrectos");
                            }
                            Console.WriteLine("Cargando pedido en CENTRO LOGÍSTICO2:");
                            Console.WriteLine("*************************************");
                            eskaera.Imprimir();
                            Console.WriteLine("Número de pedidos que quedan en la cola para procesar por los consumidores: {0}", cola.Count);
                        }

                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Ha habido un problema al procesar el pedido del almacén. Centro LOGÍSTICO2");
                    }


                }
                Console.WriteLine("CENTRO LOGÍSTICO2 no tiene material para procesar");
            });


            Task.WaitAll(ProcesarPedido1, ProcesarPedido2);

            Console.WriteLine("Tanto el almacén como los centros logísticos están cerrados. Número de elementos del almacén {0}", cola.Count);
            Console.Read();
        }
    }
}
