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

        public void Draw()
        {
            foreach (Person people in personList)
            {
                grid[people.PosX, people.PosY] = people;
            }

           
                //Print map of city and people
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

    }
}
