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

        static List<Vertex<string>> vertices;
        static List<WeightedEdge<string>> weightedEdges;
        static WeightedGraph<string> graph;
        

        static void Main(string[] args)
        {

            vertices = new List<Vertex<string>>();
            weightedEdges = new List<WeightedEdge<string>>();

            Vertex<string> LA = new Vertex<string>("Los Angeles");
            Vertex<string> SF = new Vertex<string>("San Francisco");
            Vertex<string> PAX = new Vertex<string>("Portland");
            Vertex<string> SEA = new Vertex<string>("Seattle");
            Vertex<string> LV = new Vertex<string>("Las Vegas");
            Vertex<string> MN = new Vertex<string>("Minneapolis");

            AddItemsToList(vertices, LA, SF, PAX, SEA, LV, MN);

            WeightedEdge<string> LAtoSF = new WeightedEdge<string>(LA, SF, 5);
            WeightedEdge<string> SFtoLA = new WeightedEdge<string>(SF, LA, 5);
            WeightedEdge<string> LAtoLV = new WeightedEdge<string>(LA, LV, 7);
            WeightedEdge<string> SFtoPAX = new WeightedEdge<string>(SF, PAX, 3);
            WeightedEdge<string> SFtoLV = new WeightedEdge<string>(SF, LV, 10);
            WeightedEdge<string> LVtoSF = new WeightedEdge<string>(LV, SF, 10);
            WeightedEdge<string> PAXtoSEA = new WeightedEdge<string>(PAX, SEA, 4);
            WeightedEdge<string> PAXtoMN = new WeightedEdge<string>(PAX, MN, 17);
            WeightedEdge<string> PAXtoSF = new WeightedEdge<string>(PAX, SF, 3);
            WeightedEdge<string> MNtoPAX = new WeightedEdge<string>(MN, PAX, 17);
            WeightedEdge<string> SEAtoMN = new WeightedEdge<string>(SEA, MN, 25);
            WeightedEdge<string> SEAtoPAX = new WeightedEdge<string>(SEA, PAX, 4);
            WeightedEdge<string> MNtoSEA = new WeightedEdge<string>(MN, SEA, 25);
            WeightedEdge<string> MNtoLV = new WeightedEdge<string>(MN, LV, 20);

            AddItemsToList(weightedEdges, LAtoSF, SFtoLV, LAtoLV, SFtoPAX, SFtoLV, LVtoSF);
            AddItemsToList(weightedEdges, PAXtoSEA, PAXtoMN, MNtoPAX, SEAtoMN, MNtoSEA, MNtoLV);


            foreach (Vertex<string> vertex in vertices)
            {
                Console.WriteLine(vertex.ToString());
            }
            
            Console.WriteLine();

            graph = new WeightedGraph<string>(vertices, weightedEdges);

            foreach (var vertex in vertices)
            {
                Console.WriteLine(vertex.Cost);
            }

            Console.WriteLine();

            List<Vertex<string>> path = graph.DijkstraSearch(LA, MN);

            foreach (var node in path)
            {

                Console.WriteLine(node.Value);

            }



        }


        static void AddItemsToList<T>(List<T> list, params T[] values)
        {
            list.AddRange(values);
        }

        static void LoadVertices()
        {

        }

        static void CreateEdges(string[] cityAndNeighbors, Vertex<string> currentCity)
        {


        }

    }
}
