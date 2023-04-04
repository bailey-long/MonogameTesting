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
        private int age;
        private string name;
        private int weight;
        private bool isPregnant;
        private int gestationPeriod;
        private int litterSize;

        // Constructor
        public Pig(int age, string name, int weight, bool isPregnant, int gestationPeriod, int litterSize)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
            this.isPregnant = isPregnant;
            this.gestationPeriod = gestationPeriod;
            this.litterSize = litterSize;
        }

        // Properties
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public bool IsPregnant
        {
            get { return isPregnant; }
            set { isPregnant = value; }
        }

        public int GestationPeriod
        {
            get { return gestationPeriod; }
            set { gestationPeriod = value; }
        }

        public int LitterSize
        {
            get { return litterSize; }
            set { litterSize = value; }
        }

        // Methods
        public void Squeal()
        {
            Debug.WriteLine("The pig lets out a loud squeal!");
        }

        public void Root()
        {
            Debug.WriteLine("The pig roots around in the dirt looking for food.");
        }

        public void GiveBirth()
        {
            if (isPregnant)
            {
                Debug.WriteLine("The pig gives birth to a litter of " + litterSize + " piglets!");
                isPregnant = false;
            }
            else
            {
                Debug.WriteLine("The pig is not pregnant.");
            }
        }
    }

}
