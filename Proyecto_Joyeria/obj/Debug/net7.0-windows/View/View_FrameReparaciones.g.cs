﻿#pragma checksum "..\..\..\..\View\View_FrameReparaciones.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FE5723DF963B520897B6C3BE6B63EDA4D3AB0CA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Proyecto_Joyeria.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Proyecto_Joyeria.View {
    
    
    /// <summary>
    /// View_FrameReparaciones
    /// </summary>
    public partial class View_FrameReparaciones : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\..\View\View_FrameReparaciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridProductosUsuarios;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\View\View_FrameReparaciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBuscarProducto;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\View\View_FrameReparaciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBuscarProductoUsuario;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\View\View_FrameReparaciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregarProductoUsuario;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\View\View_FrameReparaciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridMostrarProductosUsuarios;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\View\View_FrameReparaciones.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame introducirProducto;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Proyecto_Joyeria;component/view/view_framereparaciones.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\View_FrameReparaciones.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridProductosUsuarios = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtBuscarProducto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnBuscarProductoUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\..\View\View_FrameReparaciones.xaml"
            this.btnBuscarProductoUsuario.Click += new System.Windows.RoutedEventHandler(this.buscarProducto);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAgregarProductoUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\View\View_FrameReparaciones.xaml"
            this.btnAgregarProductoUsuario.Click += new System.Windows.RoutedEventHandler(this.btnAñadirProducto);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGridMostrarProductosUsuarios = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.introducirProducto = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 129 "..\..\..\..\View\View_FrameReparaciones.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.clickFila);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

