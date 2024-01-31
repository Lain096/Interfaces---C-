using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WPF_MVVM_CRUD.Views
{
    public static class Comandos
    {
        public static readonly RoutedUICommand Buscar = new RoutedUICommand(
            "Acción para buscar producto",
            "Buscar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.B, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand CargarImagen = new RoutedUICommand(
            "Acción para cargar una imagen",
            "CargarImagen",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.I, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Guardar = new RoutedUICommand(
            "Acción para guardar un producto",
            "Guardar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.G, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Actualizar = new RoutedUICommand(
            "Acción para actualizar un producto",
            "Actualizar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Eliminar = new RoutedUICommand(
            "Acción para eliminar un producto",
            "Eliminar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand Limpiar = new RoutedUICommand(
            "Acción para limpiar datos de un producto",
            "Limpiar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.L, ModifierKeys.Alt)
            }
            );
    }
}
