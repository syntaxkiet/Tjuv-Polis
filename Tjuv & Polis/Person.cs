namespace Tjuv___Polis
{
    public class Person
    {
        public int PosX { get; set; }       
        //Initiate X and Y positions
        public int PosY { get; set; }

        int direction;          //Declares an int called direction. 
        Random rng;              

        public void Move()
        {
            rng = new Random();
            direction = rng.Next(0, 8);         //Gives a random number between 0-7 to initiate a move


            switch (direction)                 //Switches direction according to the random number generated. 
            {
                case 0:
                    PosY++;                     
                    break;
                case 1:
                    PosY++;
                    PosX++;
                    break;
                case 2:
                    PosX++;
                    break;
                case 3:
                    PosY--;
                    PosX++;
                    break;
                case 4:
                    PosY--;
                    break;
                case 5:
                    PosY--;
                    PosX--;
                    break;
                case 6:
                    PosX--;
                    break;
                case 7:
                    PosY++;
                    PosX--;
                    break;
            }
            CheckOutOfBounds();
        }

        public void CheckOutOfBounds()                                      //Check if person if out of bound and replace positon to other end. 
        {
            if (PosX < 0 && PosY < 0)
            {
                PosY = Program.citySizeY - 1;
                PosX = Program.citySizeX - 1;
            }
            else if (PosX > Program.citySizeX - 1 && PosY > Program.citySizeY - 1)
            {
                PosY = 0;
                PosX = 0;
            }
            else if (PosX > Program.citySizeX - 1 && PosY < 0)
            {
                PosX = 0;
                PosY = Program.citySizeY - 1;
            }
            else if (PosX < 0 && PosY > Program.citySizeY - 1)
            {
                PosX = Program.citySizeX - 1;
                PosY = 0;
            }

            else if (PosX > Program.citySizeX - 1)
            {
                PosX = 0;
            }
            else if (PosX < 0)
            {
                PosX = Program.citySizeX - 1;
            }
            else if (PosY > Program.citySizeY - 1)
            {
                PosY = 0;
            }
            else if (PosY < 0)
            {
                PosY = Program.citySizeY - 1;
            }
        }

        public virtual void Action(Person person)
        {
            Console.WriteLine("Person gör någonting");          //Base virtual method 
        }

        public Person()
        {
            rng = new Random();
            PosX = rng.Next(0, Program.citySizeX);          //Gives start positon to each person (X,Y)
            PosY = rng.Next(0, Program.citySizeY);
        }
    }

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
                Confiscated = Enumerable.Concat(Confiscated, ((Thief)person).Loot).ToList();
                (((Thief)person).Loot).Clear();
                Thread.Sleep(2000);
                Move();
                person.Move();

            }
        }
    }

    public class Thief : Person
    {
        public List<Item> Loot { get; set; }                            
        public Thief() : base()
        {
            Loot = new List<Item>();

        }
        public override void Action(Person person)
        {
            if (person is Civilian)
            {
                Program.robberyCount++;
                Random rng = new Random();
                int index = rng.Next(0, ((Civilian)person).Possessions.Count);
                Loot.Add((((Civilian)person).Possessions[index]));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tjuv råna medborgare på " + (((Civilian)person).Possessions[index].Name));           //Thief takes 1 of civilians belongings and adds to his stolen goods. 
                ((Civilian)person).Possessions.RemoveAt(index);
                Thread.Sleep(2000);
                Move();
                person.Move();
            }
        }
    }

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
