using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroAcademy
{
    
    class Program
    {

        public abstract class Superhero
        {
            string name;
            public int health;
            public int power;
            int speed;
            public enum Element { Fire, Water, Wind, Empty }
            Element element;


            public void SetStats(string _name, int _health, int _power, int _speed, Element _element)
            {
                name = _name;
                health = _health;
                power = _power;
                speed = _speed;
                element = _element;
            }

            public void PrintStats()
            {
                Console.WriteLine("Stats for " + name + ":" + "\nHealth: " + health + "\nPower: " + power + "\nSpeed: " + speed);
            }

            public void TakeDamage(int _dmg, Element _element)
            {
                if (element == Element.Water && _element == Element.Fire) //Water types are resistant to fire
                {
                    _dmg = (int)(_dmg * 0.5f);
                }
                health -= health; //damages hero
            }
        }

        public class FireBro : Superhero
        {
            int fireCharge = 50;

            public FireBro(string _name)
            {
                SetStats(_name, 130, 60, 40, Superhero.Element.Fire);
            }

            void FlameThrower()
            {
                //cast fire forward as long as fireCharge lasts, dealing power dmg per second and afflicting enemies with burn. Has a cooldown.
            }
        }

        public class WaterDude : Superhero
        {
            public WaterDude(string _name)
            {
                SetStats(_name, 130, 20, 40, Superhero.Element.Water);
            }

            void SquirtGun()
            {
                //Shoot enemies far away every 0.5 seconds dealing power dmg per shot, no cooldown.
            }
        }

        public class WindBoi : Superhero
        {
            int stamina = 50;

            public WindBoi(string _name)
            {
                SetStats(_name, 100, 30, 60, Superhero.Element.Wind);
            }

            void Fly()
            {
                //Fly for as long as stamina lasts, knocks down enemies within range when landing
            }
        }
        static void Main(string[] args)
        {
            bool success = false;
            while (!success) {
                Console.Clear();
                Console.WriteLine("What type of hero would you like to create?\n1. Fire \n2. Water \n3. Wind");
                string ans = Convert.ToString(Console.ReadLine()).ToLower();
                Superhero.Element element = Superhero.Element.Empty;
                success = true;
                switch (ans) //Assign hero type first
                {
                    case "1": case "fire": element = Superhero.Element.Fire; break;
                    case "2": case "water": element = Superhero.Element.Water; break;
                    case "3": case "wind": element = Superhero.Element.Wind; break;
                    default: Console.WriteLine("Not a valid answer, please try again."); success = false; Console.ReadKey(true); break;
                }

                Console.WriteLine("Please choose a name for your hero.");
                string name = Convert.ToString(Console.ReadLine());
                Superhero hero = null;
                switch (element) //Create new hero by type and name
                {
                    case Superhero.Element.Fire: hero = new FireBro(name); break;
                    case Superhero.Element.Water: hero = new WaterDude(name); break;
                    case Superhero.Element.Wind: hero = new WindBoi(name); break;
                    default: Console.WriteLine("Well you somehow managed to mess it up, congrats"); break;
                }

                hero.PrintStats();
                Console.ReadLine();
            }
        }
    }
}
