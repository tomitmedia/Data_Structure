using System;
namespace Data_Struct
{
    public static class StartApp
    {
        public static string studentName { get; set; }

        public static void Play()
        {
            bool loopBreak = true;
            while (loopBreak == true)
            {

                Console.Clear();
                Console.WriteLine("\n*************************************************************************");
                AddFun.CustomMessage($"{StartApp.studentName.ToUpper()}! Welcome to Decagon-Tech-Park Portal...", true);
                Console.WriteLine("*************************************************************************");

                Console.WriteLine("*************************************************************************");
                AddFun.CustomMessage("\nWEEK 2 DATA STRUCTURE!!!", true);
            mainMenu:
                Console.WriteLine("\n*************************************************************************");
                Console.WriteLine("\nPress 1 to Stack");
                Console.WriteLine("Press 2 to Queue");
                Console.WriteLine("Press 3 to Linked List");
                Console.WriteLine("Press 4 to Exit");

                string mainMenuInput = Console.ReadLine();
                int mainMenuInput2 = 0;

                if (int.TryParse(mainMenuInput, out mainMenuInput2))
                {
                    switch (mainMenuInput2)
                    {
                        case 1:
                            Console.Clear();
                            Stack<string>.LaunchStack();
                            break;

                        case 2:
                            Console.Clear();
                            Queue<string>.LaunchQueue();
                            break;

                        case 3:
                            Console.Clear();
                            linkedList<string>.LaunchLinkedList();

                            break;

                        case 4:
                            Console.WriteLine("\n*************************************************************************");
                            Console.Write("\nAre you sure you want to logout?  Y/N: ");
                            string choice = Console.ReadLine().ToUpper();
                            if (choice == "Y")
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                Console.WriteLine("**************************************************************************");
                                Console.WriteLine("\nThank you for chosing Tech Way!");
                                loopBreak = false;
                                Environment.Exit(0);
                            }
                            else if (choice == "N")
                            {
                                Play();
                            }

                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            Console.WriteLine("**************************************************************************");
                            AddFun.CustomMessage("\nResponse can only be 'Y/N' ", false);
                            goto case 3;


                        default:
                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            AddFun.CustomMessage("\nChoose a number between 1 to 3!!!", false);
                            goto mainMenu;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*************************************************************************");
                    AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                    goto mainMenu;
                }
            }
        }
    }
}

