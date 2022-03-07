using Microsoft.Toolkit.Mvvm.DependencyInjection;
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
using System.Windows.Shapes;

namespace SuperheroManager
{
    /// <summary>
    /// Interaction logic for CreateSuperheroWindow.xaml
    /// </summary>
    public partial class CreateSuperheroWindow : Window
    {
        public CreateSuperheroWindow()
        {
            InitializeComponent();
 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in wp_side.Children)
            {
                if ((item as RadioButton).IsChecked.Value)
                {
                    (this.DataContext as CreateSuperheroWindowViewModel).NewHero.Side = (SideEnum)Enum.Parse(typeof(SideEnum), (item as RadioButton).Content.ToString());
                }
            }

            (this.DataContext as CreateSuperheroWindowViewModel).Setup();
            this.DialogResult = true;
        }
    }
}
