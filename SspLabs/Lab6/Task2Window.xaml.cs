using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SspLabs.Lab6;

public partial class Task2Window : Window
{
    public Task2Window()
    {
        InitializeComponent();
        Size_Changed(this, null!);
    }

    // Events can fire during InitializeComponent, before Canvas exists — hence the null checks.
    private void Color_Changed(object sender, SelectionChangedEventArgs e)
    {
        if (Canvas is null) return;
        var name = (string)((ComboBoxItem)ColorBox.SelectedItem).Tag;
        Canvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString(name);
    }

    private void Size_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (Canvas is null) return;
        Canvas.DefaultDrawingAttributes.Width = SizeSlider.Value;
        Canvas.DefaultDrawingAttributes.Height = SizeSlider.Value;
    }

    private void Mode_Checked(object sender, RoutedEventArgs e)
    {
        if (Canvas is null) return;
        Canvas.EditingMode = Enum.Parse<InkCanvasEditingMode>((string)((RadioButton)sender).Tag);
    }
}
