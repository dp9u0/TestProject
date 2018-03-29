// FileName:  TitleConverter.cs
// Author:  guodp <guodp9u0@gmail.com>
// Create Date:  20170914 09:48
// Description:   

#region

using System;
using System.Globalization;
using System.Windows.Data;

#endregion

namespace CefSharp.Example.Wpf {

    public class TitleConverter : IValueConverter {

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return "CefSharp.Example.Wpf - " + (value ?? "No Title Specified");
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return Binding.DoNothing;
        }

    }

}