﻿#pragma checksum "..\..\MovableBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "657541DBB889F809D34FB82F9D41AF4A0D5F84B5E00CA1EF5FBBC5DAF32CA9BF"
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


namespace Console {
    
    
    /// <summary>
    /// MovableBox
    /// </summary>
    public partial class MovableBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\MovableBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border DraggableBorder;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MovableBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MovableBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ContentTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\MovableBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ToggleModifyEditButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\MovableBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ModifyButtonsPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/Console;component/movablebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MovableBox.xaml"
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
            
            #line 4 "..\..\MovableBox.xaml"
            ((Console.MovableBox)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UserControl_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 5 "..\..\MovableBox.xaml"
            ((Console.MovableBox)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.UserControl_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 6 "..\..\MovableBox.xaml"
            ((Console.MovableBox)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.UserControl_MouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DraggableBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.TitleTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\MovableBox.xaml"
            this.TitleTextBox.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.ContentTitleBox_GotKeyboardFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ContentTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\MovableBox.xaml"
            this.ContentTextBox.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.ContentTextBox_GotKeyboardFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ToggleModifyEditButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\MovableBox.xaml"
            this.ToggleModifyEditButton.Click += new System.Windows.RoutedEventHandler(this.ToggleModifyEditButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ModifyButtonsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            
            #line 61 "..\..\MovableBox.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

