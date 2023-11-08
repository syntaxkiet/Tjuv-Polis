using System;
using System.Numerics;
using System.Security.Cryptography;
using WMPLib;

namespace Tjuv___Polis
{
    
    public class Vigilante : Person
    {
        static WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public List<Item> Gadgets { get; set; }
        public Vigilante(int posX, int posY, List<Item> gadgets)
        {
            PosX = posX;
            PosY = posY;
            Gadgets = gadgets;
        }

        public int ActiveTime = 30;

        public void DetectProximity()
        {
            //Traverse all the neighboring squares to see if there is an interactable object
            Action(PosX, (PosY + 1));
            Action((PosX + 1), (PosY + 1));
            Action((PosX + 1), PosY);
            Action((PosX + 1), (PosY - 1));
            Action(PosX, (PosY - 1));
            Action((PosX - 1), (PosY - 1));
            Action((PosX - 1), PosY);
            Action((PosX - 1), (PosY + 1));

            }

        void Action(int posX, int posY)
        {
            //If interactable object found, immobilize the target. This function is used in combination with DetectProximity()
            for (int i = 0; i < Program.cityList.Count; i++)
            {
                if (Program.cityList[i] is Thief thief && posX == thief.PosX && posY == thief.PosY)
                {
                    if (thief.Loot.Count > 0 && thief.Immobilized == false)
                    {
                        thief.Immobilized = true;
                        thief.ImmobilizedCountdown = 10;
                        Console.WriteLine("Hjälten slår till och immobiliserar tjuven!");
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        public override void Action(Person person)
        {
            //If interactable object found, immobilize the target, otherwise, move to prevent overlap. 
            if (person is Thief thief && thief.Loot.Count > 0)
            {
                
                thief.Immobilized = true;
                thief.ImmobilizedCountdown = 10;
                Console.WriteLine("Hjälten slår till och immobiliserar tjuven!");
                Thread.Sleep(2000);
                Move();
            }
            else
            {
                Move();
                person.Move();
            }
        }

        
        public static void SpawnVigilante()
        {
            Random rng = new Random();
            //Randomize an index from a temporary list of Civilian objects
            List<int> vigilanteList = new List<int>();
            for (int i = 0; i < Program.cityList.Count; i++)
            {
                if (Program.cityList[i] is Civilian)
                {
                    vigilanteList.Add(i);
                }
            }

            //From the randomized index value of Civilian objects, spawn a Vigilante that inherits their position and held items. 
            int vigilantePick = vigilanteList[rng.Next(vigilanteList.Count)];
            Program.cityList[vigilantePick] = new Vigilante(Program.cityList[vigilantePick].PosX, Program.cityList[vigilantePick].PosY, ((Civilian)Program.cityList[vigilantePick]).Possessions);
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
            Program.vigilanteSpawnCD = 20;
            Thread.Sleep(4000);

            Program.robberyCount++;
        }

        public static void DespawnVigilante()
        {
            //Despawn the latest Vigilante
            for (int i = 0; i < Program.cityList.Count; i++)
            {
                if (Program.cityList[i] is Vigilante)
                {
                    Program.cityList[i] = new Civilian();
                    Console.WriteLine("Hjälten försvinner i nattens ridå, för stunden...");
                    Program.vigilanteDespawnCD = 10;
                    Thread.Sleep(2000);
                    break;
                }

            }
            player.controls.stop();
        }

        public static void UpdateVigilante()
        {
            //Vigilante spawning logic
            if (Program.vigilanteSpawnCD > 0)
            {
                Program.vigilanteSpawnCD--;
            }

            if (Program.vigilanteDespawnCD > 0)
            {
                Program.vigilanteDespawnCD--;

            }
        }


    }

}
