namespace Tjuv___Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello my friends!");
            Console.WriteLine("Hej på dig");
            int SizeX = 80;
            int SizeY = 80;

            Random rng = new Random();

            string[,] map = new string[SizeX, SizeY];


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