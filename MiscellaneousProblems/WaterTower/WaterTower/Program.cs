using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTower
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] towers = { 4,3,2,1,2,3,4};
            
            int currentMinimum = towers[0];
            
            bool rightBoundFound = false;

            int i = 0;
            int leftBoundIndex = 0;
            int rightBoundIndex = 0;

            int waterAdded = 0;

            while(i < towers.Length - 1)
            {

                currentMinimum = towers[i];

                if(towers[i] < currentMinimum)
                {
                    currentMinimum = towers[i];
                }

                if(towers[i + 1] > towers[i])
                {
                    rightBoundFound = true;
                    rightBoundIndex = i + 1;
                }

                if (rightBoundFound)
                {

                    for(int j = leftBoundIndex + 1; j < rightBoundIndex; j++)
                    {

                        int difference = 0;

                        if(towers[leftBoundIndex] < towers[rightBoundIndex])
                        {
                            difference = towers[leftBoundIndex] - towers[j];
                        }
                        else if(towers[leftBoundIndex] > towers[rightBoundIndex])
                        {
                            difference = towers[rightBoundIndex] - towers[j];
                        }
                        else
                        {
                            difference = towers[rightBoundIndex] - towers[j];
                        }

                        towers[j] += difference;
                        waterAdded += difference;

                    }

                    if (towers[leftBoundIndex] > towers[rightBoundIndex])
                    {
                        i = leftBoundIndex - 1;
                    }
                    else if (towers[rightBoundIndex] > towers[leftBoundIndex])
                    {
                        leftBoundIndex = rightBoundIndex;
                        i = rightBoundIndex - 1;
                    }
                    else
                    {
                        leftBoundIndex = rightBoundIndex;
                        i = rightBoundIndex - 1;
                    }
                    rightBoundFound = false;

                }
                
                i++;

            }

            Console.WriteLine("Water added: " + waterAdded);

            Console.ReadKey();

        }
    }
}
