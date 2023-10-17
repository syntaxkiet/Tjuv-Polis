namespace Tjuv___Polis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello my friends!");
            Console.WriteLine("Hej på dig");
            int sizeX = 80;
            int sizeY = 80;

            Random rnd = new Random();

            string[,] map = new string[sizeX, sizeY];


            Console.ForegroundColor = ConsoleColor.Red;

            for (int x = 0; x < map.GetLength(0); x++)              //Här är en for-lopp som visar x - led
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    //map[x, y] = "[]";

                    Console.Write("[]");
                }

                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}