using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Creature_Classes
{
    public class Pig
    {
        // Fields
        private string name;
        private float speed;
        private int damage;
        private int health;
        private bool dropsChest;

        // Constructor
        public Pig(string name, float speed, int damage, int health, bool dropsChest)
        {
            this.name = name;
            this.speed = speed;
            this.damage = damage;
            this.health = health;
            this.dropsChest = dropsChest;
        }

        // Properties

        //Get returns the value assigned when constructing the pig outside of the class,
        //Set assigns the returned value to the pig
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public bool DropsChest
        {
            get { return dropsChest; }
            set { dropsChest = value; }
        }

        // Methods
    }

}
