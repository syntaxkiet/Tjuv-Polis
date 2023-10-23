namespace Tjuv___Polis
{
    public class Person
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int directionX, directionY;
        int directionCooldown = 0;
        Random rng;

        public void Move()
        {
            rng = new Random();

            if (directionCooldown == 0)
            {
                directionX = 0;
                directionY = 0;
                int movement = rng.Next(0, 8);
                directionCooldown = 10;
                switch (movement)
                {
                    case 0:
                        directionY = 1;
                        break;
                    case 1:
                        directionY = 1;
                        directionX = 1;
                        break;
                    case 2:
                        directionX = 1;
                        break;
                    case 3:
                        directionY = -1;
                        directionX = 1;
                        break;
                    case 4:
                        directionY = -1;
                        break;
                    case 5:
                        directionY = -1;
                        directionX = -1;
                        break;
                    case 6:
                        directionX = -1;
                        break;
                    case 7:
                        directionY = 1;
                        directionX = -1;
                        break;
                }
            }

            PosX = PosX + directionX;
            PosY = PosY + directionY;
            directionCooldown--;

            if (Program.prisonList.Contains(this))
            {
                (((Thief)this).SentenceTime)--;
                CheckOutOfBoundsPrison();
                if ((((Thief)this).SentenceTime) == 0)
                {
                    Random rng = new Random();
                    this.PosX = rng.Next(0, Program.citySizeX);
                    this.PosY = rng.Next(0, Program.citySizeY);
                    Program.personList.Add(this);
                    Program.prisonList.Remove(this);
                }
            }
            else
            {
                CheckOutOfBoundsCity();
            }
        }

        public void GetInfo()
        {
            if (this is Civilian civilian)
            {
                Console.Write("Medborgare, " + "medhavande föremål: ");
                foreach (Item item in civilian.Possessions)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.Write("På plats: " + this.PosX + "," + this.PosY);
                Console.WriteLine();

            }

            if (this is Police police)
            {
                Console.Write("Polis, " + "medhavande föremål: ");
                foreach (Item item in police.Confiscated)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.Write("På plats: " + this.PosX + "," + this.PosY);
                Console.WriteLine();

            }

            if (this is Thief thief)
            {
                Console.Write("Tjuv, " + "medhavande föremål: ");
                foreach (Item item in thief.Loot)
                {
                    Console.Write(item.Name + ", ");
                }
                Console.Write("På plats: " + this.PosX + "," + this.PosY);
                Console.WriteLine();

            }

        }

        public void CheckOutOfBoundsCity()                                      //Check if person if out of bound and replace positon to other end. 
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

        public void CheckOutOfBoundsPrison()                                      //Check if person if out of bound and replace positon to other end. 
        {
            if (PosX < 0 && PosY < 0)
            {
                PosY = Program.prisonSize - 1;
                PosX = Program.prisonSize - 1;
            }
            else if (PosX > Program.prisonSize - 1 && PosY > Program.prisonSize - 1)
            {
                PosY = 0;
                PosX = 0;
            }
            else if (PosX > Program.prisonSize - 1 && PosY < 0)
            {
                PosX = 0;
                PosY = Program.prisonSize - 1;
            }
            else if (PosX < 0 && PosY > Program.prisonSize - 1)
            {
                PosX = Program.prisonSize - 1;
                PosY = 0;
            }

            else if (PosX > Program.prisonSize - 1)
            {
                PosX = 0;
            }
            else if (PosX < 0)
            {
                PosX = Program.prisonSize - 1;
            }
            else if (PosY > Program.prisonSize - 1)
            {
                PosY = 0;
            }
            else if (PosY < 0)
            {
                PosY = Program.prisonSize - 1;
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





}
