using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TabsWpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenTabbedView_Click(object sender, RoutedEventArgs e)
    {
        // Assuming your new window is named TabbedWindow
        TabbedWindow tabWindow = new TabbedWindow();
        tabWindow.Show();
        // tabWindow.ShowDialog(); // Use ShowDialog() if you want to block the main window
    }
}