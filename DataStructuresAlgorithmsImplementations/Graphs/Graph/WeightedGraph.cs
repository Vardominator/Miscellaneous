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
        List<Vertex<T>> vertices;

        public List<WeightedEdge<T>> Edges { get { return edges; } }

        public WeightedGraph(List<Vertex<T>> initialVertices, List<WeightedEdge<T>> initialEdges)
        {
            vertices = initialVertices;
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

        public List<Vertex<T>> DijkstraSearch(Vertex<T> start, Vertex<T> end)
        {
            List<Vertex<T>> path = new List<Vertex<T>>();
            List<Vertex<T>> unvisitedVertices = new List<Vertex<T>>();
            Vertex<T> current = start;

            InitializeCosts(start);

            unvisitedVertices.Add(current);

            while(current != end)
            {
                List<WeightedEdge<T>> currentNeighbors = current.Edges;

                int currentCost = int.MaxValue;

                current.IsVisited = true;
                unvisitedVertices.Remove(current);
                path.Add(current);

                foreach (WeightedEdge<T> edge in currentNeighbors)
                {
                    if(!edge.End.IsVisited)
                    {
                        edge.End.Cost = current.Cost + edge.Weight;
                    }

                    if (edge.End.Cost < currentCost && !edge.End.IsVisited)
                    {
                        currentCost = edge.End.Cost;
                        current = edge.End;
                    }
                }

                unvisitedVertices.Add(current);

            }
            
            path.Add(end);

            return path;

        }


        public List<Vertex<T>> AStarSearch(Vertex<T> start, Vertex<T> end)
        {

            throw new NotImplementedException();
        }

        public void InitializeCosts(Vertex<T> start)
        {

            foreach (Vertex<T> vertex in vertices)
            {
                vertex.Cost = int.MaxValue;
            }

            start.Cost = 0;

        }
       

    }
}
