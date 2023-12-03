using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xaml;

namespace ExtrateWares
{
    /// <summary>
    /// Lógica de interacción para GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        //Declaracion de variables

        Boolean cerrar = false;
        // rutas de img
        List<String> hardwares = new List<String>() ;
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool mvIzq, mvDer;


        //Array encargado de eliminar los objetos que caigan y los que se generen
        List <Rectangle> quitarObjetos = new List <Rectangle> ();
      
        // Boolean encargados de establecer la dificultad
        Boolean isFacil = false, isMedio = false, isDificil = false;

        //Otras variables
        Random random = new Random();
        // COntador enemigos va a "establecer la dificultad", debido al gameloop, será la variable encargada de indicar cuantos enemigos se hande generar
        int contadorEnemigos = 100;

        //Otras variables
        int idEnemigo= 0;
        int vJugador = 10;
        int limite = 50;
        int score = 0;
        int hpPlayer = 100;
        int vEnemigos = 1;
        int nPantalla = 0, nPlaca = 0, nProcesador = 0, nRam = 0, nRaton = 0, nSsd = 0, nTeclado = 0;

        Rect hitBoxJugador;

        //imagenes de los ocmponentes
        ImageBrush pantalla, placa, procesador, ram, raton, ssd, teclado;

        // creamos el GameWindow con los parámetros pasados desde la ventana incial
        public GameWindow(int factorVelocidad, bool facil, bool medio, bool dificil, Uri fondoPantalla)
        {
            InitializeComponent();

            //establecemos cada imagen de cada componente que va a caer
            pantalla = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/pantalla.png")));
            placa = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/placa base.png")));
            procesador = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/procesador.png")));
            ram = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/ram.png")));
            raton = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/raton.png")));
            ssd = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/ssd.png")));
            teclado = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Assets/hardware/teclado.png")));


            // Establecemos la dificultad en base a los paámetros pasados desde la ventana de inicio
            isFacil = facil;
            isMedio = medio;    
            isDificil = dificil;
            vEnemigos = vEnemigos * factorVelocidad;


            //Creamos el GameTimer, encargado de realizar el GameLoop
            // esto quiere decir, lo uqe hará el juego en cada "vuelta" de refresco (Hz), establecido a 20 ms
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += Loop;
            gameTimer.Start();

            // con el focusable, escucha los eventos de click
            canvasJuego.Focus();

            //establecemos una imagen de fondo, de estilo "Tiles", para cada dificultad
            ImageBrush imgBg = new ImageBrush();
            imgBg.ImageSource = new BitmapImage(fondoPantalla);
            imgBg.TileMode = TileMode.Tile;
            imgBg.Viewport = new Rect(0,0, .15, .15);
            imgBg.ViewboxUnits = BrushMappingMode.RelativeToBoundingBox;
            canvasJuego.Background = imgBg;
            

            // Establecemos el Label dificultad en base a la dificultad seleccionada de la ventan de inicio
            if (isFacil)
            {
                dificultad.Content = "Dificulad: Facil"; 
            }
            if (isMedio)
            {
                dificultad.Content = "Dificulad: Media";
            }
            if (isDificil)
            {
                dificultad.Content = "Dificulad: Dificil";
            }

            //establecemos la imagen del jugador como la imagen de la nave

            ImageBrush imgPj = new ImageBrush();
            imgPj.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/player.png"));
            jugador.Fill = imgPj;

            //cargamos las imagenes de todos los componentes en una lista de imagenes
            hardwares = Directory.GetFiles("./Assets/hardware", "*.png").ToList();

         

        }

        // Hacemos el loop, que ocurrira en funcion del timer.Interval
        private void Loop(object sender, EventArgs e)
        {

            //analizamos la hitBox del jugador, para tenerlo trackeado cuando se mueva, esta hitbox será las coordenadas 
            //compuestas por el jugador, todo lo que esté dentro de esta hitbox significará que está dentro de estas coordenadas
            hitBoxJugador = new Rect(Canvas.GetLeft(jugador), Canvas.GetTop(jugador), jugador.Width, jugador.Height);

            // disminuimos la cantidad de enemigos totales (para que en un futuro aparezcan mas)
            contadorEnemigos -=1;

            // actualizamos los labels de puntuacion y vida
            puntuacion.Content = "Puntuación: " + score;
            vida.Content = "Vida: " + hpPlayer;

            // si el contador de enemigos dentro del canvas es menor que 0 (cada 20ms es -1, se tarda 2s en generar 1 enemigo)
            if (contadorEnemigos < 0)
            {
                crearEnemigos();
                contadorEnemigos = limite;
            }


            // Si el jugador se desplaza hacia la izquierda y se encuentra dentro de las coordenadas permitidas para el movimiento del jugador
            // (sin salir de la pantalla), entonces podrá moverse hacia la izquierda.
            if (mvIzq == true && Canvas.GetLeft(jugador) > 0)
            {
                Canvas.SetLeft(jugador, Canvas.GetLeft(jugador) - vJugador);
            }



            // Si el jugador se desplaza hacia la derecha y se encuentra dentro de las coordenadas permitidas para el movimiento del jugador
            // (sin salir de la pantalla), entonces podrá moverse hacia la derecha.
            if (mvDer == true && (Canvas.GetLeft(jugador) + 85) < canvasJuego.Width)
            {
                Canvas.SetLeft(jugador, Canvas.GetLeft(jugador) + vJugador);
            }

            //Aqui se comprueba si la bala ha chocado con los componentes
            // la bala se crea en la linea 383


            //Se crea un for each para comprobar todos los elementos de tipo Rectangle que estan dentro del canvas
            foreach (var x in canvasJuego.Children.OfType<Rectangle>())
            {
                // en el caso de que el elemento que contenga el for-each tenga un tag "bala"
                if (x is Rectangle && (string)x.Tag == "bala")
                {
                    //por cada loop (recordemos, 20ms) subirá una altura definida de 20 hacia arriba (por cada loop subirá 20 hacia arriba)
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);

                    //Creamos una "hitbox" (cuadrante de coordenadas) para esa bala, ya que es el objeto que estamos analizando en el for-each
                    Rect hitBoxBala = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    // en el caso de que se a una "bala perdida", se añade a la lista de quitarObjetos para quitarla del canvas y que no utilice mas memoria
                    if (Canvas.GetTop(x) < 10)
                    {
                        quitarObjetos.Add(x);                    
                    }

                    //A su vez, se analizand otros objetos dentro del canvas, que sean rectangle
                    foreach (var y in canvasJuego.Children.OfType<Rectangle>())
                    {
                        //estos objetos, serán aquellos con el tag "enemigo"
                        if (y is Rectangle && y.Tag is string besos && besos.StartsWith("enemigo"))
                        {

                            // Y se les establece también un hitbox o espacio de coordenadas
                            Rect hardwareHit= new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);


                            // Entonces, en el caso de que el hitbox de la bala y el hitbox del "enemigo" coincidan ,significará que la bala ha chocado cone el componente que está cayendo
                            // por lo que lo habrá "destruido"
                            if (hitBoxBala.IntersectsWith(hardwareHit))
                            {
                               //en ese caso, se le añade al array para quitar el objeto bala como el objeto enemigo
                                quitarObjetos.Add(y);
                                quitarObjetos.Add(x);
                                // se aumenta la puntuacion por haber acertado
                                score++;
                                // se llama al metodo que aumenta la puntuacion especifica en funcion de el componente que se haya destruido
                                puntosImagenesHardware(y);
                                
                            }
                        }

                    }

                }

                // Una vez posicionado el enemigo (se encuentra un poco más abajo en el código), este if hace que por cada loop ( cada vuelta establecida por cada 20ms) 
                // aquellos rectangle con tag "enemigo" se encarguen de "bajar" una distancia establecida como vEnemigos (velocidad enemigos)

                if (x is Rectangle && x.Tag is string tag && tag.StartsWith("enemigo"))
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + vEnemigos);

                    // Se les crea la hitbox con la cual van a interactuar con el canvas
                    Rect hitBoxEnemigo = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    // en el caso de que este rectangulo haya sobrepasado la altura del canvas, significará que el jugador no le ha disparado
                    // por lo que se le restará vida al jugador, ya que ha "fallado" el disparo
                    if (Canvas.GetTop(x) > 750)
                    {
                        quitarObjetos.Add(x);                      
                        hpPlayer -= 10;
                    }

                    // también puede ser que e lcomponente haya chocado con el jugador, en este caso de utiliza la hitbox para comprobar que ha interseccionado 
                    // con la hitbox del jugador, y también se le restará vida
                    if (hitBoxJugador.IntersectsWith(hitBoxEnemigo))
                    {
                        quitarObjetos.Add(x);
                        hpPlayer -= 5;
                    }

                    // Una vez se haya sobrepasado la altura del canvas o se haya chocado con el jugador, se eliminará el componente del canvas
                }
               
            }

            // Se encarga de remover aquellos enemigos que se han añadido al array
            foreach (Rectangle i in quitarObjetos)
            {
                canvasJuego.Children.Remove(i);    
            }
          

            // establece la velocidad a la que han de caer los enemigos.
            // esta velocidad dependerá de la dificultad inicial cona la que se haya establecido el juego (facil, medio o dificil) y de la puntuación que tenga el jugador en cada momento

            calcularVelocidad(score);


            // Comprobamos en el caso de que la vida del jugador llegue a 0

            if (hpPlayer < 0)
            {
                // para el loop
                gameTimer.Stop();
                hpPlayer = 0;
                // te dice que "has muerto"
                vida.Content = "HAS MUERTO";
                // te lo señala en rojo
                vida.Foreground = Brushes.Red;

                // te muestra un mensaje con los componentes que has destruido
                MessageBox.Show("Has destruido " + score + " componentes. Unlucky" +
                    Environment.NewLine + "Has destruido:" +
                    Environment.NewLine + nPantalla + " Pantalla/s" +
                    Environment.NewLine + nPlaca + " Placa/s Base/s" +
                    Environment.NewLine + nProcesador + " Procesador/es" +
                    Environment.NewLine + nRam + " Memoria/s Ram" +
                    Environment.NewLine + nRaton + " Raton/es" +
                    Environment.NewLine + nSsd + " Memoria/s Ssd" +
                    Environment.NewLine + nTeclado + " Teclado/s" +
                    Environment.NewLine + "Mejor suerte la próxima vez", "FIN DEL JUEGO");

               
                // en el caso de que perdamos, nos devolverá a la ventana de inicio, para vovler a elegir la dificultad
               
                MainWindow inicio = new MainWindow();
                inicio.Show();
                cerrar = true;
                this.Close();

            
            }

        }

        // establece la velocidad a la que han de caer los enemigos.
        // esta velocidad dependerá de la dificultad inicial cona la que se haya establecido el juego (facil, medio o dificil) y de la puntuación que tenga el jugador en cada momento
        // también estableceremos el label invisible que se encarga de decirno se nque nivel se encuentra el jugador dentro de cada dificultad (lvl1, lvl2 o lvl3)
        private void calcularVelocidad(int score)
        {
            if (score <10)
            {
                nivel.Content = "Lvl: 1";
            }

            if (score > 10 && score < 20 && isFacil)
            {
                nivel.Content = "Lvl: 2";
                limite = 40;
                vEnemigos = 9;              
            }
            if (score > 20 && isFacil)
            {
                nivel.Content = "Lvl: 3";
                limite = 30;
                vEnemigos = 11;
            }

            if (score > 10 && score < 20 && isMedio)
            {
                nivel.Content = "Lvl: 2";
                limite = 35;
                vEnemigos = 11;       
            }
            if (score > 20 && isMedio)
            {
                nivel.Content = "Lvl: 3";
                limite = 30;
                vEnemigos = 13;
            }

            if (score > 10 && score < 20 && isDificil)
            {
                nivel.Content = "Lvl: 2";
                limite = 30;
                vEnemigos = 15;              
            }
            if (score > 20 && isDificil)
            {
                nivel.Content = "Lvl: 3";
                limite = 20;
                vEnemigos = 15;
            }
        }


        // mientras pulsa, moverse a la izquierda o a la derecha se registra como verdadero, permitiendo establecer el booleano a true el tiemp oque se mantiene presionado
        // mientras se recorre el loop
        private void alPulsar(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                mvIzq = true;
            }
            if (e.Key == Key.Right)
            {
                mvDer = true;
            }
        }
        // detecta el levantar el dedo, por lo que elimina la accio nde moverse
        private void alLevantar(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
               
                mvIzq = false;

            }
            if (e.Key == Key.Right)
            {
                mvDer = false;
            }

            // detecta si se ha pulsado la barra espacioadora
            if (e.Key == Key.Space)
            {
                // en ese caso, genera un objeto de tipo rectangle, "nuevaBala", con unas caracteristicas especificas
                Rectangle nuevaBala = new Rectangle
                {
                    Tag ="bala",
                    Height=20,
                    Width=5,
                    Fill = Brushes.White,
                    Stroke = Brushes.Red
                };

                // Coloca la bala justo encima de la posicion del jugador y en medio
                Canvas.SetLeft(nuevaBala, Canvas.GetLeft(jugador) + jugador.Width/2);
                Canvas.SetTop(nuevaBala, Canvas.GetTop(jugador) - nuevaBala.Height);
                canvasJuego.Children.Add(nuevaBala);

            }

        }

        // Creamos enemigos
        private void crearEnemigos()
        {
            // asignamos imagen, y elegimos 1 enemigo de un total de 7 (hardware.Count)
            ImageBrush imgEnemigo = new ImageBrush();
            idEnemigo = random.Next(1, hardwares.Count);
            //asignamos al enemigo la imagen
            imgEnemigo.ImageSource = new BitmapImage(new Uri("pack://application:,,," + hardwares[idEnemigo]));


            //Asignamos también que el enemigo "sea" un rectangulo, con propiedades especificas
            Rectangle nuevoEnemigo = new Rectangle
            {
                Tag = "enemigo" + idEnemigo,
                Height = 50,
                Width=50,
                //que la imagen se ajuste al rectangulo
                Fill = imgEnemigo
            };

            // posicionamos el enemigo por encima de la visualización del jugador y en una posicion aleatoria dentro del canvas
            
            Canvas.SetTop(nuevoEnemigo, -50);
            Canvas.SetLeft(nuevoEnemigo, random.Next(50, 480));

            //añadimos el rectangulo enemigo al canvas
            canvasJuego.Children.Add(nuevoEnemigo);
            
        }

        // este metodo recibe el rectangulo eliminado por la bala

        private void puntosImagenesHardware(Rectangle x)
        {
            int i = 0;

            // Se realiza una evaluacion de como termina el tag del rectangulo para determinar que tip ode componente es y añadirlo como puntuación indivicual a cada imagen de componente
            
                if (x.Tag is string tag0 && tag0.EndsWith("0"))
                {
                    nPantalla++;
                    lblNPantalla.Content = "x" + nPantalla;
                }
                if (x.Tag is string tag1 && tag1.EndsWith("1"))
                {
                    nPlaca++;
                    lblNPlaca.Content = "x" + nPlaca;
                }
                if (x.Tag is string tag2 && tag2.EndsWith("2"))
                {
                    nProcesador++;
                    lblNProces.Content = "x" + nProcesador;
                }
                if (x.Tag is string tag3 && tag3.EndsWith("3"))
                {
                    nRam++;
                    lblNRam.Content = "x" + nRam;
                }
                if (x.Tag is string tag4 && tag4.EndsWith("4"))
                {
                    nRaton++;
                    lblNRaton.Content = "x" + nRaton;
                }
                if (x.Tag is string tag5 && tag5.EndsWith("5"))
                {
                    nSsd++;
                    lblNSsd.Content = "x" + nSsd;
                }
                if (x.Tag is string tag6 && tag6.EndsWith("6"))
                {
                    nTeclado++;
                    lblNTeclado.Content = "x" + nTeclado;
                }






        }

        // metodo por si quieres cerrar la aplicacion desde la cruceta
        protected override void OnClosing(CancelEventArgs e)
        {
       
            if (!cerrar)
            {
                MessageBoxResult mbr = MessageBox.Show("¿Estás seguro que deseas salir?", "Salir", MessageBoxButton.YesNo);

                if (mbr == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }

        }
    }
}
