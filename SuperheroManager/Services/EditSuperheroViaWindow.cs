using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.Services
{
    public partial class EditSuperheroViaWindow : IEditSuperheroViaWindow
    {
        public void Edit(Superhero superhero)
        {
            var se = new EditSuperhero(superhero).ShowDialog();
        }
    }
}
