using Avalonia.Controls;
using AvaloniaApplication2.Classes;
using AvaloniaApplication2.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AvaloniaApplication2.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        loadData();
    }

    private void loadData()
    {
        Help.Db.Subdivisions.Load();
        OrganizationTw.ItemsSource = Help.Db.Subdivisions.Where(el => el.SubdivisionId == null).ToList();
    }

    private void TreeView_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        var selected = OrganizationTw.SelectedItem as Subdivision;
        if (selected == null)
        {
            return;
        }
        Help.Db.Employees.Load();
        EmployeeDg.ItemsSource = Help.Db.Employees.Where(el => el.SubdivisionId == selected.Id).ToList();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddWnd wnd = new AddWnd();
        wnd.ShowDialog(Help.MainWnd);
    }

    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
}
