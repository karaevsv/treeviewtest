using Avalonia.Controls;
using AvaloniaApplication2.Classes;

namespace AvaloniaApplication2.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Help.MainWnd = this;
    }
}
