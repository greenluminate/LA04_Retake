using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.ViewModels
{
    public class CreateSuperheroWindowViewModel
    {
        public Superhero Actual { get; set; }

        public CreateSuperheroWindowViewModel()
        {
            Actual = new Superhero()
            {

            };
        }

        public void Setup(Superhero superhero)
        {
            this.Actual = superhero;
        }
    }
}
