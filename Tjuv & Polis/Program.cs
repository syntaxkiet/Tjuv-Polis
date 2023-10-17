namespace Tjuv___Polis
{
    internal class Program
    {
        public static int sizeX = 100;
        public static int sizeY = 25;
        public static int robberyCount = 0;
        public static int arrestCount = 0;

        static void Main(string[] args)
        {

            List<Person> peopleList = new List<Person>();
            Person[,] map = new Person[sizeX, sizeY];

            Random rng = new Random();

            //Add 20 Policemen
            for (int i = 0; i < 10; i++)
            {
                peopleList.Add(new Police());
            }

            //Add 20 Thieves
            for (int i = 0; i < 20; i++)
            {
                peopleList.Add(new Thief());
            }

            //Add 30 Civilians
            for (int i = 0; i < 30; i++)
            {
                peopleList.Add(new Civilian());
            }



            while (true)
            {
                Array.Clear(map);
                foreach (Person people in peopleList)
                {
                    map[people.PosX, people.PosY] = people;
                }
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
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
                            Console.Write("M");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                foreach (Person person in peopleList)
                {
                    person.Move();
                }


                Console.WriteLine();
                for (int i = 0; i < peopleList.Count; i++)
                {
                    for (int y = 0; y < peopleList.Count; y++)
                    {
                        if (peopleList[i].PosY == peopleList[y].PosY && peopleList[i].PosX == peopleList[y].PosX && peopleList[i] != peopleList[y])
                        {
                            peopleList[i].Action(peopleList[y]);
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Antal rånade medborgare: {robberyCount}");
                Console.WriteLine($"Antal gripna tjuvar: {arrestCount}");
                Thread.Sleep(1000);
                Console.Clear();
               
            }
           
        }
        

    }
}