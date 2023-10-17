using System.Security.Cryptography;

namespace Tjuv___Polis
{
    public class Person
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        int direction;
        Random rng;
        public List<Item> inventory = new List<Item>();

        public void Move()
        {
            rng = new Random();
            direction = rng.Next(0, 8);


            switch (direction)
            {
                case 0:
                    PosY++;
                    break;
                case 1:
                    PosY++;
                    PosX++;
                    break;
                case 2:
                    PosX++;
                    break;
                case 3:
                    PosY--;
                    PosX++;
                    break;
                case 4:
                    PosY--;
                    break;
                case 5:
                    PosY--;
                    PosX--;
                    break;
                case 6:
                    PosX--;
                    break;
                case 7:
                    PosY++;
                    PosX--;
                    break;
            }
            CheckOutOfBounds();
        }

        public void CheckOutOfBounds()
        {
            if (PosX < 0 && PosY < 0)
            {
                PosY = Program.sizeY - 1;
                PosX = Program.sizeX - 1;
            }
            else if (PosX > Program.sizeX - 1 && PosY > Program.sizeY - 1)
            {
                PosY = 0;
                PosX = 0;
            }
            else if(PosX > Program.sizeX - 1 && PosY < 0)
            {
                PosX = 0;
                PosY = Program.sizeY - 1;
            }
            else if(PosX < 0 && PosY > Program.sizeY - 1)
            {
                PosX = Program.sizeX - 1;
                PosY = 0;
            }

            else if (PosX > Program.sizeX - 1)
            {
                PosX = 0;
            }
            else if (PosX < 0)
            {
                PosX = Program.sizeX - 1;
            }
            else if (PosY > Program.sizeY - 1)
            {
                PosY = 0;
            }
            else if (PosY < 0)
            {
                PosY = Program.sizeY - 1;
            }
        }

        public virtual void Action(Person person)
        {
            Console.WriteLine("Person gör någonting");
        }

        public Person()
        {
            rng = new Random();
            PosX = rng.Next(0, Program.sizeX);
            PosY = rng.Next(0, Program.sizeY);
        }
    }

    public class Police : Person
    {
        List<Item> confiscated;
        public Police() : base()
        {
            confiscated = new List<Item>();
        }
        public override void Action(Person person)
        {
            if (person is Thief && (((Thief)person).loot.Count > 0))
            {
              
                Program.arrestCount++;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Polisen slår till mot tjuven och beslagtar hans samtliga byten");
                confiscated = Enumerable.Concat(confiscated, ((Thief)person).loot).ToList();
                (((Thief)person).loot).Clear();
                Thread.Sleep(2000);
                Move();
                person.Move();
                
            }
        }
    }

    public class Thief : Person
    {
        public List<Item> loot { get; set; }
        public Thief() : base()
        {
            loot = new List<Item>();

        }
        public override void Action(Person person) 
        {
            if(person is Civilian)
            {
                Program.robberyCount++;
                Random rng = new Random();
                int index = rng.Next(0, person.inventory.Count);
                loot.Add(person.inventory[index]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tjuv råna medborgare på " + person.inventory[index].Name);
                person.inventory.RemoveAt(index);
                Thread.Sleep(2000);
                Move();
                person.Move();
            }
        }
    }

    public class Civilian : Person
    {
        public Civilian() : base()
        {
            inventory.Add(new Item("Nycklar"));
            inventory.Add(new Item("Mobil"));
            inventory.Add(new Item("Pengar"));
            inventory.Add(new Item("Klocka"));
        }

        public override void Action(Person person)
        {
            if (person is Police || person is Civilian)
            {
                Move();
                person.Move();
            }
            
      
        }
    }

}
