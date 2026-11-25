using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace SspLabs.Lab9;

public partial class Task1Window : Window
{
    private const double Jump = 120;
    private readonly Random _random = new();

    public Task1Window() => InitializeComponent();

    private void Runner_MouseEnter(object sender, MouseEventArgs e)
    {
        var mouse = e.GetPosition(Field);
        double left = Canvas.GetLeft(Runner), top = Canvas.GetTop(Runner);

        // Move away from the cursor: direction = button center - cursor.
        double dx = left + Runner.ActualWidth / 2 - mouse.X;
        double dy = top + Runner.ActualHeight / 2 - mouse.Y;
        double length = Math.Max(Math.Sqrt(dx * dx + dy * dy), 1);
        double newLeft = left + dx / length * Jump;
        double newTop = top + dy / length * Jump;

        // Cornered against a wall: jump to a random place inside the window instead.
        double maxLeft = Field.ActualWidth - Runner.ActualWidth;
        double maxTop = Field.ActualHeight - Runner.ActualHeight;
        if (newLeft < 0 || newTop < 0 || newLeft > maxLeft || newTop > maxTop)
        {
            newLeft = _random.NextDouble() * maxLeft;
            newTop = _random.NextDouble() * maxTop;
        }

        var duration = TimeSpan.FromMilliseconds(250);
        var ease = new QuadraticEase { EasingMode = EasingMode.EaseOut };
        Runner.BeginAnimation(Canvas.LeftProperty, new DoubleAnimation(newLeft, duration) { EasingFunction = ease });
        Runner.BeginAnimation(Canvas.TopProperty, new DoubleAnimation(newTop, duration) { EasingFunction = ease });
    }

    // Reachable with the keyboard (Tab + Space) — the honest way to win.
    private void Runner_Click(object sender, RoutedEventArgs e) => MessageBox.Show(this, "Поймал!", "Убегающая кнопка");
}
