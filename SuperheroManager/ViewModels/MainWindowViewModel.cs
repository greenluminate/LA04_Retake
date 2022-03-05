using Microsoft.Toolkit.Mvvm.ComponentModel;
using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.ViewModels
{
    public partial class MainWindowViewModel:ObservableRecipient
    {
        public ObservableCollection<Superhero> SuperheroesInHQ { get; set; }
    }
}
