using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroManager.Models
{
    public partial class Superhero : ObservableObject
    {
        private SideEnum side;

        public SideEnum Side
        {
            get { return side; }
            set { SetProperty(ref side, value); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public Superhero GetCopy()
        {
            return new Superhero()
            {
                Side = this.Side,
                Speed = this.Speed,
                Power = this.Power,
                Name = this.name
            };
        }
    }
}
