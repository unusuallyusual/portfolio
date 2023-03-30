using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP2
{

  /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
  public partial class MainWindow : Window
  {
    private WorkWindow workWindow;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void BtnClickConsultant(object sender, RoutedEventArgs e)
    {
      workWindow = new WorkWindow(new Consultant());
      workWindow.Title = "Режим КОНСУЛЬТАНТ";
      workWindow.ShowDialog();
    }
    private void BtnClickManager(object sender, RoutedEventArgs e)
    {
      workWindow = new WorkWindow(new Manager());
      workWindow.Title = "Режим МЕНЕДЖЕР";
      workWindow.ShowDialog();
    }
  }
}
