﻿#pragma checksum "..\..\..\widok\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5B2747B854B42E64A18D8323C12C3402"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace wzorce.widok {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeView;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid mDgr;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid kDgr;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZakonczZakupy;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox iloscTow;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Kupuj;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Koszty;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NowaCena;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZmianaCeny;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\widok\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button hist;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFprojekt;component/widok/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\widok\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.treeView = ((System.Windows.Controls.TreeView)(target));
            return;
            case 2:
            
            #line 24 "..\..\..\widok\MainWindow.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.treeViewMebleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 26 "..\..\..\widok\MainWindow.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.treeViewPokojoweClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 33 "..\..\..\widok\MainWindow.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.treeViewBiuroweClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mDgr = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.kDgr = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.ZakonczZakupy = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\widok\MainWindow.xaml"
            this.ZakonczZakupy.Click += new System.Windows.RoutedEventHandler(this.ZakonczZakup_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.iloscTow = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Kupuj = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\widok\MainWindow.xaml"
            this.Kupuj.Click += new System.Windows.RoutedEventHandler(this.Kupuj_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Koszty = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.NowaCena = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.ZmianaCeny = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\widok\MainWindow.xaml"
            this.ZmianaCeny.Click += new System.Windows.RoutedEventHandler(this.ZmienCeneClick);
            
            #line default
            #line hidden
            return;
            case 13:
            this.hist = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\widok\MainWindow.xaml"
            this.hist.Click += new System.Windows.RoutedEventHandler(this.hist_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
