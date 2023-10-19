namespace Tjuv___Polis
{
    public class Civilian : Person
    {
        public List<Item> Possessions { get; set; }
        public Civilian() : base()
        {
            Possessions = new List<Item>();                     //List of things. 
            Possessions.Add(new Item("Nycklar"));
            Possessions.Add(new Item("Mobil"));
            Possessions.Add(new Item("Pengar"));                    //Each civilian has these 5 following things. 
            Possessions.Add(new Item("Klocka"));
        }

        public override void Action(Person person)
        {
            if (person is Police || person is Civilian)
            {
                Move();
                person.Move();
            }
        }
    }
}
