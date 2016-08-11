﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex<T>
    {
        List<Vertex<T>> neighbors;
        List<WeightedEdge<T>> edges;
        T value;
        
        public List<Vertex<T>> Neighbors { get { return neighbors; } }
        public List<WeightedEdge<T>> Edges { get { return edges; } }

        // For A*
        public Location Location { get; set; }
        public double Distance { get; set; }

        public T Value { get { return value; } set { this.value = value; } }
        public bool IsVisited { get; set; }
        public int NeighborsCount { get { return neighbors.Count; } }

        // Pathfinding
        public double Cost { get; set; }

        public Vertex(T value)
        {
            this.value = value;
            IsVisited = false;
            neighbors = new List<Vertex<T>>();
            edges = new List<WeightedEdge<T>>();
        }

        public Vertex(T value, List<Vertex<T>> neighbors)
        {
            this.value = value;
            IsVisited = false;
            this.neighbors = neighbors;
        }
        public void Visit()
        {
            IsVisited = true;
        }
        public void AddNeighbor(Vertex<T> vertex)
        {
            neighbors.Add(vertex);
        }
        public void AddEdge(WeightedEdge<T> edge)
        {
            edges.Add(edge);
        }

        public override string ToString()
        {
            StringBuilder allNeighbors = new StringBuilder("");
            allNeighbors.Append(value + ": ");

            foreach (Vertex<T> neighbor in neighbors)
            {
                allNeighbors.Append(neighbor.value + "  ");
            }

            return allNeighbors.ToString();
        }

    }
}
