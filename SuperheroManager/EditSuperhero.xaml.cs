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
    /// Interaction logic for EditSuperhero.xaml
    /// </summary>
    public partial class EditSuperhero : Window
    {
        public EditSuperhero(Superhero superhero)
        {
            InitializeComponent();
            this.DataContext = new EditSuperheroWindowViewModel();
            (this.DataContext as EditSuperheroWindowViewModel).Setup(superhero);
            foreach (var item in wp_radios.Children)
            {
                if ((item as RadioButton).Content.ToString() == (this.DataContext as EditSuperheroWindowViewModel).Actual.Side.ToString())
                {
                    (item as RadioButton).IsChecked = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack_editor.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                }
            }
            var enumstring = "";
            foreach (var item in wp_radios.Children)
            {
                if ((item as RadioButton).IsChecked==true)
                {
                    enumstring = (string)(item as RadioButton).Content.ToString();
                }
            }

            (this.DataContext as EditSuperheroWindowViewModel).Actual.Side = (SideEnum)Enum.Parse(typeof(SideEnum), enumstring);
                this.DialogResult = true;

            }
        }
    }
