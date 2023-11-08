using System.Security.Cryptography;

namespace Tjuv___Polis
{
    public class Civilian : Person
    {
        List<Item> itemList = new List<Item>()
        {
            new Item("Nycklar"),
            new Item("Mobil"),
            new Item("Pengar"),
            new Item("Klocka"),
            new Item("Plånbok"),
            new Item("Surfplatta"),
            new Item("Dator"),
            new Item("Smycken"),
        };
        Random rng = new Random();

        public List<Item> Possessions;

        public Civilian() : base()
        {
            Possessions = new List<Item>();
            for (int i = 0; i < 4; i++)
            {
                int itemPick = rng.Next(itemList.Count);
                Possessions.Add(itemList[itemPick]);
            }

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
