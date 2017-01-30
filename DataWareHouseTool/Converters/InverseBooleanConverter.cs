using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DataWareHouseTool.Converters
{
    public class InverseBooleanConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(value as bool?) ?? value;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Convert(value, targetType, parameter, culture);
    }
}