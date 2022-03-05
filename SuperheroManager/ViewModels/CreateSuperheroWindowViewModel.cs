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
        public CreateSuperheroWindowViewModel() : this(Ioc.Default.GetService<ISuperheroLogic>())
        {

        }

        public CreateSuperheroWindowViewModel(ISuperheroLogic superheroLogic)
        {
            this.superheroLogic = superheroLogic;
        }

        public void Setup(Superhero superhero)
        {
            superheroLogic.AddToHQ(superhero);
        }
    }
}
