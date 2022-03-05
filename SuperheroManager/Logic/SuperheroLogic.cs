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
        IEditSuperheroViaWindow editSuperhero;

        public SuperheroLogic(IMessenger messenger, IEditSuperheroViaWindow editSuperhero, ICreateSuperheroViaWindow createWindow)
        {
            this.createWindow = createWindow;
            Messenger = messenger;
            this.editSuperhero = editSuperhero;
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

        public double AVGPower
        {
            get
            {
                return Math.Round(SuperheroesInBattle.Count == 0 ? 0 : SuperheroesInBattle.Average(t => t.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(SuperheroesInBattle.Count == 0 ? 0 : SuperheroesInBattle.Average(t => t.Speed), 2);
            }
        }
        public void EditSuperhero(Superhero superhero)
        {
            editSuperhero.Edit(superhero);
            Messenger.Send("SuperheroEdited", "SuperheroInfo");

        }
    }
}
