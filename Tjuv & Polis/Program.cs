namespace Tjuv___Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeX = 80;
            int sizeY = 80;

            List<People> peopleList = new List<People>();
            People[,] map = new People[sizeX, sizeY];

            Random rng = new Random();

            for (int i = 0; i < 10; i++)
            {
                peopleList.Add(new People(rng.Next(80), rng.Next(80)));
            }



            Console.BackgroundColor = ConsoleColor.Blue;

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    if (y is People)
                    {
                        Console.WriteLine("P");
                    }

                    else
                    {
                        Console.Write("[]");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}