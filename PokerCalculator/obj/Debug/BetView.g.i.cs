﻿#pragma checksum "..\..\BetView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "404A9E6CF596207B26F443710F64EB5B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PokerCalculator;
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


namespace PokerCalculator {
    
    
    /// <summary>
    /// BetView
    /// </summary>
    public partial class BetView : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\BetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox betSizeInput;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\BetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider betSizeSlider;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\BetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button foldBtn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\BetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button callBtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\BetView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button raiseBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/PokerCalculator;component/betview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BetView.xaml"
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
            this.betSizeInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.betSizeSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 3:
            this.foldBtn = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\BetView.xaml"
            this.foldBtn.Click += new System.Windows.RoutedEventHandler(this.foldBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.callBtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\BetView.xaml"
            this.callBtn.Click += new System.Windows.RoutedEventHandler(this.callBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.raiseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\BetView.xaml"
            this.raiseBtn.Click += new System.Windows.RoutedEventHandler(this.raiseBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

