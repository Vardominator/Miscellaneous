﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonSkeetCSInDepthCh2
{

    delegate void StringProcessor(string input);

    class Person
    {
        string name;
        public Person(string name) { this.name = name; }

        public void Say(string message)
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }
    }

    class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Person jon = new Person("Jon");
            Person tom = new Person("Tom");

            StringProcessor jonsVoice, tomsVoice, background;

            jonsVoice = new StringProcessor(jon.Say);
            tomsVoice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);
            jonsVoice("Hello, son!");
            tomsVoice.Invoke("Hello, Daddy!");
            background("An airplane flies past.");

        }
    }
}
