using System;
using System.Threading;
using System.Linq;

namespace CarreraCaballos
{
    public partial class Form1 : Form
    {
        //variables globales para el programa
        static Random random = new Random();
        static int longitudCarrera = 100;
        static bool carreraAcabada = false;
        static int[] arrayPosiciones = new int[4];
        static Thread[] caballos = new Thread[4];
        static object bloqueo = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            //bucle para crear un array de threads
            for (int i = 0; i < caballos.Length; i++)
            {
                caballos[i] = new Thread(Correr);
                //uso el atributo name para poder conectar el indice de cada thread en el array con su rspectiva posicion
                //en el array donde se guardan las posiciones de los caballos
                caballos[i].Name = i.ToString();
                //se asigna una prioridad diferente a cada caballo usando Priority
                caballos[i].Priority = (ThreadPriority)(i + 1);
                caballos[i].Start();
            }
        }

        //metodo para reiniciar, es un bucle que se ejecuta solo si la variable carreraAcabada es true
        //reestablece los valores del array de posiciones, las progress bar y los label con los resultados
        //finalmente marca carreraAcabado como false para poder volver a empezar una carrera
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            if (carreraAcabada)
            {
                Array.Clear(arrayPosiciones, 0, arrayPosiciones.Length);
                pbrCaballo1.Value = 0;
                pbrCaballo2.Value = 0;
                pbrCaballo3.Value = 0;
                pbrCaballo4.Value = 0;
                lblGanador.Text = string.Empty;
                lblResultados.Text = string.Empty;

                carreraAcabada = false;

            }
        }

        //metodo Correr que es ejecutado por cada thread, uso parse para obtener el indice del thread
        //y usarlo como indice del array que almacena las posiciones de cada caballo
        //se usa un objeto para bloquear con lock y aque todos los threads manipulan el arrayPosiciones
        //se va actualizando la progress bar con el valor de avance
        //cuando un thread llega a sumar 100 o mas se interrumpe el resto cambiando carreraAcabada a true
        //se actualiza el label de resultados
        private void Correr()
        {
            int caballoId = int.Parse(Thread.CurrentThread.Name);
            int avance = random.Next(1, longitudCarrera / 10 + 1);
            while (!carreraAcabada)
            {
                lock(bloqueo)
                {
                    arrayPosiciones[caballoId] += avance;
                    ActualizarBarra(caballoId, avance);
                    if (arrayPosiciones[caballoId] > longitudCarrera)
                    {
                        carreraAcabada = true;
                        ActualizarResultados();
                    }
                    
                }
                Thread.Sleep(500);
            }
        }

        //en este metodo se actualiza con Invoke la progress bar, para ello uso el indice del array para buscar el nombre de la
        //barra que quiero actualizar en cada vuelta del bucle usando el metodo Find de la clase Control y guardando el resultado
        //como progress bar en lugar de control
        //tambien se controla que, si la suma de la barra actual y el avance es mas de 100. el valor se quede como 100 para no tener error
        private void ActualizarBarra (int caballoId, int avance)
        {
            string nombre = "pbrCaballo" + (caballoId + 1);
            ProgressBar pbr = this.Controls.Find(nombre, true).FirstOrDefault() as ProgressBar;
            if ( pbr != null )
            {
                if ( (pbr.Value + avance ) < pbr.Maximum)
                {
                    pbr.Invoke(new MethodInvoker(delegate { pbr.Value += avance; }));

                } else
                {
                    pbr.Invoke(new MethodInvoker(delegate { pbr.Value = pbr.Maximum; }));

                }
            }
        }

        //en este metodo se actualizan los label de los resultados, buscando el indice del caballo con la posicion mas alta
        //y se enseña el podio usando los valores de las progress bar, ambos mediante Invoke
        private void ActualizarResultados ()
        {
            int ganador = Array.IndexOf(arrayPosiciones, arrayPosiciones.Max()) + 1;
            lblGanador.Invoke(new MethodInvoker(delegate { lblGanador.Text = "Ganador: Caballo" + ganador; }));
            lblResultados.Invoke(new MethodInvoker(delegate {
                lblResultados.Text = "Caballo1:" + pbrCaballo1.Value +
                                 "\nCaballo2:" + pbrCaballo2.Value +
                                 "\nCaballo3:" + pbrCaballo3.Value +
                                 "\nCaballo4:" + pbrCaballo4.Value;
            }));
            
        }
    }
}
