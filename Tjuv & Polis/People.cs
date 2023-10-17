using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tjuv___Polis
{
    internal class People
    {
        public int posX { get; }
        public int posY { get; }

        int directionX, directionY;
        Random rng;
        List<Items> inventory = new List<Items>();

        public People(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

    }
}
