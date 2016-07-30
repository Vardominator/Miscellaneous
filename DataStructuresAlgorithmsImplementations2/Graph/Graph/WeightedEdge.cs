using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class WeightedEdge<T>
    {
        int weight;
        Vertex<T> start;
        Vertex<T> end;

        public int Weight { get { return weight; } }

        public Vertex<T> Start { get { return start; } }
        public Vertex<T> End { get { return end; } }

        public WeightedEdge(Vertex<T> start, Vertex<T> end, int weight)
        {
            this.start = start;
            this.end = end;
            this.weight = weight;
            start.Neighbors.Add(end);
        }

        public override string ToString()
        {
            return string.Format("{0}--{1}-->{2}", start.Value, weight, end.Value);
        }
    }
}
