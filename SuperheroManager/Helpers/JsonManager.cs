using Newtonsoft.Json;
using SuperheroManager.Models;
using SuperheroManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.Helpers
{
    public class JsonManager : IJsonManager
    {

        public JsonManager()
        {

        }
        public ObservableCollection<Superhero> DeserializeHeroes()
        {
            if (!File.Exists("superheroes.json") || File.ReadAllText("superheroes.json").Length == 0)
            {
                ObservableCollection<Superhero> superheroes = new ObservableCollection<Superhero>()
                {
                    new Superhero() { Name = "Iron Man", Power = 5, Side = SideEnum.good, Speed = 8 },
                    new Superhero() { Name = "Thor", Power = 9, Side = SideEnum.good, Speed = 7 },
                    new Superhero() { Name = "Thanos", Power = 10, Side = SideEnum.evil, Speed = 3 },
                    new Superhero()
                    {
                        Name = "Collector",
                        Power = 2,
                        Side = SideEnum.neutral,
                        Speed = 2}
                };

                return superheroes;
            }
            else
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Superhero>>(File.ReadAllText("superheroes.json"));

                return items;
            }
        }

        public void SuperheroWriter(ObservableCollection<Superhero> superheroes)
        {
            File.WriteAllText("superheroes.json", JsonConvert.SerializeObject(superheroes));
        }
    }
}
