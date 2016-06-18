using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas2
{

    /// <summary>
    /// What are events?
    /// 
    /// Essentially notification systems.  It is a way to notify other objects when 
    /// a specific action as occured. 
    /// 
    /// Events work with delegates. You must subscribe to the event handler. 
    /// 
    /// </summary>


    class Program
    {
        static void Main(string[] args)
        {

            Person p = new Person();
            // We added this function to the invocation list of the delegate
            p.cashEvent += p_cashEvent;
            // Use the delegates power to hold references to functions

            // Subscribe an expression lambda
            //p.cashEvent += (Person person) => Console.WriteLine("haha loser!") ;

            p.AddCash(55.0);
            p.AddCash(50.0);
       
            Console.WriteLine(p.Cash);

        }

        // This function has to work with the requirements of the delegate
        private static void p_cashEvent(Person p)
        {
            p.Cash = 0;
        }

        // Functions subscribed to the MyEventHandler invocation list: a lambda and p_cashEvent

    }


    public class Person
    {

        // The delegate fires all events subscribed to its invocation list
        public delegate void MyEventHandler(Person p);
        public event MyEventHandler cashEvent;  // an event will be null if it has no subscribers

        private double cash;
        public double Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
                if(cash > 100.00)
                {
                    // let our subscribers know
                    if(cashEvent != null)
                    {
                        cashEvent(this); // fires the event

                    }
                }
            }
        }

        // Want to notify everyone when a person has gotten 100 dollars
        public void AddCash(double amount)
        {
            Cash += amount;
        }

    }


}
