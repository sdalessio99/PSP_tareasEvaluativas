/*
PSP05: Tarea Evaluativa
Descripción: Trabajando con Threads. El ejercicio simula carrera de caballor.
             4 caballos, simulados por threads
Fecha: 19/03/2024
 */
using System.Diagnostics;
using System.Security.Cryptography;

namespace PSP02_Carrera
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Para el fin del programa
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        //Evento al hacer click en el bot�n para empezar la carrera
        private void buttonEmpezar_Click(object sender, EventArgs e)
        {
            //Desactivamos boton para que no deje empezar dos veces la carrera
            buttonEmpezar.Enabled = false;

            //Desactivamos boton de reiniciar para que no deje reiniciar durante la carrera
            buttonReiniciar.Enabled = false;

            //No hay ganador al inicio
            ganador = -1;

            //Crear hilos

            Thread tCaballo1 = new Thread(Correr);
            Thread tCaballo2 = new Thread(Correr);
            Thread tCaballo3 = new Thread(Correr);
            Thread tCaballo4 = new Thread(Correr);

            //Marcar prioriodad a hilos
            tCaballo1.Priority = ThreadPriority.AboveNormal;
            tCaballo2.Priority = ThreadPriority.Normal;
            tCaballo3.Priority = ThreadPriority.Lowest;
            tCaballo4.Priority = ThreadPriority.BelowNormal;

            //Alias para hilo
            tCaballo1.Name = "hiloCaballo1";
            tCaballo2.Name = "hiloCaballo2";
            tCaballo3.Name = "hiloCaballo3";
            tCaballo4.Name = "hiloCaballo4";

            //Lista de hilos 
            threads.Add(tCaballo1); threads.Add(tCaballo2); threads.Add(tCaballo3); threads.Add(tCaballo4);

            //Lanzar los hilos
            tCaballo1.Start(0);
            tCaballo2.Start(1);
            tCaballo3.Start(2);
            tCaballo4.Start(3);


        }

        //Evento al pulsar el boton de reiniciar
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            //Ponemos a cero las ProgressBar
            foreach (ProgressBar pb in this.Controls.OfType<ProgressBar>())
            {
                pb.Value = 0;
            }

            //Activar el botón para volver a empezar
            buttonEmpezar.Enabled = true;

            //Limpiamos texto del resultado
            textBoxResultado.Text = "RESULTADO:";

            //Inicializar los valores avance caballo
            for (int i = 0; i < arrayAvance.Length; i++)
            {
                arrayAvance[i] = 0;
            }
            //Se inicializa valor del ganador
            ganador = -1;

            //Borramos todos los threads
            threads.Clear();

        }

        //Metodo que ejecutan los hilos para simular el avance de los caballos
        private void Correr(object id)
        {
            //Distancia recorrida por cada caballo
            int distanciaRecorrida = 0;

            //Mientras no haya ganador
            while (ganador < 0)
            {
                //Bloqueamos la parte del avance
                lock (bloqueo)
                {
                    if (ganador < 0)
                    {
                        //Avanzamos un entero random entre 1 y 10 (La barra completa son 100)
                        Random rnd = new Random();
                        int avance = rnd.Next(1, 10);

                        //El total de metros recorridos lo vamos contando
                        distanciaRecorrida += avance;

                        //Mostrar 100% en caso de ganador
                        if (distanciaRecorrida >= 100)
                        {
                            distanciaRecorrida = 100;
                            ganador = (int)id;
                        }
                        //Guardamos la distancia en su posici�n
                        arrayAvance[(int)id] = distanciaRecorrida;

                        //Actualizar progressBar del caballo
                        if ((int)id == 0)
                        {
                            Invoke(new Action(() => progressBarCaballo1.Value = distanciaRecorrida));
                        }
                        else if ((int)id == 1)
                        {
                            Invoke(new Action(() => progressBarCaballo2.Value = distanciaRecorrida));
                        }
                        else if ((int)id == 2)
                        {
                            Invoke(new Action(() => progressBarCaballo3.Value = distanciaRecorrida));
                        }
                        else if ((int)id == 3)
                        {
                            Invoke(new Action(() => progressBarCaballo4.Value = distanciaRecorrida));
                        }


                        //Muestra resultado ganador
                        if (ganador >= 0)
                        {
                            MostrarResultado(ganador);
                            //Activar botón reiniciar
                            Invoke(new Action(() => buttonReiniciar.Enabled = true));
                        }
                    }

                }
                //Espera
                Thread.Sleep(200);
            }
        }

        //M�todo para mostrar el resultado en el textBox
        private void MostrarResultado(int ganador)
        {
            Invoke(new Action(() => textBoxResultado.Text = "RESULTADO: " + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Ganador caballo: " + (ganador + 1) + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 1: " + progressBarCaballo1.Value + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 2: " + progressBarCaballo2.Value + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 3: " + progressBarCaballo3.Value + System.Environment.NewLine));
            Invoke(new Action(() => textBoxResultado.Text += "Caballo 4: " + progressBarCaballo4.Value + System.Environment.NewLine));
        }

        //M�todo para aplicar al pulsar la X de fin de programa
        private void OnApplicationExit(object sender, EventArgs e)
        {

            try
            {
                String mensaje = "Cerramos aplicaci�n y comprobamos estado threads:\n";
                foreach (Thread th in threads)
                {
                    mensaje += th.Name + " esta vivo: " + th.IsAlive + "\n ";
                }
                MessageBox.Show(mensaje, "Fin del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

       
    }
}