﻿#pragma checksum "C:\Users\mattc\Desktop\C#\myApp\App1\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EDA9F04CCCDE14BC841156B3414BD5A4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App1
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Grid element1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 10 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element1).Loaded += this.Grid_Loaded;
                    #line default
                }
                break;
            case 2:
                {
                    this.MoodList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 14 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.MoodList).SelectionChanged += this.SelectionChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.webview = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            case 4:
                {
                    this.welcome = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.welcome2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
