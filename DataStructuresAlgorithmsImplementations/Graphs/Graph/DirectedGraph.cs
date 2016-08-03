using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class DirectedGraph<T>
    {

        private List<Vertex<T>> vertices;

        public List<Vertex<T>> Vertices { get { return vertices; } }
        public int Size { get { return vertices.Count; } }

        public DirectedGraph(List<Vertex<T>> initialNodes)
        {
            vertices = initialNodes;
        }

        //public void AddEdge(Vertex<T> vertexA, Vertex<T> vertexB)
        //{
        //    vertexA.AddEdge(vertexB);
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

                foreach (Vertex<T> neighbor in root.Neighbors)
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
    }
}
