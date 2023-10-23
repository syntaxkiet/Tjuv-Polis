namespace Tjuv___Polis
{
    public class Thief : Person
    {
        public int SentenceTime { get; set; }
        public List<Item> Loot { get; set; }
        public Thief() : base()
        {
            Loot = new List<Item>();
            SentenceTime = 0;
        }
        public override void Action(Person person)
        {
            if (person is Civilian civ && civ.Possessions.Count > 0)
            {
                Program.robberyCount++;
                Random rng = new Random();
                //Loots one random item and adds to loot list.
                int index = rng.Next(0, ((Civilian)person).Possessions.Count);
                Loot.Add(civ.Possessions[index]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tjuv rånar medborgare på " + civ.Possessions[index].Name);           //Thief takes 1 of civilians belongings and adds to his stolen goods. 
                civ.Possessions.RemoveAt(index);
                Thread.Sleep(2000);
                Move();
                person.Move();
            }
            else
            {
                Move();
                person.Move();
            }
        }
    }
}
