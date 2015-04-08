namespace EasterFarm.TestWPF.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class MatrixToLeftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringMatrix = value.ToString();
            string[] stringArray = stringMatrix.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int result = (int.Parse(stringArray[1]) - 1) * 32;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not needed
        }
    }
}
