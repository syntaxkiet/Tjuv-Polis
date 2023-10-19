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
            if (person is Thief && (((Thief)person).Loot.Count > 0))                    //If person is thief and the thiefs lootcount is bigger than zero
            {
                Program.arrestCount++;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Polisen slår till mot tjuven och beslagtar hans samtliga byten");                //Police takes action and sends thief to jail. Thief inv resets. 
                //Confiscated = Enumerable.Concat(Confiscated, ((Thief)person).Loot).ToList();
                Confiscated.AddRange(((Thief)person).Loot);
                (((Thief)person).SentenceTime) = (((Thief)person).Loot.Count) * 10;
                (((Thief)person).Loot).Clear();
                Random rng = new Random();
                person.PosX = rng.Next(0, Program.prisonSize);
                person.PosY = rng.Next(0, Program.prisonSize);
                Program.prisonList.Add(person);
                Program.personList.Remove(person);
                Thread.Sleep(2000);
                //Move();
                //person.Move();
            }
            else
            {
                Move();
                person.Move();
            }
        }
    }
}
