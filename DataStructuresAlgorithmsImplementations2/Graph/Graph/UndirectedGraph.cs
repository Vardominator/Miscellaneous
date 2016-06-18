using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{

    /// <summary>
    /// Implementation of an integer, unweighted, undirected graph data structure
    /// 
    /// Searching algorithms implemented:
    ///     Breadth-first search
    ///     Depth-first search
    /// </summary>

    class UndirectedGraph
    {

        // An array of lists containing the nodes for each vertex of the graph
        private List<int>[] vertices;

        int size;

        bool[] visited;

        public List<int>[] Vertices { get { return vertices; } }
        public int Size { get { return vertices.Length; } }


        public UndirectedGraph(int initialSize)
        {

            if (size < 0)
            {
                throw new ArgumentException("Number of vertices cannot be negative");
            }

            size = initialSize;
            vertices = new List<int>[size];
            visited = new bool[size];

            for(int i = 0; i < size; i++)
            {
                vertices[i] = new List<int>();
            }
            
        }

        public UndirectedGraph(List<int>[] initialNodes)
        {
            vertices = initialNodes;
            size = vertices.Length;
            visited = new bool[initialNodes.Length];
        }


        // Adds an edge to a given node
        public void AddEdge(int index, int value)
        {
            vertices[index].Add(value);
        }

        // Removes an edge from a given node
        public void RemoveEdge(int index, int value)
        {
            vertices[index].Remove(value);
            size--;
        }

        // Indicites whether a given Node has an edge to a given node
        public bool HasEdge(int index, int value)
        {
            return vertices[index].Contains(value);
        }

        // Searches the graph recursively in a depth first manner
        public void DepthFirstSearch(int root)
        {
            if (!visited[root])
            {
                Console.Write(root + " ");
                visited[root] = true;
                foreach(int neighbor in GetSuccessors(root))
                {
                    DepthFirstSearch(neighbor);
                }
            }
            
        }

        // Searches the graph using a Queue in a breadth first manner
        public void BreadthFirstSearch(int root)
        {

            Queue<int> queue = new Queue<int>();
            visited[root] = true;

            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int current = queue.Dequeue();

                foreach(int neighbor in GetSuccessors(current))
                {

                    if (!visited[neighbor])
                    {
                        Console.Write(neighbor + " ");
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }

                }

            }
            
        }


        public override string ToString()
        {

            StringBuilder graphStructure = new StringBuilder("");

            for(int i = 0; i < vertices.Length; i++)
            {
                graphStructure.Append(i + ": ");
                for(int j = 0; j < vertices[i].Count; j++)
                {
                    graphStructure.Append(vertices[i][j] + " ");
                }
                graphStructure.Append("\n");
            }

            return graphStructure.ToString();

        }

        public IList<int> GetSuccessors(int vertexIndex)
        {
            return vertices[vertexIndex];
        }

        public bool IsVisited(int vertex)
        {
            return visited[vertex];
        }

        public void ResetVisited()
        {
            for(int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
        }

    }
}
