namespace Tjuv___Polis
{
    internal class Program
    {
        public static int citySizeX = 100;
        public static int citySizeY = 25;
        public static int prisonSize = 10;
        public static int robberyCount = 0;
        public static int arrestCount = 0;

        //Create list of prisoners
        public static List<Person> prisonList = new List<Person>();

        //Create list of people
        public static List<Person> personList = new List<Person>();
        static void Main(string[] args)
        {
            //Create city map (matrix)
            Person[,] cityMap = new Person[citySizeX, citySizeY];
            //Create prison map (matrix)
            Person[,] prisonMap = new Person[prisonSize, prisonSize];

            //Add 10 Policemen
            for (int i = 0; i < 20; i++)
            {
                personList.Add(new Police());
            }

            //Add 20 Thieves
            for (int i = 0; i < 20; i++)
            {
                personList.Add(new Thief());
            }

            //Add 30 Civilians
            for (int i = 0; i < 30; i++)
            {
                personList.Add(new Civilian());
            }
            bool showMap = true;

            //Main loop
            while (true)
            {
                //Erase previous position of people
                Array.Clear(cityMap);
                Array.Clear(prisonMap);

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

                //Add each person's position into the city map
                foreach (Person people in personList)
                {
                    cityMap[people.PosX, people.PosY] = people;
                }

                if (showMap)
                {
                    //Print map of city and people
                    Console.WriteLine("City");
                    for (int i = 0; i <= citySizeX; i++)
                    {
                        Console.Write("_");
                    }
                    Console.WriteLine();

                    for (int y = 0; y < cityMap.GetLength(1); y++)
                    {
                        for (int x = 0; x < cityMap.GetLength(0); x++)
                        {
                            if (cityMap[x, y] is Police)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("P");
                            }
                            if (cityMap[x, y] is Thief)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("T");
                            }
                            if (cityMap[x, y] is Civilian)
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

                    for (int i = 0; i <= citySizeX; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("_");
                    }
                    Console.WriteLine();

                    Console.WriteLine();

                    //Add each person's position into the prison map
                    foreach (Person people in prisonList)
                    {
                        prisonMap[people.PosX, people.PosY] = people;
                    }

                    //Print prison
                    Console.WriteLine("Prison");
                    for (int i = 0; i <= prisonSize; i++)
                    {
                        Console.Write("_");
                    }
                    Console.WriteLine();

                    for (int y = 0; y < prisonMap.GetLength(1); y++)
                    {
                        for (int x = 0; x < prisonMap.GetLength(0); x++)
                        {
                            if (prisonMap[x, y] is Thief)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("T");
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    for (int i = 0; i <= prisonSize; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("_");
                    }
                    Console.WriteLine();
                }

                //Move people around the prison
                for (int i = 0; i < prisonList.Count; i++)
                {
                    prisonList[i].Move();
                }

                //Move people around the prison
                for (int i = 0; i < personList.Count; i++)
                {
                    personList[i].Move();
                }

                //Move people around the city
                foreach (Person person in personList)
                {
                    person.Move();
                }

                if (!showMap)
                {
                    for (int i = 0; i < personList.Count; i++)
                    {
                        Console.Write("Person " + (i + 1) + " ");
                        personList[i].GetInfo();
                    }
                }

                Console.WriteLine();

                //Compares people's coordinates to initiate action if needed
                for (int i = 0; i < personList.Count; i++)
                {
                    for (int y = 0; y < personList.Count; y++)
                    {
                        if (personList[i].PosY == personList[y].PosY && personList[i].PosX == personList[y].PosX && personList[i] != personList[y])
                        {
                            personList[i].Action(personList[y]);
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