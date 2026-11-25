using System.Windows;
using System.Windows.Media;

namespace SspLabs.Lab6;

public partial class Task1Window : Window
{
    public Task1Window() => InitializeComponent();

    // Color items keep a color name in Tag; other items keep a hint text.
    private static string Hint(object sender) => ((FrameworkElement)sender).Tag as string switch
    {
        "White" => "Сделать фон белым",
        "LightBlue" => "Сделать фон голубым",
        "LightGreen" => "Сделать фон зелёным",
        "Pink" => "Сделать фон розовым",
        var text => text ?? "",
    };

    private void ShowHint(object sender, RoutedEventArgs e) => Status.Text = Hint(sender);
    private void ClearHint(object sender, RoutedEventArgs e) => Status.Text = "Готово";

    private void Color_Click(object sender, RoutedEventArgs e) =>
        Background = (Brush)new BrushConverter().ConvertFromString((string)((FrameworkElement)sender).Tag)!;

    private void About_Click(object sender, RoutedEventArgs e) =>
        MessageBox.Show(this, "Разработчик: студент группы ...\nЛабораторная работа № 6, WPF", "О разработчике");

    private void Close_Click(object sender, RoutedEventArgs e) => Close();
}
