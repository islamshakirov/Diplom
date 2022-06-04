﻿#pragma checksum "..\..\TranportationOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "31AE5CA701BD93ADCF8E6D8999972DC050B01E639CCD013482C2DDAE3886AF9F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ShakirovTranspComp;
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


namespace ShakirovTranspComp {
    
    
    /// <summary>
    /// TranportationOrder
    /// </summary>
    public partial class TranportationOrder : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AmountBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox NeedLoaders;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoadersBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CargoTypeSelector;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RequestButton;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExportBox;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\TranportationOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ImportBox;
        
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
            System.Uri resourceLocater = new System.Uri("/ShakirovTranspComp;component/tranportationorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TranportationOrder.xaml"
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
            this.AmountBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.NeedLoaders = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\TranportationOrder.xaml"
            this.NeedLoaders.Checked += new System.Windows.RoutedEventHandler(this.NeedLoaders_Checked);
            
            #line default
            #line hidden
            
            #line 58 "..\..\TranportationOrder.xaml"
            this.NeedLoaders.Unchecked += new System.Windows.RoutedEventHandler(this.NeedLoaders_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoadersBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CargoTypeSelector = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.RequestButton = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\TranportationOrder.xaml"
            this.RequestButton.Click += new System.Windows.RoutedEventHandler(this.RequestButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ExportBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ImportBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

