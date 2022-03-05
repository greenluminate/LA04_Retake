using SuperheroManager.Models;
using System.Collections.Generic;

namespace SuperheroManager.Logic
{
    public interface ISuperheroLogic
    {
        void AddToBattle(Superhero superhero);
        void SetupCollections(IList<Superhero> SuperheroesInHQ, IList<Superhero> SuperheroesInBattle);
        void EditSuperhero(Superhero superhero);
    }
}