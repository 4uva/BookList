using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BookList.View.Converters
{
    class PriceToBrushConverter : IMultiValueConverter
    {
        static Color minColor = Colors.Green, middleColor = Colors.Yellow, maxColor = Colors.Red;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Contains(DependencyProperty.UnsetValue))
                return Binding.DoNothing;
            decimal price = (decimal)values[0];
            decimal minPrice = (decimal)values[1];
            decimal maxPrice = (decimal)values[2];
            var color = GetColor(price, minPrice, maxPrice);
            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();

        Color GetColor(decimal price, decimal minPrice, decimal maxPrice)
        {
            if (minPrice >= maxPrice)
                return minColor;
            var fraction = (double)(price - minPrice) / (double)(maxPrice - minPrice);
            if (fraction < 0.5)
                return Interpolate(minColor, middleColor, fraction * 2); // from green to yellow
            else
                return Interpolate(middleColor, maxColor, fraction * 2 - 1); // from yellow to red
        }

        Color Interpolate(Color c1, Color c2, double fraction)
        {
            double r = Interpolate(c1.R, c2.R, fraction);
            double g = Interpolate(c1.G, c2.G, fraction);
            double b = Interpolate(c1.B, c2.B, fraction);
            return Color.FromRgb((byte)Math.Round(r), (byte)Math.Round(g), (byte)Math.Round(b));
        }

        double Interpolate(double d1, double d2, double fraction) => d1 + (d2 - d1) * fraction;
    }
}
