using SuperheroManager.Models;
using System.Collections.Generic;

namespace SuperheroManager.Logic
{
    public interface ISuperheroLogic
    {
        void AddToBattle(Superhero superhero);
        void SetupCollections(IList<Superhero> SuperheroesInHQ, IList<Superhero> SuperheroesInBattle);
        void CreateSuperhero();
        void AddToHQ(Superhero superhero);
        void RemoveFromBattle(Superhero superhero);

        double AVGPower { get; }
        double AVGSpeed { get; }
    }
}