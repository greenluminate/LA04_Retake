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

        public SuperheroLogic(IMessenger messenger)
        {
            Messenger = messenger;
        }
        public void SetupCollections(IList<Superhero> SuperheroesInHQ, IList<Superhero> SuperheroesInBattle)
        {
            this.SuperheroesInHQ = SuperheroesInHQ;
            this.SuperheroesInBattle = SuperheroesInBattle;
        }
        public void AddToBattle(Superhero superhero)
        {
            SuperheroesInBattle.Add(superhero);
            Messenger.Send("SuperheroAdded", "SuperheroInfo");

        }
        public void CreateSuperhero(Superhero superhero)
        {
            SuperheroesInHQ.Add(superhero);
            Messenger.Send("Superhero Created", "SuperheroInfo");
        }
    }
}
