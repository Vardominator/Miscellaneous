using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class AStarSearch<T> : SearchAlgorithm<T>
    {
        public override List<Vertex<T>> Search(WeightedGraph<T> graph, Vertex<T> start, Vertex<T> end)
        {
            Dictionary<Vertex<T>, Vertex<T>> parentMap = new Dictionary<Vertex<T>, Vertex<T>>();
            PriorityQueue<Vertex<T>> priorityQueue = new PriorityQueue<Vertex<T>>();

            InitializeCosts(graph, start);
            priorityQueue.Enqueue(start, start.Cost);

            Vertex<T> current;

            while (priorityQueue.Count > 0)
            {
                current = priorityQueue.Dequeue();

                if (!current.IsVisited)
                {
                    current.IsVisited = true;

                    if (current.Equals(end))
                    {
                        break;
                    }

                    foreach (WeightedEdge<T> edge in current.Edges)
                    {
                        Vertex<T> neighbor = edge.End;

                        double newCost = current.Cost + edge.Weight;
                        double neighborCost = neighbor.Cost;

                        if (newCost < neighborCost)
                        {
                            neighbor.Cost = newCost;
                            parentMap.Add(neighbor, current);
                            double priority = newCost + Heuristic(neighbor, end);
                            priorityQueue.Enqueue(neighbor, priority);
                        }
                    }
                }
            }
            List<Vertex<T>> path = ReconstructPath(parentMap, start, end);
            return path;
        }

        public double Heuristic(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            return vertexA.Location.DistanceTo(vertexB.Location);
        }
    }
}
