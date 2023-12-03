using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExtrateWares
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int factorVelocidad;

        Boolean isFacil = false, isMedio = false, isDificil = false;
        Uri fondo;
        Boolean cerrar = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void click_Salir(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("¿Estás seguro que deseas salir?", "Salir", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                cerrar = true;
                
                this.Close();
            }

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
           
            if (!cerrar) {
                MessageBoxResult mbr = MessageBox.Show("¿Estás seguro que deseas salir?", "Salir", MessageBoxButton.YesNo);
                if (mbr == MessageBoxResult.Yes)
                {
                    App.Current.Shutdown();
                    //base.OnClosing(e);
                } else if (mbr == MessageBoxResult.No)
                {

                }
            }

        }

        // se inicia el juego en base a los parámetros establecidos
        private void Jugar(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow(factorVelocidad, isFacil, isMedio, isDificil, fondo);
            cerrar = true;
            Close();
            game.Show();
        }

        // metodo del radio Group en el que se establecen las variables que se le van a pasar a la pventana del juego
        // estas variables son la dificultad y el factor de velocidad de caída de los componentes asociados a la dificultad
        //También se le añade un fondo personalizado en base a la dificultad
        private void Radio_Group(object sender, EventArgs e)
        {

            if (sender is RadioButton radioButton)
            {
                if (radioButton == rdFacil)

                {
                    fondo = new Uri("pack://application:,,,/Assets/fondo1.png");
                    isFacil = true;
                    factorVelocidad = 5;
                }
                if (radioButton == rdMedio)
                {
                    fondo = new Uri("pack://application:,,,/Assets/fondo2.jpg");
                    isMedio = true;
                    factorVelocidad = 9;
                }
                if (radioButton == rdDifícil)
                {
                    fondo = new Uri("pack://application:,,,/Assets/fondo3.jpg");
                    isDificil = true;
                    factorVelocidad = 12;
                }

            }

        }
    }
}
