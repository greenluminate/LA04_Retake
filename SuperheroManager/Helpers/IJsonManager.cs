using SuperheroManager.Models;
using System.Collections.ObjectModel;

namespace SuperheroManager.Helpers
{
    public interface IJsonManager
    {
        ObservableCollection<Superhero> DeserializeHeroes();
        void SuperheroWriter(ObservableCollection<Superhero> superheroes);
    }
}