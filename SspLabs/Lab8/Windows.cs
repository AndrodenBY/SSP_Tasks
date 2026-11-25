using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace SspLabs.Lab8;

public partial class Task1Window : Window { public Task1Window() => InitializeComponent(); }

// Only the commands live in code. All look-and-feel changes are triggers in XAML.
public partial class Task2Window : Window
{
    public Task2Window() => InitializeComponent();

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Текстовые файлы|*.txt|Все файлы|*.*" };
        if (dialog.ShowDialog(this) == true) Box1.Text = File.ReadAllText(dialog.FileName);
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        Box1.Clear();
        Box2.Clear();
    }

    private void Close_Click(object sender, RoutedEventArgs e) => Close();
}
