﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD643EFFAC5B1C90D3C401245E7E630F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace Youtube_music_WPF {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Send;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox cResData;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox vResData;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser wbMain;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelOption;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox themeSwitch;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CheckUpdates_Button;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_Loop;
        
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
            System.Uri resourceLocater = new System.Uri("/Youtube music;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 10 "..\..\MainWindow.xaml"
            ((Youtube_music_WPF.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Send = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.Send.Click += new System.Windows.RoutedEventHandler(this.button1_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\MainWindow.xaml"
            this.searchBox.GotFocus += new System.Windows.RoutedEventHandler(this.SearchBox_FirstFocus);
            
            #line default
            #line hidden
            
            #line 34 "..\..\MainWindow.xaml"
            this.searchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchBox_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cResData = ((System.Windows.Controls.ListBox)(target));
            
            #line 45 "..\..\MainWindow.xaml"
            this.cResData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cResData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.vResData = ((System.Windows.Controls.ListBox)(target));
            
            #line 64 "..\..\MainWindow.xaml"
            this.vResData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.VResData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.wbMain = ((System.Windows.Controls.WebBrowser)(target));
            return;
            case 7:
            this.labelOption = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.themeSwitch = ((System.Windows.Controls.CheckBox)(target));
            
            #line 81 "..\..\MainWindow.xaml"
            this.themeSwitch.Unchecked += new System.Windows.RoutedEventHandler(this.themeSwitch_Unchecked);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            this.themeSwitch.Checked += new System.Windows.RoutedEventHandler(this.themeSwitch_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CheckUpdates_Button = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\MainWindow.xaml"
            this.CheckUpdates_Button.Click += new System.Windows.RoutedEventHandler(this.CheckUpdates_Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.checkBox_Loop = ((System.Windows.Controls.CheckBox)(target));
            
            #line 83 "..\..\MainWindow.xaml"
            this.checkBox_Loop.Unchecked += new System.Windows.RoutedEventHandler(this.checkBox_Loop_Unchecked);
            
            #line default
            #line hidden
            
            #line 83 "..\..\MainWindow.xaml"
            this.checkBox_Loop.Checked += new System.Windows.RoutedEventHandler(this.checkBox_Loop_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
