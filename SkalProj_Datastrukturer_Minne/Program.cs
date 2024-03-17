using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}

            //F2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
            //  List-klassen definierar en variabel för standardkapaciteten som börjar vid 4.
            //  När en Lista instantieras utan en given storlek så skapar den en tom
            //  underliggande array vars storlek ökas på när listans kapacitet överskrids.

            //F3. Med hur mycket ökar kapaciteten?
            //  När listans storlek överskider dess kapacitet så ökas den med sig själv gånger
            //  två, som definierat i Grow()-metoden. I vårat fall så börjar den med fyra,
            //  eftersom det är vad standard kapaciteten är satt till, och sedan 8, 16, 32, osv...

            //F4.Varför ökar inte listans kapacitet i samma takt som element läggs till?

            //5.Minskar kapaciteten när element tas bort ur listan ?
            //  Nej, kapaciteten minskas inte.

            //6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            //  Bla
            Console.Clear();
            List<string> theList = new List<string>();
            string input, value = String.Empty;
            int oldCapacity = 4;

            do
            {
                Console.WriteLine("Enter a value starting with '+' or '-'" +
                        "\nIf the value is perceeded by a '+' it will be added to a list." +
                        "\nIf it's perceeded by a '-' the value will be removed from the list." +
                        "\nPress '0' to exit back to the main menu.");
                Console.Write("\nYour input: ");

                input = Console.ReadLine();
                char nav = input[0];
                value = input.Substring(1);
                
                switch (nav)
                {

                    case '+':
                        theList.Add(value);
                        
                        if (oldCapacity != theList.Capacity)
                            Console.WriteLine($"Capacity increased by {oldCapacity}!");
                        oldCapacity = theList.Capacity;
                        
                        Console.WriteLine($"Current number of items in the list: {theList.Count}");
                        Console.WriteLine($"Current capacity of the list: {theList.Capacity}");
                        break;
                    case '-':
                        string entry = theList.Where(s => s.Equals(value)).FirstOrDefault();
                        theList.Remove(entry);
                        Console.WriteLine($"Current number of items in the list: {theList.Count}");
                        Console.WriteLine($"Current capacity of the list: {theList.Capacity}");
                        break;
                    case '*':
                        PrintContentsOfList(theList, oldCapacity);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            } while (input != "0");
        }

        static void PrintContentsOfList(List<string> strings, int oldCapacity)
        {
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Console.Clear();
            Queue<string> queue = new Queue<string>();
            string userInput = string.Empty;
            int x = 0;

            do
            {
                Console.WriteLine("1. Add a customer to the queue.");
                Console.WriteLine("2. Expediate a customer from the queue.");
                Console.WriteLine("3. Display queue.");
                Console.WriteLine("0. Exit.");
                Console.Write("Your selection: ");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        x++;
                        queue.Enqueue("New customer added: Customer"+x);
                        break;
                    case "2":
                        Console.WriteLine($"Customer removed from queue!!");
                        queue.Dequeue();
                        break;
                    case "3":
                        Console.WriteLine("\nCurrent customers in queue:");
                        for (int i = 0; i < queue.Count; i++)
                        {
                            string customer = queue.ElementAt<string>(i);
                            Console.WriteLine($"Customer {customer} with index {i+1}");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }

            } while (userInput != "0");
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }
    }
}

