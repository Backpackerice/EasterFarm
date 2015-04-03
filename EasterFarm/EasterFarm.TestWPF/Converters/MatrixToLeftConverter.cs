using EasterFarm.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EasterFarm.TestWPF.Converters
{
    public class MatrixToLeftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            string stringMatrix = value.ToString();
            string[] stringArray = stringMatrix.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int result = Int32.Parse(stringArray[1]) * 40;
            return result;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null; // Not needed
        }
    }
}
