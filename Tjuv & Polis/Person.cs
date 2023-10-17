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
