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
            this.DataContext = new CreateSuperheroWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Superhero newSuperhero = new Superhero();
            newSuperhero.Name = tb_name.Text;
            newSuperhero.Power = int.Parse(tb_power.Text);
            newSuperhero.Speed = int.Parse(tb_speed.Text);

            foreach (var item in stack_creator.Children)
            {
                if (item is RadioButton t && t.IsChecked.Value)
                {
                    newSuperhero.Side = (SideEnum)Enum.Parse(typeof(SideEnum), t.Content.ToString());
                }
            }

            (this.DataContext as CreateSuperheroWindowViewModel).Setup(newSuperhero);
            this.DialogResult = true;
        }
    }
}
