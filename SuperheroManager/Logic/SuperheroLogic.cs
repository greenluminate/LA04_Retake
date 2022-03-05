using Microsoft.Toolkit.Mvvm.Messaging;
using SuperheroManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.Logic
{
    public partial class SuperheroLogic : ISuperheroLogic
    {
        IList<Superhero> SuperheroesInHQ;
        IList<Superhero> SuperheroesInBattle;
        IMessenger Messenger;

        public SuperheroLogic(IList<Superhero> superheroesInHQ, IList<Superhero> superheroesInBattle, IMessenger messenger)
        {
            SuperheroesInHQ = superheroesInHQ;
            SuperheroesInBattle = superheroesInBattle;
            Messenger = messenger;
        }
        public void AddToBattle(Superhero superhero)
        {
            SuperheroesInBattle.Add(superhero);
            Messenger.Send("SuperheroAdded", "SuperheroInfo");
        }
    }
}
