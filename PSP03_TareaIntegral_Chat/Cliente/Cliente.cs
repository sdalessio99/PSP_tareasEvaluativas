using System.Net.Sockets;
using System.Net;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace Cliente
{
    public partial class Cliente : Form
    {
        //declarar variables globales para usar en el resto del programa
        private UdpClient cliente;
        IPEndPoint servidorEP;

        string usuario;
        string chat;
        string mensaje;
        private bool desconectado = false;

        public Cliente()
        {
            InitializeComponent();
        }

        //metodo que se ejecuta al clickear en el boton de conectar a server
        //intenta crear una conexion usando un obj UdpClient y los datos de ip y puerto del servidor
        //para que se puedan conectar varios clientes se usan metodos async
        //se crea un metodo aparte que devuelva un task
        private async void btn_conectar_Click(object sender, EventArgs e)
        {
            //recoger datos insertados por usuario
            string ip = tb_IP.Text;
            int puerto = 2000;
            usuario = tb_usuario.Text;

            if (string.IsNullOrWhiteSpace(ip) && string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Faltan los datos obligatorios para conectar al servidor.");
                return;
            }

            try
            {
                //gestion de los controles del formulario
                btn_conectar.Enabled = false;
                btn_desconectar.Enabled = true;
                groupBox1.Enabled = true;
                desconectado = false;

                this.cliente = new UdpClient();

                servidorEP = new IPEndPoint(IPAddress.Parse(ip), puerto);
                mensaje = "Se acaba de conectar: " + usuario + "\r\n";
                byte[] enviar = Encoding.UTF8.GetBytes(mensaje);
                await cliente.SendAsync(enviar, enviar.Length, servidorEP);

                Task.Run(() => Recibir());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema al conectar. Ver error para saber mas: " + ex.Message);
            }
        }

        //metodo que se ejecuta al clickear en el boton desconectar server
        //envia mensaje de desconexion y cierra el cliente, usando metodo async para enviar datos
        private async void btn_desconectar_Click(object sender, EventArgs e)
        {
            try
            {
                btn_conectar.Enabled = true;
                btn_desconectar.Enabled = false;
                groupBox1.Enabled = false;
                tb_chat.Clear();

                mensaje = "Se acaba de desconectar: " + usuario + "\r\n";
                byte[] enviar = Encoding.UTF8.GetBytes(mensaje);
                await cliente.SendAsync(enviar, enviar.Length, servidorEP);
                desconectado = true;

                if (cliente != null)
                {
                    cliente.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema al desconectar. Ver error para saber mas: " + ex.Message);
            }
        }

        //metodo que se ejecuta al clickear en el boton de enviar, usa metodos async para enviar y recibir datos
        //manda el mensaje del usuario al servidor y recibe respuesta del servidor para mostrar el mensaje en pantalla
        private async void btn_enviar_Click(object sender, EventArgs e)
        {
            try
            {

                chat = tb_mensaje.Text;
                mensaje = usuario + ": " + chat + "\r\n";
                tb_chat.Text += mensaje;
                tb_mensaje.Clear();

                byte[] enviar = Encoding.UTF8.GetBytes(mensaje);
                await cliente.SendAsync(enviar, enviar.Length, servidorEP);
 
                UdpReceiveResult resultado = await cliente.ReceiveAsync();
                string recibido = Encoding.UTF8.GetString(resultado.Buffer);
                tb_chat.Text += recibido;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Problema al enviar mensaje. Ver error para saber mas:" + ex.Message);
            }
        }

        //metodo para la gestion de la recepcion de mensajes, devuelve una tarea
        //para que no se bloquee el servidor al trabajar con varios clientes a la vez
        private async Task Recibir()
        {
            try
            {
                //verificacion de que el cliente siga conectado
                while(!desconectado)
                {
                    UdpReceiveResult resultado = await cliente.ReceiveAsync();
                    string recibido = Encoding.UTF8.GetString(resultado.Buffer);

                    //si recibe un mensaje que corresponde al de final de programa del servidor simula que se haya clickeado el boton de desconexion
                    //de esa manera se ejecuta la desconexion de manera correcta sin repetir codigo
                    //si el mensaje es otro, lo añade a la ventana del chat
                    if(recibido.Equals("FIN"))
                    {
                        try
                        {
                            btn_desconectar.PerformClick();
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Problema al desconectar: " + e.Message);
                        }
                    }
                    else
                    {
                        Invoke(new Action( () => tb_chat.AppendText(recibido)));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Problema al recibir mensaje: " + ex.Message);
            }
        }

    }
}
