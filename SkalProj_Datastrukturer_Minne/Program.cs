using System;
using System.Collections;
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
            //  När listans kapacitet överskrids så kopieras alla föremål över till en ny
            //  array med större storlek.

            //5.Minskar kapaciteten när element tas bort ur listan ?
            //  Nej.

            //6.När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            //  Då en array har en fixerad storlek så är den bättre att använda istället för en
            //  lista om man vet att storleken på en kollektion inte kommer att ändras.
            Console.Clear();
            List<string> theList = new List<string>();
            string input, value = String.Empty;

            do
            {
                Console.WriteLine("Enter a value starting with '+' or '-'" +
                        "\nIf the value is perceeded by a '+' it will be added to a list." +
                        "\nIf it's perceeded by a '-' the value will be removed from the list." +
                        "\nPress '*' to print the current contents of the list." +
                        "\nPress '0' to exit back to the main menu.");
                Console.Write("\nYour input: ");

                input = Console.ReadLine();
                char nav = input[0];
                value = input.Substring(1);
                
                switch (nav)
                {

                    case '+':
                        theList.Add(value);
                        PrintListInformation(theList);
                        break;
                    case '-':
                        string entry = theList.Where(s => s.Equals(value)).FirstOrDefault();
                        theList.Remove(entry);
                        PrintListInformation(theList);
                        break;
                    case '*':
                        PrintCustomerList(theList);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            } while (input != "0");
        }

        static void PrintListInformation(List<string> strings)
        {
            Console.WriteLine($"Current number of items in the list: {strings.Count}");
            Console.WriteLine($"Current capacity of the list: {strings.Capacity}");
            Console.WriteLine();
        }

        static void PrintCustomerList(List<string> strings)
        {
            Console.WriteLine("Customers in list:");
            foreach (var item in strings)
            {
                Console.Write($"{item}\n");
            }
            PrintListInformation(strings);
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
            int customersAdded = 0;

            do
            {
                Console.WriteLine("1. Add a customer to the queue.");
                Console.WriteLine("2. Expediate a customer from the queue.");
                Console.WriteLine("3. Display customers in queue.");
                Console.WriteLine("0. Exit.");
                Console.Write("Your selection: ");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        customersAdded++;
                        queue.Enqueue($"\nNew customer added: Customer{customersAdded}");
                        break;
                    case "2":
                        queue.Dequeue();
                        Console.WriteLine($"\nA customer was removed from queue!");
                        break;
                    case "3":
                        Console.WriteLine("\nCurrent customers in queue:");
                        for (int i = 0; i < queue.Count; i++)
                        {
                            string customer = queue.ElementAt<string>(i);
                            Console.WriteLine($"\nCustomer {customer} with index {i+1}");
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
            //  1.Simulera ännu en gång ICA-kön på papper. Denna gång med en stack.Varför är det
            //  inte så smart att använda en stack i det här fallet?
            //  S: Då en stack arbetar med först-in sist-ut principen så skulle det betyda att den 
            //  första kunden i kön skulle behöva vänta tills alla andra kunder inom stack ramen
            //  betalat.
            Stack stack = new Stack();

            //todo: add null check
            string userInput = Console.ReadLine();
            string nav = string.Empty;

            do
            {
                Console.WriteLine("1. Push to the stack");
                Console.WriteLine("2. Pop the stack");
                Console.WriteLine("3. Reverse input");
                Console.WriteLine("4. Check stack");
                Console.WriteLine("0. Exit");
                Console.Write("Your input: ");
                nav = Console.ReadLine();
                switch (nav)
                {
                    case "1":
                        Console.WriteLine("Enter a string value which will be added to the stack.");
                        Console.Write("Your input: ");
                        userInput = Console.ReadLine();
                        stack.Push(userInput);
                        break;
                    case "2":
                        stack.Pop();
                        Console.WriteLine("Item popped from stack!");
                        break;
                    case "3":
                        Console.WriteLine("Enter a string value which will be added to the stack.");
                        userInput = Console.ReadLine();
                        Console.Write("Your input: ");
                        Console.WriteLine(ReverseText(userInput));
                        break;
                    case "4":
                        StackChecker(stack);
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            } while (nav != "0");

        }

        static string ReverseText(string userInput)
        {
            char[] userInputArray = userInput.ToCharArray();
            Stack stringReverser = new Stack();
            string toReturn = "";

            foreach (var item in userInputArray)
            {
                stringReverser.Push(item);
            }
            foreach (var item in userInputArray)
            {
                toReturn += stringReverser.Pop();
            }
            return toReturn;
        }

        static void StackChecker(Stack stack)
        {
            int index = 0;
            foreach (var item in stack)
            {
                Console.WriteLine($"String {item} with index {index}");
                index++;
            }
        }

        //  1. Skapa med hjälp av er nya kunskap funktionalitet för att kontrollera en välformad
        //  sträng på papper.Du ska använda dig av någon eller några av de datastrukturer vi
        //  precis gått igenom.Vilken datastruktur använder du?
        //  S: En datastruktur likt stacken skulle kunna fungera här eftersom att den har koll på 
        //  vilka variabler och undermetoder som lever inom ramen för en metod. 
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

