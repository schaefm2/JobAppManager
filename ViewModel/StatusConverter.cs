using System;
using System.Globalization;
using System.Windows.Data;

namespace JobAppManager.ViewModel;
public class StatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null && value.ToString() == parameter.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((bool)value)
            return parameter.ToString();
        return Binding.DoNothing;
    }
}