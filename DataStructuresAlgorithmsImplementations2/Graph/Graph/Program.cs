using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {

        static List<Vertex<string>> vertices = new List<Vertex<string>>();
        static List<WeightedEdge<string>> weightedEdges = new List<WeightedEdge<string>>();

        static StreamReader cityNetworkFile = 
            cityNetworkFile = new StreamReader(
                @"C:\Users\barse\Desktop\Github\Miscellaneous\DataStructuresAlgorithmsImplementations2\Graph\Graph\citynetworkweights.txt");


        static void Main(string[] args)
        {

            LoadVertices();

            foreach (Vertex<string> vertex in vertices)
            {
                Console.WriteLine(vertex.ToString());
            }
            
            Console.WriteLine();
        }

        static void AddItemsToList<T>(List<T> toList, params T[] values)
        {
            toList.AddRange(values);
        }

        static void LoadVertices()
        {

            string currentLine = cityNetworkFile.ReadLine();
            string[] cityAndNeighbors;

            while(currentLine != null)
            {
                cityAndNeighbors = currentLine.Split(':');

                CreateEdges(cityAndNeighbors);

                currentLine = cityNetworkFile.ReadLine();
            }
            
        }

        static void CreateEdges(string[] cityAndNeighbors)
        {
            Vertex<string> currentCity = new Vertex<string>(cityAndNeighbors[0]);

            vertices.Add(currentCity);


            if (cityAndNeighbors[1] != "")
            {
                string neighbors = cityAndNeighbors[1];
                string[] neighborsWithWeights = neighbors.Split(';');

                foreach (string neighborAndWeight in neighborsWithWeights)
                {

                    string[] neighbor = neighborAndWeight.Split(',');

                    Vertex<string> endpoint = new Vertex<string>(neighbor[0]);
                    int weight = int.Parse(neighbor[1]);

                    WeightedEdge<string> edge = new WeightedEdge<string>(currentCity, endpoint, weight);

                    weightedEdges.Add(edge);

                }

            }
        }

    }
}
