namespace Tjuv___Polis
{
    public class Vigilante : Person
    {
        public List<Item> Gadgets { get; set; }
        public Vigilante(int posX, int posY, List<Item> gadgets)
        {
            PosX = posX;
            PosY = posY;
            Gadgets = gadgets;
        }

        public override void Action(Person person)
        {
            if (person is Thief thief && thief.Loot.Count > 0)
            {
                //Vigilante immobilizes thief for 5 turns
                thief.Immobilized = true;
                thief.ImmobilizedCountdown = 5;
                Console.WriteLine("Batman slår till och immobiliserar tjuven.");
                Thread.Sleep(2000);
                Move();
            }
            else
            {
                Move();
                person.Move();
            }
        }
    }

}
