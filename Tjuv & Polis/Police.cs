namespace Tjuv___Polis
{
    public class Police : Person
    {
        public List<Item> Confiscated { get; set; }                     //List that holds the thiefs stolen goods when caught. Empty from the start. 
        public Police() : base()
        {
            Confiscated = new List<Item>();                            //Constructor
        }
        public override void Action(Person person)
        {
            if (person is Thief thief && thief.Loot.Count > 0)                    //If person is thief and the thiefs lootcount is bigger than zero
            {
                Program.arrestCount++;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Polisen slår till mot tjuven och beslagtar hans samtliga byten");                //Police takes action and sends thief to jail. Thief inv resets.
                //Adds all loot indexes to police's confiscated items
                Confiscated.AddRange(thief.Loot);
                //Initiates sentence time depending on number of loot items
                thief.SentenceTime = (thief.Loot.Count * 10);
                thief.Loot.Clear();
                //Randomizes start point in prison
                Random rng = new Random();
                person.PosX = rng.Next(0, 10);
                person.PosY = rng.Next(0, 10);
                Program.prisonList.Add(person);
                Program.cityList.Remove(person);
                Thread.Sleep(2000);
            }
            else if(person is Civilian civ && civ.Possessions.Count == 0)
            {
                Console.WriteLine("Polisen tar den luspanka medborgaren i sitt förvar, och denna finner sitt nya hem i fattighuset.");
                Random rng = new Random();
                person.PosX = rng.Next(0, 10);
                person.PosY = rng.Next(0, 10);
                Program.poorHouseList.Add(person);
                Program.cityList.Remove(person);
                Thread.Sleep(2000);
            }

            else
            {
                Move();
                person.Move();
            }
        }
    }
}
