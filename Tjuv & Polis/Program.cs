namespace Tjuv___Polis
{
    internal class Program
    {
        public static int sizeX = 100;
        public static int sizeY = 25;

        static void Main(string[] args)
        {

            List<People> peopleList = new List<People>();
            People[,] map = new People[sizeX, sizeY];

            Random rng = new Random();

            //Police
            for (int i = 0; i < 10; i++)
            {
                peopleList.Add(new Police());
            }

            //Thieves
            for (int i = 0; i < 20; i++)
            {
                peopleList.Add(new Thief());
            }

            //Civlians
            for (int i = 0; i < 30; i++)
            {
                peopleList.Add(new Civilian());
            }

            foreach (People people in peopleList)
            {
                map[people.PosX, people.PosY] = people;
            }


            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] is Police)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("P");
                    }
                    if (map[x, y] is Thief)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("T");
                    }
                    if (map[x, y] is Civilian)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("C");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}