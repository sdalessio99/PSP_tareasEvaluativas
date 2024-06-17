using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP02_TE01_PedidosOnline
{
    internal class Pedido
    {
        private int idPedido;
        private string tipoMaterial;
        private TimeSpan tiempoRespuesta;

        // Constructor que toma el identificador del pedido como argumento
        public Pedido(int idPedido)
        {
            this.idPedido = idPedido;
            Console.WriteLine("Pedido {0}",this.idPedido);
            GenerarTipoMaterial();
            GenerarTiempoRespuesta();
        }


        // Método privado para generar aleatoriamente el tipo de material
        private void GenerarTipoMaterial()
        {
            Random rnd = new Random();
            string[] materiales = { "Ropa", "Electrónica", "Juguetes" };
            tipoMaterial = materiales[rnd.Next(0, materiales.Length)];
            Console.WriteLine(tipoMaterial);
        }

        // Método privado para generar aleatoriamente el tiempo de respuesta
        private void GenerarTiempoRespuesta()
        {
            Random rnd = new Random();
            int horas = rnd.Next(1, 24);
            int minutos = rnd.Next(0, 60);
            tiempoRespuesta = new TimeSpan(horas, minutos, 0);
            Console.WriteLine(tiempoRespuesta);
        }

        // Método para obtener el identificador del pedido
        public int getIdPedido()
        {
            return idPedido;
        }

        // Método para obtener el tipo de material
        public string getTipoMaterial()
        {
            return tipoMaterial;
        }

        // Método para obtener el tiempo de respuesta
        public TimeSpan getTiempoRespuesta()
        {
            return tiempoRespuesta;
        }
        // Método que imprime información del pedido
        public void Imprimir()
        {
            
            Console.WriteLine("Pedido num:{0}",this.idPedido);
            Console.WriteLine(this.tipoMaterial);
            Console.WriteLine(this.tiempoRespuesta);
            
        }
    }
}
