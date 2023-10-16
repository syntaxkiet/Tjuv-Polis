using System.Security.Cryptography;

namespace Tjuv___Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int SizeX = 80;
            int SizeY = 80;

            Random rng = new Random();

            string[,] map = new string[SizeX, SizeY];


            Console.ForegroundColor = ConsoleColor.Red;

            for (int x = 0; x < map.GetLength(0); x++)              //Här är en forlopp som visar x - led
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