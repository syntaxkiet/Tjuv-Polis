namespace Tjuv___Polis
{
    internal class Program
    {
        public static int citySizeX = 100;
        public static int citySizeY = 25;
        public static int prisonSize = 10;
        public static int robberyCount = 0;
        public static int arrestCount = 0;

        static void Main(string[] args)
        {
            //Create list of prisoners
            List<Person> prisonList = new List<Person>();

            //Create list of people
            List<Person> peopleList = new List<Person>();

            //Create city map (matrix)
            Person[,] map = new Person[citySizeX, citySizeY];

            //Add 10 Policemen
            for (int i = 0; i < 5; i++)
            {
                peopleList.Add(new Police());
            }

            //Add 20 Thieves
            for (int i = 0; i < 10; i++)
            {
                peopleList.Add(new Thief());
            }

            //Add 30 Civilians
            for (int i = 0; i < 10; i++)
            {
                peopleList.Add(new Civilian());
            }
            bool showMap = true;

            

            //Main loop
            while (true)
            {   //Erase previous position of people
                Array.Clear(map);
               

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == 'm')
                        showMap = true;
                    Console.Clear();
                  
                    if (key.KeyChar == 'i')
                        showMap = false;
                     Console.Clear();

                }
                



                //Add each person's position into the map
                foreach (Person people in peopleList)
                {
                    map[people.PosX, people.PosY] = people;
                }


                if (showMap)
                {

                //Print map of city and people
                Console.WriteLine("City");
                for (int i = 0; i < citySizeX; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();

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
                for (int i = 0; i < citySizeX; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-");
                }
                Console.WriteLine();
                //Print prison
                Console.WriteLine();

                Console.WriteLine("Prison");
                for (int i = 0; i < prisonSize; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-");
                }
               
                for (int i = 0; i < prisonSize; i++)
                {
                    for (int j = 0; j < prisonSize; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                for (int i = 0; i < prisonSize; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("-");
                }

                }

                

                //Move people around
                foreach (Person person in peopleList)
                {
                    person.Move();
                }


                if (!showMap)
                {
                    foreach (Person person in peopleList)
                    {
                        person.GetInfo(person);
                    }
                }

                    Console.WriteLine();

                //Compares people's coordinates to initiate action if needed
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