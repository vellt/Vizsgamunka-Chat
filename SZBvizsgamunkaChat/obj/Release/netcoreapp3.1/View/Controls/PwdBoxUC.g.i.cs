﻿#pragma checksum "..\..\..\..\..\View\Controls\PwdBoxUC.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63293B609CA701F6CA7B4D7E8AEC97A76CDDA3CC"
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
    /// PwdBoxUC
    /// </summary>
    public partial class PwdBoxUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\..\View\Controls\PwdBoxUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SZBvizsgamunkaChat.View.Controls.PwdBoxUC pwdBoxControl;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\View\Controls\PwdBoxUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl PlaceHolderContent;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\View\Controls\PwdBoxUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwdBoxContent;
        
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
            System.Uri resourceLocater = new System.Uri("/SZBvizsgamunkaChat;component/view/controls/pwdboxuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Controls\PwdBoxUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.pwdBoxControl = ((SZBvizsgamunkaChat.View.Controls.PwdBoxUC)(target));
            return;
            case 2:
            this.PlaceHolderContent = ((System.Windows.Controls.ContentControl)(target));
            
            #line 11 "..\..\..\..\..\View\Controls\PwdBoxUC.xaml"
            this.PlaceHolderContent.GotFocus += new System.Windows.RoutedEventHandler(this.PlaceHolderContent_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pwdBoxContent = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 12 "..\..\..\..\..\View\Controls\PwdBoxUC.xaml"
            this.pwdBoxContent.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
