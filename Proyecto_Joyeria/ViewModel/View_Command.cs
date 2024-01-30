using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_Joyeria.ViewModel
{
    class View_Command
    {
        public static readonly RoutedUICommand Search = new RoutedUICommand(
           "Acción para buscar producto",
           "Buscar",
           typeof(View_Command),
           new InputGestureCollection()
           {
                new KeyGesture(Key.B, ModifierKeys.Alt)
           }
           );

        public static readonly RoutedUICommand UploadImg = new RoutedUICommand(
            "Acción para cargar una imagen",
            "CargarImagen",
            typeof(View_Command),
            new InputGestureCollection()
            {
                new KeyGesture(Key.I, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Save = new RoutedUICommand(
            "Acción para guardar un producto",
            "Guardar",
            typeof(View_Command),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Update = new RoutedUICommand(
            "Acción para actualizar un producto",
            "Actualizar",
            typeof(View_Command),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Delete = new RoutedUICommand(
            "Acción para eliminar un producto",
            "Eliminar",
            typeof(View_Command),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Clear = new RoutedUICommand(
            "Acción para limpiar datos de un producto",
            "Limpiar",
            typeof(View_Command),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Alt)
            }
            );
    }
}
