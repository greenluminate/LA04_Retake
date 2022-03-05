using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using SuperheroManager.Helpers;
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

        IJsonManager jsonManager;
        ISuperheroLogic superheroLogic;
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel(ISuperheroLogic logic, IJsonManager jsonManager)
        {
            this.superheroLogic = logic;
            this.jsonManager = jsonManager;
            SuperheroesInHQ = new ObservableCollection<Superhero>();
            SuperheroesInBattle = new ObservableCollection<Superhero>();
            SuperheroesInHQ = this.jsonManager.DeserializeHeroes();

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
               () => logic.EditSuperhero(selectedFromHQ),//TODO
               ()=>SelectedFromHQ != null
               );

            Messenger.Register<MainWindowViewModel, string, string>(this, "SuperheroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
        }
        public double AVGPower
        {
            get
            {
                return superheroLogic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return superheroLogic.AVGSpeed;
            }
        }

        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<ISuperheroLogic>(), IsInDesignMode ? null : Ioc.Default.GetService<IJsonManager>())
        {

        }
    }
}
