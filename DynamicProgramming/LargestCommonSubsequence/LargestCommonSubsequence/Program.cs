using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "abcbdab";
            string y = "bdcababa";


        }

        public static int LCSLength(string x, string y)
        {
            int m = x.Length;
            int n = y.Length;
            
            int[,] c = new int[m, n];
            
            for(int i = 1; i < m; i++)
            {
                for(int j = 1;j < n; j++)
                {
                    if(x[i] == y[j])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        c[i, j] = Math.Max(c[i, j - 1], c[i - 1, j]);
                    }
                }
            }

            return c[m - 1, n - 1];
        }
    }
}
