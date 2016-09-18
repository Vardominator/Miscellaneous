using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Location
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double DistanceTo(Location end)
        {
            return Math.Sqrt(Math.Pow(this.x - end.X, 2) + Math.Pow(this.y - end.Y, 2));
        }

        public override string ToString()
        {
            return $"[{x},{y}]";
        }
    }
}
