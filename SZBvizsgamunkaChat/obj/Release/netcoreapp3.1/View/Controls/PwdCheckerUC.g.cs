﻿#pragma checksum "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0492DDF99C306D0F056E918E97E39EEF8874DE04"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SZBvizsgamunkaChat.View.Controls;
using SZBvizsgamunkaChat.View.Icons;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SZBvizsgamunkaChat.View.Controls {
    
    
    /// <summary>
    /// PwdCheckerUC
    /// </summary>
    public partial class PwdCheckerUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SZBvizsgamunkaChat.View.Controls.PwdCheckerUC pwdCheckerUC;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid currentPwdCC;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SZBvizsgamunkaChat;component/view/controls/pwdcheckeruc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.pwdCheckerUC = ((SZBvizsgamunkaChat.View.Controls.PwdCheckerUC)(target));
            return;
            case 2:
            this.textBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            this.textBox.LostFocus += new System.Windows.RoutedEventHandler(this.textBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            this.textBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 26 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            this.passwordBox.LostFocus += new System.Windows.RoutedEventHandler(this.passwordBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            this.passwordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.currentPwdCC = ((System.Windows.Controls.Grid)(target));
            
            #line 28 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            this.currentPwdCC.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.currentPwdCC_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 33 "..\..\..\..\..\View\Controls\PwdCheckerUC.xaml"
            ((System.Windows.Controls.Grid)(target)).PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.eyeBTN_PreviewMouseUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
