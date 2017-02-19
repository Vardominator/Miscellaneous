using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        string[] words = new string[] { "Hi", "This", "is", "a", "multithreading", "question", "to", "assess", "your", "thread", "synchronization", "skills" };

        ParalellForEach(words, Console.WriteLine, 12);

    }

    public static void ParalellForEach(object[] items, Action<object> action, int n)
    {

        Thread[] nThreads = new Thread[n];
        int start = 0;
        int end = items.Length / n;

        for (int i = 0; i < nThreads.Length; i++)
        {
            nThreads[i] = new Thread(() =>
            {

                for (int j = start; j < end; j++)
                {
                    action(items[j]);
                }

                start += items.Length / n;
                end += items.Length / n;

            });

            nThreads[i].Start();
        }


        for (int i = 0; i < nThreads.Length; i++)
        {
            nThreads[i].Join();
        }


    }

}