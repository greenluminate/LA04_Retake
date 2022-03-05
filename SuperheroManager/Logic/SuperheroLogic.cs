using Microsoft.Toolkit.Mvvm.Messaging;
using SuperheroManager.Models;
using SuperheroManager.Services;
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
        ICreateSuperheroViaWindow createWindow;

        public SuperheroLogic(IMessenger messenger, ICreateSuperheroViaWindow createWindow)
        {
            this.createWindow = createWindow;
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
        public void CreateSuperhero()
        {
            createWindow.Create();
            Messenger.Send("Superhero Created", "SuperheroInfo");
        }

        public void AddToHQ(Superhero superhero)
        {
            SuperheroesInHQ.Add(superhero);
        }

        public void RemoveFromBattle(Superhero superhero)
        {
            SuperheroesInBattle.Remove(superhero);
            Messenger.Send("Superhero Removed From Battle", "SuperheroInfo");
        }
    }
}
