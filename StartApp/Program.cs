using System;

namespace Data_Struct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
        studentName:
            Console.WriteLine("\n*************************************************************************");
            Console.Write("Hi! What's your Name? :");
            string userInput = Console.ReadLine();

            StartApp.studentName = userInput.ToUpper();

            Console.WriteLine(StartApp.studentName);

            if (userInput == " " || userInput == string.Empty)
            {
                Console.Clear();
                Console.WriteLine("\n*************************************************************************");
                AddFun.CustomMessage("\nField can't be empty!!!", false);
                Console.WriteLine("**************************************************************************");
                goto studentName;

            }
            else if (userInput.Length <= 2)
            {
                Console.Clear();
                Console.WriteLine("\n*************************************************************************");
                AddFun.CustomMessage("\nUsername too short!!!", false);
                Console.WriteLine("**************************************************************************");
                goto studentName;
            }

            Console.Clear();
            StartApp.Play();
            //Console.WriteLine(StartApp.studentName);
        }
    }
}

