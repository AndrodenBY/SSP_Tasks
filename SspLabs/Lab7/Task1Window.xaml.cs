using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace SspLabs.Lab7;

public partial class Task1Window : Window
{
    public Task1Window()
    {
        // Copy the binding errors that Visual Studio shows in the Output window into the Log box.
        // Attach before InitializeComponent: bindings report errors while the tree loads.
        var buffer = new StringWriter();
        var listener = new TextWriterTraceListener(buffer);
        PresentationTraceSources.Refresh(); // without a debugger attached, WPF binding tracing is off until this call
        var source = PresentationTraceSources.DataBindingSource;
        source.Listeners.Add(listener);
        source.Switch.Level = SourceLevels.Error;

        InitializeComponent();

        Loaded += (_, _) => Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, () =>
        {
            listener.Flush();
            Log.Text = buffer.ToString().Replace(". ", ".\n");
        });
        Closed += (_, _) => source.Listeners.Remove(listener);
    }
}
