using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv___Polis
{
    public class Person
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Person()
        {
            
        }

    }

    public class Thief : Person
    {

    }

    public class Police : Person
    {

    }

    public class Citizen : Person
    {

    }
}
