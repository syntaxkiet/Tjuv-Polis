namespace Tjuv___Polis
{
    public class Civilian : Person
    {
        public List<Item> Possessions { get; set; }
        public Civilian() : base()
        {
             
            Possessions = new List<Item>    //List of things.
            {
            new Item("Nycklar"),
            new Item("Mobil"),
            new Item("Pengar"),                    //Each civilian has these 5 following things. 
            new Item("Klocka")

            };
            
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
