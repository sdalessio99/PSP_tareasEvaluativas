using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

//Enlace a video autoevaluacio: https://youtu.be/M_qKma90VFU
namespace PSP05_TE1_GestorPass
{
    public partial class Form1 : Form
    {
        //variables necesarias para la aplicacion
        private string nombreUsuario = "";
        private string rutaTxtUsuario = "";
        private List<Contrasena> listaContrasenas = new List<Contrasena>();

        public Form1()
        {
            InitializeComponent();
        }

        //boton para confirmar que se quiere registrar un usuario nuevo
        //mira si se ha seleccionado el radio Si y validará el formato del correo, luego crea el fichero.txt
        //tambien genera una clave publica y sus metodos, y una privada que envia al correo
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                string direccionCorreo = this.textBox5.Text;
                if (validarCorreo(direccionCorreo))
                {
                    try
                    {
                        //crear txt vacio
                        using (FileStream fs = File.Create(rutaTxtUsuario)) { }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error al crear el archivo de usuario: {0}", ex.Message);
                    }

                    //generar llaves publica y privada y guardar los archivos
                    generarClavesRSA();

                    //enviar la privada al correo electronico
                    enviarCorreo(direccionCorreo);
                }
                else
                {
                    MessageBox.Show("El formato del email no es valido");
                }
            }
            else
            {
                MessageBox.Show("No has seleccionado la opcion SI");
            }
        }

        //boton de guardar y cerrar
        //tiene que guardarse la informacion para cuando se vuelve a abrir el programa
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //metodo para mostrar una contraseña seleccionada mediante su descripcion
        //se carga el fichero de la clave privada para desencrirptar la contraseña y mostrarla
        private void button3_Click(object sender, EventArgs e)
        {
            //obtener el obj seleccionado del combobox y la contraseña cifrada
            Contrasena seleccionada = (Contrasena)this.comboBox1.SelectedItem;
            byte[] contrasenaEncriptada = seleccionada.contrasena;

            //abrir el openFileDialog y obtener la ruta de la clave privada
            string rutaPrivateKF = "";
            DialogResult resultado = openFileDialog1.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                rutaPrivateKF = openFileDialog1.FileName;
                this.label6.Text = rutaPrivateKF;
            }

            byte[] contrasenaPlana = desencriptar(contrasenaEncriptada, rutaPrivateKF);
            this.textBox2.Text = Encoding.UTF8.GetString(contrasenaPlana);
        }

        //boton de registrar usuario pulsado
        //comprueba el formato del nombre de usuario y mira si ya existe un archivo correspondente o no
        //si existe, carga su fichero. si no, habilita el groupbox para registrar un usuario nuevo
        //si el fichero existe, habilita los checkbox para modificarlo
        private void button4_Click(object sender, EventArgs e)
        {
            this.groupBox4.Enabled = false;
            this.nombreUsuario = this.textBox1.Text;
            if (validarUsuario(nombreUsuario))
            {
                string nombreArchivo = nombreUsuario + ".txt";
                this.rutaTxtUsuario = Path.Combine(Directory.GetCurrentDirectory(), "../../../bbdd", nombreArchivo);

                if (File.Exists(rutaTxtUsuario))
                {
                    this.checkBox1.Enabled = true;
                    this.checkBox2.Enabled = true;
                    this.checkBox3.Enabled = true;

                    //cargar la lista con todas las contraseñas de este usuario una vez que se ha comprobado que existe
                    this.listaContrasenas = deserializarJson();
                }
                else
                {
                    this.groupBox4.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario tiene que ser:\n" +
                                "todo minusculas\n" +
                                "solo letras\n" +
                                "4-10 caracteres de longitud");
            }
        }

        //boton para guardar la contraseña insertada
        //se comprueba que cumple los requisitos, si los cumple se cifra con la clave publica
        //se guarda en el txt cifrada
        private void button5_Click(object sender, EventArgs e)
        {
            //comprobar si la contraseña es valida
            string contrasenaPlana = this.textBox4.Text;

            if (validarContrasena(contrasenaPlana))
            {
                //si lo es, cifrarla
                byte[] contrasenaCifrada = encriptar(contrasenaPlana);

                //guardar el resultado y la descripcion como un obj Contraseña en listaContraseña
                string nuevaDescripcion = this.textBox3.Text;
                this.listaContrasenas.Add(new Contrasena { descripcion = nuevaDescripcion, contrasena = contrasenaCifrada });

                //sobreescribir el archivo usuario.txt
                string json = JsonConvert.SerializeObject(listaContrasenas);
                File.WriteAllText(rutaTxtUsuario, json);
            }
            else
            {
                MessageBox.Show("La contraseña almenos tiene que contener:\n" +
                                "1 mayuscula\n" +
                                "1 minuscula\n" +
                                "1 numero\n" +
                                "1 de estos caracteres especiales:!@#&()–[{}:',?/*~$^+=<>\n" +
                                "8-20 caracteres de longitud");
            }
        }

        //metodo de pulsar boton borrar
        private void button6_Click(object sender, EventArgs e)
        {
            //obtener el obj seleccionado del combobox, quitar elemento
            Contrasena seleccionada = (Contrasena)this.comboBox2.SelectedItem;
            this.listaContrasenas.Remove(seleccionada);

            //sobreescribir el archivo usuario.txt para que quede modificado con la lista correcta
            string json = JsonConvert.SerializeObject(listaContrasenas);
            File.WriteAllText(rutaTxtUsuario, json);

        }

        //mirar si el checkbox esta marcado para establecer si el groupbox esta activo o no
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.checkBox1.Checked;
            this.groupBox1.Enabled = isChecked;
        }

        //mirar si el checkbox esta marcado para establecer si el groupbox esta activo o no
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.checkBox2.Checked;
            this.groupBox2.Enabled = isChecked;
        }

        //mirar si el checkbox esta marcado para establecer si el groupbox esta activo o no
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.checkBox3.Checked;
            this.groupBox3.Enabled = isChecked;
        }

        //metodo al desplegar el combobox
        //debera cargar las varias contraseñas guardadas y mostrar las descripciones
        private void comboBox1_DroppedDown(object sender, EventArgs e)
        {
            this.listaContrasenas = deserializarJson();
            this.comboBox1.DataSource = this.listaContrasenas;
            this.comboBox1.DisplayMember = "descripcion";
        }

        //metodo al desplegar el combobox
        //debera cargar las varias contraseñas guardadas y mostrar las descripciones
        private void comboBox2_DroppedDown(object sender, EventArgs e)
        {
            this.listaContrasenas = deserializarJson();
            this.comboBox2.DataSource = this.listaContrasenas;
            this.comboBox2.DisplayMember = "descripcion";
        }

        //metodo para validar el nombre de usuario usando regex
        private static bool validarUsuario(string usuario)
        {
            bool esValida;
            string pattern = @"^[a-z]{4,10}$";

            try
            {
                return esValida = Regex.IsMatch(usuario, pattern);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al validar el usuario: {0}", e.Message);
                return esValida = false;
            }
        }

        //metodo para validar el correo electronico usando regex
        private static bool validarCorreo(string correo)
        {
            bool esValida;
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            try
            {
                return esValida = Regex.IsMatch(correo, pattern);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al validar el correo electronico: {0}", e.Message);
                return esValida = false;
            }
        }

        //metodo para comprobar si la contraseña que se intenta guardar cumple con los requisitos usando regex
        private static bool validarContrasena(string contrasena)
        {
            bool esValida;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#&()–[{}:',?/*~$^+=<>])(?!\s)[a-zA-Z\d!@#&()–[{}:',?/*~$^+=<>]{8,20}$";

            try
            {
                return esValida = Regex.IsMatch(contrasena, pattern);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al validar la contraseña: {0}", e.Message);
                return esValida = false;
            }
        }

        //metodo para generar las claves RSA
        private void generarClavesRSA()
        {
            string rutaPublicKF = Path.Combine(Directory.GetCurrentDirectory(), "../../../publickeys", this.nombreUsuario + "_public.xml");
            string rutaPrivateKF = Path.Combine(Directory.GetCurrentDirectory(), "../../../privatekeys", this.nombreUsuario + "_private.xml");

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                //creacion clave y archivo de la publica
                string publicKey = rsa.ToXmlString(false);
                File.WriteAllText(rutaPublicKF, publicKey);

                //creacion clave y archivo de la privada
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(rutaPrivateKF, privateKey);
            }
        }

        //metodo para el envio el correo mediante SMTP
        private void enviarCorreo(string direccionDestino)
        {
            //variables para la conexion smtp
            string host = "smtp.gmail.com";
            int port = 587;
            bool usaSSL = false;
            string contrasenaEmisor = "zilndbshahkvqbcn";

            //variables para el correo electronico
            string direccionEmisor = "pruebasmtpbirt@gmail.com";
            string nombreEmisor = "BirtGestorPass";
            string sujeto = "BirtGestorPass";
            string body = "Clave de acceso a contraseñas en gestor de password.";
            string rutaPrivateKF = Path.Combine(Directory.GetCurrentDirectory(), "../../../privatekeys", this.nombreUsuario + "_private.xml");

            //recoger datos del mensaje
            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress(nombreEmisor, direccionEmisor));
            mensaje.To.Add(new MailboxAddress(this.nombreUsuario, direccionDestino));
            mensaje.Subject = sujeto;

            //crear el cuerpo del mensaje con el texto y el archivo adjunto
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;
            if (File.Exists(rutaPrivateKF))
            {
                bodyBuilder.Attachments.Add(rutaPrivateKF);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("El archivo adjunto no se encuentra en la ruta indicada");
            }
            mensaje.Body = bodyBuilder.ToMessageBody();

            //conexion al cliente smtp de google para enviar el correo
            using (var client = new SmtpClient())
            {
                //aceptar certificados
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                //conexion al servidor
                client.Connect(host, port, usaSSL);

                //autenticacion y envio del correo
                try
                {
                    client.Authenticate(direccionEmisor, contrasenaEmisor);
                    client.Send(mensaje);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Error al autenticarse en el servidor de gmail: " + e.ToString());
                }

                //desconexion para que se envie
                client.Disconnect(true);
            }
        }

        //metodo para encriptar usando algoritmo RSA
        private byte[] encriptar(string texto)
        {
            byte[] contrasenaPlana = Encoding.UTF8.GetBytes(texto);
            byte[] contrasenaEncriptada = Array.Empty<byte>();
            string rutaPublicKF = Path.Combine(Directory.GetCurrentDirectory(), "../../../publickeys", this.nombreUsuario + "_public.xml");

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;
                //leer en formato string el contenido del archivo de la clave
                string publicKey = File.ReadAllText(rutaPublicKF);
                //obtener clave desde el fichero xml
                rsa.FromXmlString(publicKey);
                //cifrado de la contrasena
                contrasenaEncriptada = rsa.Encrypt(contrasenaPlana, true);
            }

            return contrasenaEncriptada;
        }

        //metodo para desencriptar usando algoritmo RSA
        private byte[] desencriptar(byte[] contrasenaEncriptada, string rutaPrivateKF)
        {
            byte[] contrasenaPlana = Array.Empty<byte>();

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.PersistKeyInCsp = false;

                string privateKey = File.ReadAllText(rutaPrivateKF);

                rsa.FromXmlString(privateKey);

                try
                {
                    contrasenaPlana = rsa.Decrypt(contrasenaEncriptada, true);
                }
                catch (System.Security.Cryptography.CryptographicException e)
                {
                    MessageBox.Show("El archivo de clave privada seleccionado no es correcto");
                    System.Diagnostics.Debug.WriteLine("Error al intentar desencriptar la contraseña:" + e.ToString());
                }
            }

            return contrasenaPlana;
        }

        //metodo para deserializar un json a una lista de contrasenas
        private List<Contrasena> deserializarJson()
        {
            if (new FileInfo(rutaTxtUsuario).Length > 0)
            {
                string json = File.ReadAllText(rutaTxtUsuario);
                List<Contrasena> lista = JsonConvert.DeserializeObject<List<Contrasena>>(json);
                return lista;
            }
            else
            {
                return new List<Contrasena>();
            }
        }
    }

    //clase para crear objetos tipo contraseña y guardar los datos de cada una
    public class Contrasena
    {
        public string descripcion { get; set; }
        public byte[] contrasena { get; set; }
    }
}