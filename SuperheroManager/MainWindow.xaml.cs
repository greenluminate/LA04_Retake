using Microsoft.Toolkit.Mvvm.DependencyInjection;
using SuperheroManager.Helpers;
using SuperheroManager.Models;
using SuperheroManager.ViewModels;
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

namespace SuperheroManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IJsonManager jsonManager;
        public MainWindow(IJsonManager jsonManager)
        {
            InitializeComponent();
            this.jsonManager = jsonManager;
        }
        public MainWindow() : this(Ioc.Default.GetService<IJsonManager>())
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            jsonManager.SuperheroWriter((this.DataContext as MainWindowViewModel).SuperheroesInHQ);
        }
    }
}
