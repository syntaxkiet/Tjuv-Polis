using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv___Polis
{
    internal class Map
    {
        int sizeX;
        int sizeY;
        Person[,] grid;
        public List<Person> personList {  get; set; }
        string mapName;


        public Map(int sizeX, int sizeY, List<Person> personList, string mapName)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.personList = personList;
            this.mapName = mapName;
            grid = new Person[sizeX, sizeY];

        }

        //Draw out the grid with objects
        public void Draw()
        {
            foreach (Person people in personList)
            {
                grid[people.PosX, people.PosY] = people;
            }

                //Print map of the current grid, and people
                Console.WriteLine(mapName);
                for (int i = 0; i <= sizeX; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();

                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    for (int x = 0; x < grid.GetLength(0); x++)
                    {
                        if (grid[x, y] is Police)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("P");
                        }
                        if (grid[x, y] is Thief)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("T");
                        }
                        if (grid[x, y] is Civilian)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("M");
                        }
                        if (grid[x, y] is Vigilante)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("V");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i <= sizeX; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("_");
                }
                Console.WriteLine();

                Console.WriteLine();
            }

        //Clears the current grid, use ahead of a new draw
        public void Clear()
        {
            Array.Clear(grid);
        }

        //Move and update the position of each object in each list
        public static void MovementUpdate()
        {

 
            for (int i = 0; i < Program.prisonList.Count; i++)
            {
                Program.prisonList[i].Move();
            }

            for (int i = 0; i < Program.cityList.Count; i++)
            {
                Program.cityList[i].Move();
            }

            for (int i = 0; i < Program.poorHouseList.Count; i++)
            {
                Program.poorHouseList[i].Move();
            }


            //Compares objects' coordinates to initiate action if needed
            for (int i = 0; i < Program.cityList.Count; i++)
            {
                for (int y = 0; y < Program.cityList.Count; y++)
                {
                    if (Program.cityList[i].PosY == Program.cityList[y].PosY && Program.cityList[i].PosX == Program.cityList[y].PosX && Program.cityList[i] != Program.cityList[y])
                    {
                        Program.cityList[i].Action(Program.cityList[y]);
                    }
                }
            }
        }
        //Iterate through each of the lists and print out individual information for each object within each list
        public static void ShowInfo()
        {
           
            Console.WriteLine("Stadens invånare:");
            for (int i = 0; i < Program.cityList.Count; i++)
            {
                Console.Write("Person " + (i + 1) + " ");
                Program.cityList[i].GetInfo();
            }
            Console.WriteLine();
            Console.WriteLine("Fängslade brottslingar:");
            for (int i = 0; i < Program.prisonList.Count; i++)
            {
                Console.Write("Person " + (i + 1) + " ");
                Program.prisonList[i].GetInfo();
            }
            Console.WriteLine();
            Console.WriteLine("De i 'utanförskap':");
            for (int i = 0; i < Program.poorHouseList.Count; i++)
            {
                Console.Write("Person " + (i + 1) + " ");
                Program.poorHouseList[i].GetInfo();
            }
            Console.WriteLine();
        }
    }
}
