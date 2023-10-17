namespace Tjuv___Polis
{
    public class Person
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        int direction;
        Random rng;
        public List<Item> inventory = new List<Item>();

        public virtual void Move()
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
        public Police() : base()
        {

        }
    }

    public class Thief : Person
    {
        public Thief() : base()
        {

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
    }

}
