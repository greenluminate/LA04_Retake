using SuperheroManager.Models;
using SuperheroManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace SuperheroManager.ViewModels
{
    public class CreateSuperheroWindowViewModel
    {
        ISuperheroLogic superheroLogic;
        public Superhero NewHero { get; set; }
        public CreateSuperheroWindowViewModel() : this(Ioc.Default.GetService<ISuperheroLogic>())
        {
            this.NewHero = new Superhero();
        }

        public CreateSuperheroWindowViewModel(ISuperheroLogic superheroLogic)
        {
            this.superheroLogic = superheroLogic;
            this.NewHero=new Superhero();
        }

        public void Setup()
        {
            superheroLogic.AddToHQ(this.NewHero);
        }
    }
}
