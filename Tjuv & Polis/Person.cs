namespace Tjuv___Polis
{
    public class Person
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        int direction;
        Random rng;

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
                PosY = Program.citySizeY - 1;
                PosX = Program.citySizeX - 1;
            }
            else if (PosX > Program.citySizeX - 1 && PosY > Program.citySizeY - 1)
            {
                PosY = 0;
                PosX = 0;
            }
            else if (PosX > Program.citySizeX - 1 && PosY < 0)
            {
                PosX = 0;
                PosY = Program.citySizeY - 1;
            }
            else if (PosX < 0 && PosY > Program.citySizeY - 1)
            {
                PosX = Program.citySizeX - 1;
                PosY = 0;
            }

            else if (PosX > Program.citySizeX - 1)
            {
                PosX = 0;
            }
            else if (PosX < 0)
            {
                PosX = Program.citySizeX - 1;
            }
            else if (PosY > Program.citySizeY - 1)
            {
                PosY = 0;
            }
            else if (PosY < 0)
            {
                PosY = Program.citySizeY - 1;
            }
        }

        public virtual void Action(Person person)
        {
            Console.WriteLine("Person gör någonting");
        }

        public Person()
        {
            rng = new Random();
            PosX = rng.Next(0, Program.citySizeX);
            PosY = rng.Next(0, Program.citySizeY);
        }
    }

    public class Police : Person
    {
        public List<Item> Confiscated { get; set; }
        public Police() : base()
        {
            Confiscated = new List<Item>();
        }
        public override void Action(Person person)
        {
            if (person is Thief && (((Thief)person).Loot.Count > 0))
            {

                Program.arrestCount++;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Polisen slår till mot tjuven och beslagtar hans samtliga byten");
                Confiscated = Enumerable.Concat(Confiscated, ((Thief)person).Loot).ToList();
                (((Thief)person).Loot).Clear();
                Thread.Sleep(2000);
                Move();
                person.Move();

            }
        }
    }

    public class Thief : Person
    {
        public List<Item> Loot { get; set; }
        public Thief() : base()
        {
            Loot = new List<Item>();

        }
        public override void Action(Person person)
        {
            if (person is Civilian)
            {
                Program.robberyCount++;
                Random rng = new Random();
                int index = rng.Next(0, ((Civilian)person).Possessions.Count);
                Loot.Add((((Civilian)person).Possessions[index]));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tjuv råna medborgare på " + (((Civilian)person).Possessions[index].Name));
                ((Civilian)person).Possessions.RemoveAt(index);
                Thread.Sleep(2000);
                Move();
                person.Move();
            }
        }
    }

    public class Civilian : Person
    {
        public List<Item> Possessions { get; set; }
        public Civilian() : base()
        {
            Possessions = new List<Item>();
            Possessions.Add(new Item("Nycklar"));
            Possessions.Add(new Item("Mobil"));
            Possessions.Add(new Item("Pengar"));
            Possessions.Add(new Item("Klocka"));
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
