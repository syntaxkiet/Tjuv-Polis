namespace Tjuv___Polis
{
    public class People
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        int direction;
        Random rng;
        public List<Items> inventory = new List<Items>();

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

        public People()
        {
            rng = new Random();
            PosX = rng.Next(0, Program.sizeX);
            PosY = rng.Next(0, Program.sizeY);
        }
    }

    public class Police : People
    {
        public Police() : base()
        {

        }
    }

    public class Thief : People
    {
        public Thief() : base()
        {

        }
    }

    public class Civilian : People
    {
        public Civilian() : base()
        {
            inventory.Add(new Items("Nycklar"));
            inventory.Add(new Items("Mobil"));
            inventory.Add(new Items("Pengar"));
            inventory.Add(new Items("Klocka"));
        }
    }

}
