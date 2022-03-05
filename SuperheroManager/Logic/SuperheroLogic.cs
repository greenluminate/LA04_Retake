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
        IEditSuperheroViaWindow editSuperhero;

        public SuperheroLogic(IMessenger messenger, IEditSuperheroViaWindow editSuperhero)
        {
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
        public void CreateSuperhero(Superhero superhero)
        {
            SuperheroesInHQ.Add(superhero);
            Messenger.Send("Superhero Created", "SuperheroInfo");
        }
        public void EditSuperhero(Superhero superhero)
        {
            editSuperhero.Edit(superhero);
            Messenger.Send("SuperheroEdited", "SuperheroInfo");

        }
    }
}
