using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.Services
{
    public class CreateSuperheroViaWindow
    {
        public void Create(Superhero superhero)
        {
            new CreateSuperheroWindow().ShowDialog();
        }
    }
}
