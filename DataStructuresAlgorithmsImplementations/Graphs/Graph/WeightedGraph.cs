using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class WeightedGraph<T>
    {
        List<WeightedEdge<T>> edges;

        public List<WeightedEdge<T>> Edges { get { return edges; } }

        public WeightedGraph(List<WeightedEdge<T>> initialEdges)
        {
            edges = initialEdges;
        }

        public void AddEdge(WeightedEdge<T> newEdge)
        {
            edges.Add(newEdge);
        }
        public void RemoveEdge(WeightedEdge<T> edge)
        {
            edges.Remove(edge);
        }
    }
}
