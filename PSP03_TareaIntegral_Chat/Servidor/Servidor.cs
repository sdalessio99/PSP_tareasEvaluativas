using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Servidor
{
    public partial class Servidor : Form
    {
        private UdpClient socketServidor;
        private const int puerto = 2000;

        int numeroClientes = 0;
        private ArrayList clientesConectados = new ArrayList();

        public Servidor()
        {
            InitializeComponent();
        }
        
        //metodo que se ejecuta al clickear en el boton de arrancar servidor
        private async void btn_arrancar_Click(object sender, EventArgs e)
        {
            //se gestionan los controles del formulario
            btn_parar.Enabled = true;
            btn_arrancar.Enabled = false;

            //verifica que el socket (obj UdpClient) del servidor no sea nulo, en ese caso lo cierra
            if (socketServidor != null)
            {
                socketServidor.Close();
            }

            //crea socket y conexion
            try
            {
                socketServidor = new UdpClient(puerto);
                tb_chat.Text = "Servidor Arrancado. A la Espera de clientes\r\n";

                //con este bucle se queda a la espera de recibir mensajes del cliente por el buffer gracias al await
                //cuando recibe datos, se dividen usando ":", para obtener el nombre de usuario del cliente que manda el mensaje
                while (true)
                {
                    UdpReceiveResult resultado = await socketServidor.ReceiveAsync();
                    IPEndPoint clienteEP = resultado.RemoteEndPoint;

                    byte[] recibir = resultado.Buffer;
                    string recibirString = Encoding.UTF8.GetString(recibir);
                    string[] mensajeDividido = recibirString.Split(':');
                    string usuario = mensajeDividido[1];

                    //la variable global se usa para almacenar los clientes conectados, verifica que el cliente que envia los datos no este ya en esa lista y en ese caso lo añade
                    //aparte se añade el nombre de usuario sacado de ese buffer de datos
                    if (!clientesConectados.Contains(clienteEP))
                    {
                        clientesConectados.Add(clienteEP);
                        lb_clientes.Items.Add(usuario);
                    }

                    //si recibe un mensaje de desconexion, busca el indice del cliente en la lista, lo borra y actualiza el tb_total
                    //despues busca el nombre de usuario del listbox y lo borra de ahí tambien
                    if (recibirString.Contains("desconectar"))
                    {
                        int indice = clientesConectados.IndexOf(clienteEP);

                        if (indice != -1)
                        {
                            clientesConectados.RemoveAt(indice);
                        }

                        tb_total.Text = clientesConectados.Count.ToString();

                        int indiceLista = lb_clientes.FindString(usuario);
                        if (indiceLista != -1)
                        {
                            lb_clientes.Items.RemoveAt(indiceLista);
                        }
                    }

                    tb_total.Text = clientesConectados.Count.ToString();
                    tb_chat.Text += recibirString;

                    //finalmente recorre todos los elementos del la lista para enviarles los mensajes que van
                    //a mostrar en su propia ventana de chat
                    foreach (IPEndPoint endpoint in clientesConectados)
                    {
                        if (!endpoint.Equals(clienteEP))
                        {
                            await socketServidor.SendAsync(recibir, recibirString.Length, endpoint);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Problema con el servidor. Ver error para saber mas: " + ex.Message);
            }
        }

        //metodo que se ejecuta al clickear en el boton de parar el servidor, envia mensaje de fin a todos los clientes con un foreach, vacia la lista y cierra el socket del servidor
        private async void btn_parar_Click(object sender, EventArgs e)
        {
            //gestion de los controles del formulario
            btn_arrancar.Enabled = true;  
            btn_parar.Enabled = false;
            
            //limpiar los textbox y el listbox
            tb_chat.Clear();
            tb_total.Clear();
            lb_clientes.Items.Clear();

            byte[] enviar = Encoding.UTF8.GetBytes("FIN");

            foreach (IPEndPoint endpoint in clientesConectados)
            {
                try
                {
                    await socketServidor.SendAsync(enviar, enviar.Length, endpoint);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Problema al enviar el mensaje. Ver error para saber mas: " + ex.Message);
                }
            }

            clientesConectados.Clear(); 
        }
    }
}
