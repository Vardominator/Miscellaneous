using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public abstract class SearchAlgorithm<T> : ISearchAlgorithm<T>
    {
        public abstract List<Vertex<T>> Search(WeightedGraph<T> graph, Vertex<T> start, Vertex<T> end);

        public List<Vertex<T>> ReconstructPath(Dictionary<Vertex<T>, Vertex<T>> parentMap, Vertex<T> start, Vertex<T> end)
        {
            List<Vertex<T>> path = new List<Vertex<T>>();
            Vertex<T> current = end;

            while (current != start)
            {
                path.Add(current);
                current = parentMap[current];
            }

            path.Add(start);

            path.Reverse();
            return path;
        }

        public void InitializeCosts(WeightedGraph<T> graph, Vertex<T> start)
        {
            foreach (Vertex<T> vertex in graph.Vertices)
            {
                vertex.Cost = int.MaxValue;
            }

            start.Cost = 0;
        }


    }
}
