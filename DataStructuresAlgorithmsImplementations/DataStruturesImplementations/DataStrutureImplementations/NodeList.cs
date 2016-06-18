using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class NodeList<T>
    {

        private List<T> neighbors;

        public NodeList(int initialSize)
        {
            neighbors = new List<T>();
            AddNodes(initialSize);
        }

        public void AddNodes(int initialSize)
        {
            for (int i = 0; i < initialSize; i++)
            {
            }
        }

    }
}
