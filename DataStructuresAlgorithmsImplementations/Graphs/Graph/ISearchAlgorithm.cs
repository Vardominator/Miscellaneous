using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public interface ISearchAlgorithm<T>
    {
        List<Vertex<T>> Search(WeightedGraph<T> graph, Vertex<T> start, Vertex<T> end);
        List<Vertex<T>> ReconstructPath(Dictionary<Vertex<T>, Vertex<T>> parentMap, Vertex<T> start, Vertex<T> end);
        void InitializeCosts(WeightedGraph<T> graph, Vertex<T> start);
    }

}
