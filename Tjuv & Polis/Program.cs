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

        //Create respective lists
        public static List<Person> cityList = new List<Person>();
        public static List<Person> prisonList = new List<Person>();
        public static List<Person> poorHouseList = new List<Person>();
        static void Main(string[] args)
        {
            Random rng = new Random();
            //Create creative matrix grids for respective maps
            Map cityMap = new Map(citySizeX, citySizeY, cityList, "Staden");
            Map prisonMap = new Map(AltSize, AltSize, prisonList, "Fängelset");
            Map poorHouseMap = new Map(AltSize, AltSize, poorHouseList, "Fattighuset");

            //Create an instance of MediaPlayer for surprise!
            WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            int vigilanteSpawnCD = 0;
            int vigilanteDespawnCD = 0;

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
            bool showMap = true;

            //Main loop
            while (true)
            {
                
                //Show map or list on key press
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

                    //Updates movement
                    for (int i = 0; i < prisonList.Count; i++)
                    {
                        prisonList[i].Move();
                    }

                    for (int i = 0; i < cityList.Count; i++)
                    {
                        cityList[i].Move();
                    }

                    for (int i = 0; i < poorHouseList.Count; i++)
                    {
                        poorHouseList[i].Move();
                    }


                    //Spawn a vigilante based on the criminal activity of the city. In this case, whenever the criminal activity of the city is a divisible by 5, i.e. 5, 10, 15...
                    #region "Vigilante code"
                    if (robberyCount % 5 == 0 && robberyCount != 0 && vigilanteSpawnCD == 0)
                    {
                        //Randomize an index from a temporary list of Civilian objects
                        List<int> vigilanteList = new List<int>();
                        for (int i = 0; i < cityList.Count; i++)
                        {
                            if (cityList[i] is Civilian)
                            {
                                vigilanteList.Add(i);
                            }
                        }

                        //From the randomized index value of Civilian objects, spawn a Vigilante that inherits their position and held items. 
                        int vigilantePick = vigilanteList[rng.Next(vigilanteList.Count)];
                        cityList[vigilantePick] = new Vigilante(cityList[vigilantePick].PosX, cityList[vigilantePick].PosY, ((Civilian)cityList[vigilantePick]).Possessions);
                        int heroPick = rng.Next(4);

                        switch (heroPick)
                        {
                            case 0:
                                Console.WriteLine("Kriminaliteten är så hög att medborgaren Bruce Wayne tar på sig Batman-dräkten och säger: \"I'm BATMAN!\". Tjuvar, se upp!");
                                player.URL = "BatmanThemeSong.mp3";
                                player.settings.volume = 25;
                                player.settings.setMode("loop", true);
                                player.controls.play();
                                break;
                            case 1:
                                Console.WriteLine("Luke Skywalker landar med sin X-Wing och leder motståndsrörelsen mot den mörka sidan!");
                                player.URL = "TheForceThemeSong.mp3";
                                player.settings.volume = 50;
                                player.settings.setMode("loop", true);
                                player.controls.play();
                                break;
                            case 2:
                                Console.WriteLine("Spider Man svingar runt och vakar över stadens invånare!");
                                player.URL = "SpiderManThemeSong.mp3";
                                player.settings.volume = 25;
                                player.settings.setMode("loop", true);
                                player.controls.play();
                                break;
                            case 3:
                                Console.WriteLine("Iron Man tar på sig sin power suit och undsätter polisstyrkan i deras kamp mot den ökande kriminaliteten!");
                                player.URL = "IronManThemeSong.mp3";
                                player.settings.volume = 25;
                                player.settings.setMode("loop", true);
                                player.controls.play();
                                break;
                            default:
                                Console.WriteLine("En ny superhjälte har tagit på sig sin mantel!");
                                break;
                        }
                        vigilanteSpawnCD = 5;
                        Thread.Sleep(4000);

                        robberyCount++;
                    }
                    

                    if (arrestCount % 5 == 0 && arrestCount != 0 && vigilanteDespawnCD == 0)
                    {
                        for (int i = 0; i < cityList.Count; i++)
                        {
                            if (cityList[i] is Vigilante)
                            {
                                cityList[i] = new Civilian();
                                Console.WriteLine("With their work being done, the vigilante hero disappears into the night, for now...");
                                vigilanteDespawnCD = 10;
                                Thread.Sleep(2000);
                                break;
                            }

                        }
                        player.controls.stop();
                    }
                    #endregion

                    
                    Console.WriteLine();

                    //Compares people's coordinates to initiate action if needed
                    for (int i = 0; i < cityList.Count; i++)
                    {
                        for (int y = 0; y < cityList.Count; y++)
                        {
                            if (cityList[i].PosY == cityList[y].PosY && cityList[i].PosX == cityList[y].PosX && cityList[i] != cityList[y])
                            {
                                cityList[i].Action(cityList[y]);
                            }
                        }
                    }

                    if (vigilanteSpawnCD > 0)
                    {
                        vigilanteSpawnCD--;
                    }

                    if (vigilanteDespawnCD > 0)
                    {
                        vigilanteDespawnCD--;

                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Antal rånade medborgare: {robberyCount}");
                    Console.WriteLine($"Antal gripna tjuvar: {arrestCount}");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                //Show list view
                if (!showMap)
                {
                    Console.WriteLine("Stadens invånare:");
                    for (int i = 0; i < cityList.Count; i++)
                    {
                        Console.Write("Person " + (i + 1) + " ");
                        cityList[i].GetInfo();
                    }
                    Console.WriteLine("Fängslade brottslingar:");
                    for (int i = 0; i < prisonList.Count; i++)
                    {
                        Console.Write("Person " + (i + 1) + " ");
                        prisonList[i].GetInfo();
                    }
                    Console.WriteLine("De i 'utanförskap':");
                    for (int i = 0; i < poorHouseList.Count; i++)
                    {
                        Console.Write("Person " + (i + 1) + " ");
                        poorHouseList[i].GetInfo();
                    }

                    Thread.Sleep(1000);
                    Console.Clear();
                }

            }
        }
    }
}