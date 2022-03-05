using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.ViewModels
{
    public partial class EditSuperheroWindowViewModel
    {
        public Superhero Actual { get; set; }
        public EditSuperheroWindowViewModel()
        {
           
        }
        public void Setup(Superhero superhero)
        {
            this.Actual = superhero;
        }
    }
}
