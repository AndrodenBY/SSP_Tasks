using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Ink;
using System.Windows.Media;

namespace SspLabs.Lab7;

public partial class Task2Window : Window { public Task2Window() => InitializeComponent(); }
public partial class Task4Window : Window { public Task4Window() => InitializeComponent(); }

// DrawingAttributes is not a DependencyObject, so its Color/Width cannot be binding targets.
// Instead bind the whole InkCanvas.DefaultDrawingAttributes to (color, size).
public sealed class DrawingAttributesConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var color = values[0] is Color c ? c : Colors.Black;
        var size = values[1] is double d ? d : 2;
        return new DrawingAttributes { Color = color, Width = size, Height = size };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
