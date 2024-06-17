using System;
using System.Net;
using Newtonsoft.Json;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;

namespace PSP04__TE1_PeliculasBirt
{
    public partial class Form1 : Form
    {
        private string urlAPI = $"http://www.omdbapi.com/?apikey=";
        private string apikey = "573e9fed";
        private string tipo = "movie";
        private List<Movie> listaPeliculas = new List<Movie>();

        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.SelectionChanged += new System.EventHandler(dataGridView1_SelectionChanged);
        }

        //metodo que se ejecuta al pulsar el boton de busqueda, obtiene el texto introducido y lo usa para la consulta a la API
        //una vez que obtiene la respuesta, deserializa el json y de eso obtenemos una lista de obj Movie
        //despues se añaden filas a la tabla con el contenido de la lista
        private async void btn_busqueda_Click(object sender, EventArgs e)
        {
            //vaciar el datagrid y la lista de peliculas del contenido anterior cada vez que se pulsa el boton
            //tambien se vuelve a deshabilitar el panel2
            this.dataGridView1.Rows.Clear();
            this.listaPeliculas = new List<Movie>();
            this.panel2.Enabled = false;
            this.tb_respuesta_ftp.Clear();
            this.tb_respuesta_mail.Clear();

            string busqueda = tb_busqueda.Text;
            string urlBusqueda = urlAPI + apikey + "&s=" + busqueda + "&type=" + tipo;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlBusqueda))
            {
                string datosPeliculas = await response.Content.ReadAsStringAsync();
                RespuestaPeliculaSearch resultadoPeliculas = JsonConvert.DeserializeObject<RespuestaPeliculaSearch>(datosPeliculas);

                this.listaPeliculas = resultadoPeliculas.Search;

                if (listaPeliculas != null)
                {
                    int cont = 1;
                    foreach (Movie peli in listaPeliculas)
                    {
                        this.dataGridView1.Rows.Add(cont, peli.Title, peli.Year);
                        cont++;
                    } 
                } else
                {
                    MessageBox.Show("No se encuentran peliculas con ese titulo");
                }
            }
        }
        
        //metodo que se ejecuta al pulsar una de las filas del datagrid, obtenemos el index del objeto seleccionado
        //usamos el index para usarlo y buscar ese mismo objeto en la listaPeliculas que contiene todos los datos incluido el ImdbId
        //ese id se usa para otra consulta a la api y se pone el resultado en el textbox2 y la caratula en el picturebox1
        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string idPeli = "";
            this.textBox2.Clear();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indiceSeleccion = dataGridView1.SelectedRows[0].Index;
                Movie peliculaSeleccionada = this.listaPeliculas[indiceSeleccion];
                idPeli = peliculaSeleccionada.ImdbID;
            }

            string urlId = urlAPI + apikey + "&i=" + idPeli + "&type=" + tipo;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(urlId))
            {
                string datosPeliculas = await response.Content.ReadAsStringAsync();
                RespuestaPeliculaID resultadoPelicula = JsonConvert.DeserializeObject<RespuestaPeliculaID>(datosPeliculas);

                this.textBox2.AppendText("Titulo: "+resultadoPelicula.Title+ "\r\n");
                this.textBox2.AppendText("Año: "+resultadoPelicula.Year+ "\r\n");
                this.textBox2.AppendText("Duración: "+resultadoPelicula.Runtime+"\r\n");
                this.textBox2.AppendText("Actores: "+resultadoPelicula.Actors +"\r\n");
                this.textBox2.AppendText("Nota: "+resultadoPelicula.imdbRating +"\r\n");
                this.textBox2.AppendText("Resumen: "+resultadoPelicula.Plot +"\r\n");
                
                this.pictureBox1.ImageLocation = resultadoPelicula.Poster;
            }
        }

        private void btn_FTP_Click(object sender, EventArgs e)
        {
            this.panel2.Enabled = true;
        }

        private void btn_FTP_Mail_Click(object sender, EventArgs e)
        {
            string servidorFtp = this.tb_servidor.Text;
            string usuarioFtp = this.tb_usuario.Text;
            string pwdFtp = this.tb_pwd.Text;
            string rutaTxt = "";

            if (!string.IsNullOrEmpty(this.textBox2.Text))
            {
                try
                {
                    rutaTxt = Path.Combine(Directory.GetCurrentDirectory(),"../../fichero.txt");
                    File.WriteAllText(rutaTxt, this.textBox2.Text);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Ocurrió un error al intentar guardar el archivo: " + ex.Message);
                }
            }
            
            string respuestaFtp = subirArchivoFtp(servidorFtp, usuarioFtp, pwdFtp, rutaTxt);
            this.tb_respuesta_ftp.Text = respuestaFtp;
            MessageBox.Show(respuestaFtp);

            string respuestaMail = enviarCorreo();
            this.tb_respuesta_mail.Text = respuestaMail;
            MessageBox.Show(respuestaMail);
        }

        private string subirArchivoFtp(string servidor, string usuario, string pwd, string ruta)
        {
            string respuesta = "";

            try
            {
                //creamos una conexión FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + servidor + "//" + "fichero.txt");
                
                //Si no se especifican las credenciales se asignan unas credenciales de tipo anónimas. El servidor lo deberá permitir.
                request.Credentials = new NetworkCredential(usuario, pwd);

                //Recogemos en el atributo Method el tipo de acción que vamos a realizar: en este caso subir un fichero.
                request.Method = WebRequestMethods.Ftp.UploadFile;

                byte[] fileContents;

                //se controla las excepciones en caso de que las credenciales de acceso no sean validas
                try
                {
                    //Recogemos el contenido del fichero en un buffer
                    using (StreamReader sourceStream = new StreamReader(ruta))
                    {
                        fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                    }

                    //Recogemos en el atributo ContentLength del objeto request
                    request.ContentLength = fileContents.Length;

                    //Creamos un objeto de tipo Stream para enviar la información
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }

                    //Se espera la respuesta y se muestra por consola.
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        return "Fichero subido con codigo: " + response.StatusDescription;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problema al realizar la conexion al sevidor. Ver el mensaje para saber mas:\n" + e.Message);
                    return respuesta;
                }
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show("Error al realizar conexion ftp. Ver el mensaje para saber mas:\n" + ex.Message);
                return respuesta;
            }
        }

        //metodo para el envio el correo mediante SMTP
        private string enviarCorreo()
        {
            //variables para la conexion smtp
            string host = "smtp.gmail.com";
            int port = 587;
            bool usaSSL = false;
            string contrasenaEmisor = "zilndbshahkvqbcn";
            //string contrasenaEmisor = "hola";

            //variables para el correo electronico
            string direccionDestino = "birtpsp@gmail.com";
            //string direccionDestino = "hola";
            string nombreDestino = "BirtPsp";
            string direccionEmisor = "pruebasmtpbirt@gmail.com";
            string nombreEmisor = "PeliculasBirt";
            string sujeto = "infopeli";
            string body = this.textBox2.Text;

            //recoger datos del mensaje
            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress(nombreEmisor, direccionEmisor));
            mensaje.To.Add(new MailboxAddress(nombreDestino, direccionDestino));
            mensaje.Subject = sujeto;
            mensaje.Body = new TextPart("plain")
            {
                Text = body
            };

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
                    return "Email enviado.";
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Error al autenticarse en el servidor de gmail: " + e.ToString());
                    return "Email no enviado";
                }

                //desconexion para que se envie
                client.Disconnect(true);
            }
        }
    }
    
    //estructura de clases para el json deserializado de la consulta a la API por search
    public class RespuestaPeliculaSearch
    {
        public List<Movie> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    //estructura de clases para el json deserializado de la consulta a la API por id
    public class RespuestaPeliculaID
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
