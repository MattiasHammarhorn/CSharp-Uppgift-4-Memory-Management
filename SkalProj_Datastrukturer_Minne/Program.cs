using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

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
            //  array med större storlek. Ur ett prestanda-perspektiv så kan det vara intressant 
            //  att då inte behöva omdefiniera den underliggande arrayen för varje nytt element.

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
            //  1.	Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion.
            //  Stacken ansvarar för att allokera minne åt variabler som deklarera inom eller returneras från metoder.Den lagrar främst värden av Value Types men kan även lagra referenser till objekt som lagras på heapen, och Struct - datatyper.Stackens struktur fungerar på en först -in-sist - ut nivå och kan liknas med en hög talrikar:
            //  1.När en variabel deklareras i en metod så sparas den längst ner i stacken likt en talrik.
            //  2.När metoden anropar en annan metod med parametrar så sparas parametrarna som talrikar som läggs på toppen.
            //  3.När den andra metoden returnerar ett värde så tas den högsta talriken bort.
            //  4.När den första metoden avslutats så tas alla talrikar bort i och med att de inte behövs längre.
            //  Dvs.När variablerna i en metod använt så rensas de när de inte behövs längre, och på detta sätt så ser stacken till att minnet inte tar slut.
            //  Referenser. [0]
            //  https://endjin.com/blog/2022/07/understanding-the-stack-and-heap-in-csharp-dotnet

           //Heapen förvarar Reference Types, d.v.s.större värden som objekt, klasser, interfaces, etc... T.ex.när ett objekt instantieras så allokeras minne för den någonstans i datorn, och en referens till det skapas på heapen.Till skillnad från stacken där alla värden endast kan kommas åt genom först -in-sist - ut, så har heapen alltid tillgång till alla värden samtidigt.Då värden på heapen stannar kvar tills(GC) Garbage Collection sker så kan det vara bra att ha itanke när man behöver Reference Types.
            //2.Vad är Value Types respektive Reference Types och vad skiljer dem åt?
            //Value Types är värden som ärver från System.ValueType - klassen och representarar mindre objekt som integers, booleans. De lagras huvudsakligen på stacken där de existerar inom ramen för metoder, men om de tillhör en property på en klass så lagras de också på heapen där de stannar kvar tills GC sker, även efter att stacken redan tagit bort dem.
            //
            //Reference Types tillhör större datatyper som klasser, interfaces och delegater – variabler som man kan tänkas behöva genom en större del av programmets gång.
            //
            //3.Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den
            //andra returnerar 4, varför ?
            //•	Den första metoden returnerar ”3” eftersom att variabeln ”x” som deklarerats tilldelas värde ”3” som inte ändras innan den returneras.
            //•	Den andra metoden returnerar 4 eftersom att variabeln ”x” är en instans av ”MyInt”-klassen vars ”MyValue”-property tilldelas värdet ”4” i slutet av metoden. När ”y” tilldelas värdet ”x” så kopieras en referens från objektet ”x”på heapen till ”y” – d.v.s att båda variablerna nu refererar till samma objekt på heapen.


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
        //  vilka variabler och undermetoder som lever inom ramen för en metod. Eftersom jag inte 
        //  kommer år så simulerar jag ramen för en metod inom stacken genom arrays och lists
        //  istället.
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            string userInput = "List<int> list = new List<int>() { 1, 2, 3, 4 )";
            char[] userInputToCharArray = userInput.ToCharArray();

            // Declare a list of parentheses to hold all the ones in the user input
            List<char> parenthesesList = new List<char>();

            for (int i = 0; i < userInputToCharArray.Length; i++)
            {
                if (userInput[i] == '(' || userInput[i] == '[' || userInput[i] == '{'||
                    userInput[i] == ')' || userInput[i] == ']' || userInput[i] == '}')
                    parenthesesList.Add(userInput[i]);
            }
            // Cast list containing parenthes into array since we can't grab entries by index in
            // for loops
            char[] parenthesesArray = parenthesesList.ToArray();

            // loop from bottom of the "stack" to see if there is a match in the "top"
            for (int i = 0; i < parenthesesArray.Length; i++)
            {
                var topIndex = parenthesesArray.Length - i;
                var bottomItem = parenthesesArray[i];

                // need a nested for loop to check from top of array down if a match can be made
                // foreach item starting from the top, check if the closing parenthesis can be made
                for (int j = topIndex; j > i; j--)
                {
                    if (bottomItem == '(' || parenthesesArray[topIndex] == ')')
                    {
                        parenthesesList.RemoveAt(i);
                        parenthesesList.RemoveAt(topIndex);
                    }
                    else if (bottomItem == '[' || parenthesesArray[topIndex] == ']')
                    {
                        parenthesesList.RemoveAt(i);
                        parenthesesList.RemoveAt(topIndex);
                    }
                    if (bottomItem == '{' || parenthesesArray[topIndex] == '}')
                    {
                        parenthesesList.RemoveAt(i);
                        parenthesesList.RemoveAt(topIndex);
                    }
                }
            }

            foreach (var item in parenthesesList)
            {
                Console.WriteLine(item);
            }

            if (parenthesesArray.Length > 0)
                Console.WriteLine("Format was incorrect!");
            else
                Console.WriteLine("Format was correct!");
            Console.ReadLine();
        }
    }
}

