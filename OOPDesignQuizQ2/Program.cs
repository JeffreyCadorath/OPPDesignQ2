using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesignQuizQ2
{
    class Program
    {
        public class Hero
        {
            public string Name { get; set; }
            public Sword Weapon { get; set; }
        }

        public class Sword : Weapon
        {
            Enemy enemy;
            public Sword()
            {
                this.Name = "Shadown Mourne";
            }

            public override void upgradeWeapon()
            {

            }
        }

        public abstract class Weapon
        {
            public string Name { get; set; }
            public abstract void upgradeWeapon(Weapon weapon);
        }

        public abstract class WeaponDecorator : Weapon
        {
            public abstract override void upgradeWeapon(Weapon weapon);
        }
        public class BigBadSlayer : WeaponDecorator
        {
            Enemy enemy;
            public override void upgradeWeapon(Weapon weapon)
            {
                var input = Console.ReadLine();
                if (enemy.Type == "Big Baddy")
                {
                    Console.WriteLine("The Big Baddy has been slain!");
                    if (input == "1")
                    {
                        Console.WriteLine("You have Vanquished the Enemy Close Application and start again to challenge another");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.ReadLine();
                    }
                }
            }
        }

        public class GiantSlayer : WeaponDecorator
        {
            Enemy enemy;

            public override void upgradeWeapon(Weapon weapon)
            {
                var input = Console.ReadLine();
                if (enemy.Type == "Giant")
                {
                    Console.WriteLine("The Giant Has Been Slain!");
                    if (input == "1")
                    {
                        Console.WriteLine("You have defeated the Enemy Close Application and Go again!");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
        }
        public abstract class Enemy
        {
            public string Type { get; set; }
            public string Name { get; set; }
        }

        public class BigBaddy : Enemy
        {
            public string Name = "Big Bald Baddy";
            public BigBaddy()
            {
                this.Type = "Big Baddy";
            }
        }
        public class Giant : Enemy
        {
            public string Name = "Gorthok the Slayer";
            public Giant()
            {
                this.Type = "Giant";
            }
        }

        public class Fight
        {
            public List<Enemy> Monsters { get; set; }
            public Hero hero { get; set; }
            public Enemy monster { get; set; }
            public Weapon weapon { get; set; }
            public Fight(Hero hero)
            {
                this.Monsters = new List<Enemy>();
                this.hero = hero;
                Enemy giant = new Giant();
                Enemy bigbaddy = new BigBaddy();
                Monsters.Add(giant);
                Monsters.Add(bigbaddy);
            }
            public void StartFight()
            {
                Console.Clear();
                Console.WriteLine("Please Choose an option for who you'd like to fight");
                Console.WriteLine("1. Fight the Easiest Monster");
                Console.WriteLine("2. Fight the Hardest Monster");

                var input = Console.ReadLine();
                if (input == "1")
                {
                    monster = Monsters[0];
                    Console.WriteLine("You've encountered a {0},  its going to be a doozey", monster.Name);
                    Console.WriteLine("Hope you're prepared for this fight!");
                    if(monster.Type == "Giant")
                    {
                        weapon.upgradeWeapon(hero.Weapon);
                    }
                    Console.WriteLine(" ");
                }
                else if (input == "2")
                {
                    monster = Monsters[1];
                    Console.WriteLine("You've encountered a wild {0}, watch out for his wild whacky arms", monster.Name);
                    Console.WriteLine("Hope you're prepared for this!");
                    if(monster.Type == "Big Baddy")
                    {
                        weapon.upgradeWeapon(hero.Weapon);
                    }
                    Console.WriteLine(" ");
                }
            }
        }


        static void Main(string[] args)
        {
            Hero StanDarsh = new Hero();
            StanDarsh.Name = "Stan Darsh";
            Fight fight = new Fight(StanDarsh);
            fight.StartFight();

        }
    }
}
