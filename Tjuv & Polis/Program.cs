using WMPLib;
namespace Tjuv___Polis
{
    internal class Program
    {
        public static int citySizeX = 100;
        public static int citySizeY = 25;
        public static int AltSize = 10;
        public static int robberyCount = 0;
        public static int arrestCount = 0;
        public static int vigilanteSpawnCD = 0;
        public static int vigilanteDespawnCD = 0;
        
        //Create respective lists
        public static List<Person> cityList = new List<Person>();
        public static List<Person> prisonList = new List<Person>();
        public static List<Person> poorHouseList = new List<Person>();
        static void Main(string[] args)
        {
            Random rng = new Random();
            //Create matrix grids for respective maps, to draw out each part
            Map cityMap = new Map(citySizeX, citySizeY, cityList, "Staden");
            Map prisonMap = new Map(AltSize, AltSize, prisonList, "Fängelset");
            Map poorHouseMap = new Map(AltSize, AltSize, poorHouseList, "Fattighuset");

            
            //Add 20 Policemen
            for (int i = 0; i < 20; i++)
            {
                cityList.Add(new Police());
            }

            //Add 20 Thieves
            for (int i = 0; i < 20; i++)
            {
                cityList.Add(new Thief());
            }

            //Add 30 Civilians
            for (int i = 0; i < 30; i++)
            {
                cityList.Add(new Civilian());
            }



              bool Sleep = false;
              bool showMap = true;
              int sleepInterval = 1000;

            //Main loop
            while (true)
            {
                
                //Show map(M) or list(I) on key press, with additional functions to add extra police(P), thief(T), Civilian(C) and to remove the latest added person(R)
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.KeyChar)
                    {
                        case 'm':
                           showMap = true;
                            Console.Clear();
                            break;
                        case 'i':
                            showMap=false;
                            Console.Clear();
                            break;
                        case 'p':
                            cityList.Add(new Police());
                            break;
                        case 't':
                            cityList.Add(new Thief());
                            break;
                        case 'c':
                            cityList.Add(new Civilian());
                            break;
                        case 'v':
                            cityList.Add(new Vigilante(rng.Next(citySizeX), rng.Next(citySizeY), new List<Item>()));
                            break;
                        case 'r':
                            cityList.RemoveAt(cityList.Count - 1);
                            break;
                        case 's':
                            //Remove the sleep thread delay, allowing for faster updates during debug
                            if (Sleep)
                            {
                                sleepInterval = 0;
                                Sleep = false;
                            }
                            else
                            {
                                sleepInterval = 1000;
                                Sleep = true;
                            }
                            break;
                        case 'q':
                            //Empties all civilian items, ONLY USE THIS DURING DEBUGGING
                            for (int i = 0; i < cityList.Count; i++)
                            {
                                if (cityList[i] is Civilian civ)
                                {
                                    civ.Possessions.Clear();
                                }
                            }
                            break;

                    }

                }

                //Show map view
                if (showMap)
                {
                    //Erase previous position of people
                    cityMap.Clear();
                    prisonMap.Clear();
                    poorHouseMap.Clear();

                    //Draw out each map
                    cityMap.Draw();
                    prisonMap.Draw();
                    poorHouseMap.Draw();
                }

                //Show list view
                if (!showMap)
                {
                    Map.ShowInfo();
                }

                //Updates movement of Persons objects & initiate actions if needed
                Map.MovementUpdate();
                Vigilante.UpdateVigilate();

                    //Spawn a vigilante based on the criminal activity of the city. In this case, whenever the criminal activity of the city is a divisible by 5, i.e. 5, 10, 15...
                    if (robberyCount % 5 == 0 && robberyCount != 0 && vigilanteSpawnCD == 0)
                    {
                        Vigilante.SpawnVigilante();
                    }
                    
                    //Despawn the vigilante when the city reaches stable crime levels
                    if (arrestCount % 5 == 0 && arrestCount != 0 && vigilanteDespawnCD == 0)
                    {
                        Vigilante.DespawnVigilante();
                    }
                              
                    Console.WriteLine();        
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Antal rånade medborgare: {robberyCount}");
                    Console.WriteLine($"Antal gripna tjuvar: {arrestCount}");
                    Thread.Sleep(sleepInterval);
                    Console.Clear();
                }

            }
        }
    }
