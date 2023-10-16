using System.Security.Cryptography;

namespace Tjuv___Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, int> mapSize = new Tuple<int, int>(80,80);

            Random rng = new Random();

            string[,] map = new string[mapSize.Item2, mapSize.Item1];

            List<Tuple<int, int>> actorList = new List<Tuple<int, int>>();

            for (int i = 0; i < 20; i++)
            {
                actorList.Add(new Tuple<int, int>(rng.Next(0,25), rng.Next(0,100)));
            }

            Console.ForegroundColor = ConsoleColor.Red;

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    //map[x, y] = "[]";

                    Console.Write("[]");
                }

                Console.WriteLine();
            }
            
        }
    }
}