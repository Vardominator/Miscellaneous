using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex<T>
    {
        List<Vertex<T>> neighbors;   
        T value;
        
        public List<Vertex<T>> Neighbors { get { return neighbors; } }
        public T Value { get { return value; } set { this.value = value; } }
        public bool IsVisited { get; set; }
        public int NeighborsCount { get { return neighbors.Count; } }

        public Vertex(T value)
        {
            this.value = value;
            IsVisited = false;
            neighbors = new List<Vertex<T>>();
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
        public void AddEdge(Vertex<T> vertex)
        {
            neighbors.Add(vertex);
        }
        public void AddEdges(List<Vertex<T>> newNeighbors)
        {
            neighbors.AddRange(newNeighbors);
        }
        public void RemoveEdge(Vertex<T> vertex)
        {
            neighbors.Remove(vertex);
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
