using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BreadcrumbControl;

namespace Example
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BreadcrumbItem> Items { get; } = new ObservableCollection<BreadcrumbItem>(); 


        public MainWindow()
        {
            InitializeComponent();
            Items.Add(new BreadcrumbItem() {Header = "1"});
            Items.Add(new BreadcrumbItem() { Header = "2" });
        }

        private void OnContentChanged(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
