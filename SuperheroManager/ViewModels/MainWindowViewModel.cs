using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using SuperheroManager.Logic;
using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SuperheroManager.ViewModels
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Superhero> SuperheroesInHQ { get; set; }
        public ObservableCollection<Superhero> SuperheroesInBattle { get; set; }
        private Superhero selectedFromHQ;

        public Superhero SelectedFromHQ
        {
            get { return selectedFromHQ; }
            set
            {
                SetProperty(ref selectedFromHQ, value);
                (AddToBattle as RelayCommand).NotifyCanExecuteChanged();
                (EditSuperhero as RelayCommand).NotifyCanExecuteChanged();

            }
        }
        private Superhero selectedFromBattle;

        public Superhero SelectedFromBattle
        {
            get { return selectedFromBattle; }
            set
            {
                SetProperty(ref selectedFromBattle, value);
                (RemoveFromBattle as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToBattle { get; set; }
        public ICommand RemoveFromBattle { get; set; }
        public ICommand CreateSuperhero { get; set; }
        public ICommand EditSuperhero { get; set; }


        ISuperheroLogic superheroLogic;
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel(ISuperheroLogic logic)
        {
            this.superheroLogic = logic;
            SuperheroesInHQ = new ObservableCollection<Superhero>();
            SuperheroesInBattle = new ObservableCollection<Superhero>();


            SuperheroesInHQ.Add(new Superhero() { Name = "Iron Man", Power = 5, Side = SideEnum.good, Speed = 8 });
            SuperheroesInHQ.Add(new Superhero() { Name = "Thor", Power = 9, Side = SideEnum.good, Speed = 7 });
            SuperheroesInHQ.Add(new Superhero() { Name = "Thanos", Power = 10, Side = SideEnum.evil, Speed = 3 });
            SuperheroesInHQ.Add(new Superhero() { Name = "Collector", Power = 2, Side = SideEnum.neutral, Speed = 2 });

            SuperheroesInBattle.Add(SuperheroesInHQ[0].GetCopy());
            SuperheroesInBattle.Add(SuperheroesInHQ[2].GetCopy());
            SuperheroesInBattle.Add(SuperheroesInHQ[3].GetCopy());

            logic.SetupCollections(SuperheroesInHQ, SuperheroesInBattle);

            AddToBattle = new RelayCommand(
                () => superheroLogic.AddToBattle(SelectedFromHQ),
                () => SelectedFromHQ != null
                );

            RemoveFromBattle = new RelayCommand(
               () => superheroLogic.RemoveFromBattle(SelectedFromBattle),
               () => SelectedFromBattle != null
               );

            CreateSuperhero = new RelayCommand(
               () => superheroLogic.CreateSuperhero()
               );

            EditSuperhero = new RelayCommand(
               () => { },//TODO
               () => SelectedFromHQ != null
               );
        }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<ISuperheroLogic>())
        {

        }
    }
}
