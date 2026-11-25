using System.Windows;
using System.Windows.Controls;

namespace SspLabs;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource is not Button { Tag: string name }) return;
        var type = typeof(MainWindow).Assembly.GetType($"SspLabs.{name}")
                   ?? throw new InvalidOperationException($"Window type not found: {name}");
        ((Window)Activator.CreateInstance(type)!).Show();
    }
}
