﻿using System;
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

        public WeightedGraph(List<Vertex<T>> vertices, List<WeightedEdge<T>> edges)
        {
            this.vertices = vertices;
            this.edges = edges;
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
            Dictionary<Vertex<T>, Vertex<T>> parentMap = new Dictionary<Vertex<T>, Vertex<T>>();
            PriorityQueue<Vertex<T>> priorityQueue = new PriorityQueue<Vertex<T>>();

            InitializeCosts(start);
            priorityQueue.Enqueue(start, start.Cost);

            Vertex<T> current;

            while (priorityQueue.Count > 0)
            {
                current = priorityQueue.Dequeue();

                if (!current.IsVisited)
                {
                    current.Visit();

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
                            double priority = newCost;
                            priorityQueue.Enqueue(neighbor, priority);
                        }
                    }
                }
            }
            List<Vertex<T>> path = ReconstructPath(parentMap, start, end);
            return path;
        }


        public List<Vertex<T>> AStarSearch(Vertex<T> start, Vertex<T> end)
        {
            Dictionary<Vertex<T>, Vertex<T>> parentMap = new Dictionary<Vertex<T>, Vertex<T>>();
            PriorityQueue<Vertex<T>> priorityQueue = new PriorityQueue<Vertex<T>>();

            InitializeCosts(start);
            InitializeDistances(start);
            priorityQueue.Enqueue(start, start.Cost);

            Vertex<T> current;

            while (priorityQueue.Count > 0)
            {
                current = priorityQueue.Dequeue();

                if (!current.IsVisited)
                {
                    current.Visit();

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

        public void InitializeCosts(Vertex<T> start)
        {
            foreach (Vertex<T> vertex in vertices)
            {
                vertex.Cost = int.MaxValue;
            }

            start.Cost = 0;

        }
    
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

        // For A*
        public void InitializeDistances(Vertex<T> start)
        {
            foreach(Vertex<T> vertex in vertices)
            {
                vertex.Distance = start.Location.DistanceTo(vertex.Location);
            }
            start.Distance = 0.0;
        }

    }
}
