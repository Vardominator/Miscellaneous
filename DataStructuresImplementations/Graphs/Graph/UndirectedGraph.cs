using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{

    /// <summary>
    /// Implementation of a generic, unweighted, undirected graph
    /// </summary>
    class UndirectedGraph<T>
    {
        List<Vertex<T>> vertices;

        public List<Vertex<T>> Vertices { get { return vertices; } }
        public int Size { get { return vertices.Count; }}

        public UndirectedGraph(List<Vertex<T>> initialVertices)
        {
            vertices = initialVertices;
        }

        //public void AddPair(Vertex<T> vertexA, Vertex<T> vertexB)
        //{
        //    vertexA.AddEdge(vertexB);
        //    vertexB.AddEdge(vertexA);
        //}
        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }
        public void RemoveVertex(Vertex<T> vertex)
        {
            vertices.Remove(vertex);
        }
        public bool HasVertex(Vertex<T> vertex)
        {
            return vertices.Contains(vertex);
        }

        public void DepthFirstTraverse(Vertex<T> root)
        {
            if (!root.IsVisited)
            {
                Console.WriteLine(root.Value);
                root.Visit();

                foreach(Vertex<T> neighbor in root.Neighbors)
                {
                    DepthFirstTraverse(neighbor);
                }
            }
        }
        public void BreadthFirstTraverse(Vertex<T> root)
        {
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Console.WriteLine(root.Value);

            root.Visit();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Vertex<T> current = queue.Dequeue();
                foreach (Vertex<T> neighbor in current.Neighbors)
                {
                    if (!neighbor.IsVisited)
                    {
                        Console.WriteLine(neighbor.Value);
                        neighbor.Visit();
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        public void ResetVisits()
        {
            foreach (Vertex<T> vertex in vertices)
            {
                vertex.IsVisited = false;
            }
        }
    }
}
