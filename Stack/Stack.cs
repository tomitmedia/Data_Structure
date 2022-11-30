using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Struct
{
    public class Stack<T> : IEnumerable<T>
    {
        linkedList<T> stack = new linkedList<T>();
        public int count { get; private set; }

        public int MaxSize { get; set; }
        public int Front = 0;
        public int Rear = 0;
        public int NItem { get; set; }
        public int Length = 0;
        public int pushCount = 0;

        public bool isEmpty() => stack.Count == 0 ? true : false;

        public int size()
        {
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T Item in stack)
            {
                yield return Item;

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            stack.Add(item);
            Rear++;
            NItem++;
        }

        public void Pop()
        {

            count--;
            T temp = stack.RemoveLast();
            Front++;
            if (Front == MaxSize)
            {
                Front = 0;
            }
            NItem--;
            Console.Clear();
            //Console.WriteLine("\n*************************************************************************");
            //Console.WriteLine("\n*************************************************************************");
            //Console.WriteLine($"\n{temp} Popped!");
            //Console.WriteLine("\n*************************************************************************");
        }

        public void Peek()
        {
            Console.Clear();
            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine($"\n{stack.PeekStack()} Peeked!");
            Console.WriteLine("\n*************************************************************************");
        }

        public bool isFull()
        {
            return (MaxSize - 1 == Front);
        }

        public void printItems()
        {
            Console.Clear();

            Console.Write("Loading Stack"); AddFun.PrintDotAnimation();
            Console.Clear();

            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine("Your Stack...");
            Console.WriteLine("*************************************************************************");
            if (isEmpty() == false)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n*************************************************************************");
            }
            else
            {
                Console.WriteLine("\nStack is Empty!!!");
                Console.WriteLine("\n*************************************************************************");
            }
        }



        public static void LaunchStack()
        {
            Stack<string> stackS = new Stack<string>();


            Console.Clear();
            bool loopBreak = true;
            while (loopBreak == true)
            {
                Console.WriteLine("*************************************************************************");
                AddFun.CustomMessage("\nSTACK MENU!!!", true);
            mainMenu:
                Console.WriteLine("\n*************************************************************************");
                Console.WriteLine("\n1. IsEmpty? ");
                Console.WriteLine("2. Push? ");
                Console.WriteLine("3. Pop? ");
                Console.WriteLine("4. Peek? ");
                Console.WriteLine("5. Print Stack? ");
                Console.WriteLine("6. Main Menu? ");

                string stackmenu = Console.ReadLine();
                int stackMenu = 0;

                if (int.TryParse(stackmenu, out stackMenu))
                {
                    switch (stackMenu)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            if (stackS.isEmpty())
                            {
                                Console.WriteLine("true");
                                Console.WriteLine("*************************************************************************");
                            }
                            else
                            {
                                Console.WriteLine("false");
                                Console.WriteLine("*************************************************************************");
                            }
                            break;

                        case 2:

                            Console.Clear();
                        maxSize:
                            Console.WriteLine("\n*************************************************************************");
                            Console.WriteLine("\nHow many Items would you like to stack up? ");
                            string Maxsize = Console.ReadLine();
                            int maxSize = 0;
                            if (!int.TryParse(Maxsize, out maxSize))
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                goto maxSize;
                            }
                            stackS.MaxSize = maxSize;
                            stackS.Length = stackS.MaxSize;

                            //if (stackS.pushCount != stackS.MaxSize)
                            //{
                            for (int i = 0; i < stackS.Length; i++)
                            {
                                Console.Clear();
                            Push:
                                var number = AddFun.AddOrdinal(i + 1);
                                Console.WriteLine("\n*************************************************************************");

                                Console.WriteLine($"Enter your {number} item ");
                                Console.WriteLine("\n*************************************************************************");

                                string Push = Console.ReadLine();
                                //int pusH = 0;

                                //if (int.TryParse(Push, out pusH))
                                //{
                                stackS.Push(Push);
                                stackS.pushCount++;
                                //}
                                //else
                                //  {
                                //  Console.Clear();
                                //  Console.WriteLine("\n*************************************************************************");
                                //  AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                //  goto Push;
                                //  }
                            }
                            stackS.printItems();
                            //}
                            //else
                            //{
                            //    Console.Clear();

                            //    AddFun.CustomMessage("Stack is full!!! Kindly Pop some item(s) and try again...",false);
                            //    Console.WriteLine("\n*************************************************************************");
                            //}

                            break;

                        case 3:
                            if (stackS.pushCount > 0)
                            {
                                Console.Clear();
                            pop:
                                Console.WriteLine("\n*************************************************************************");
                                Console.WriteLine("\nHow many Item(s) do you wanna Pop? ");
                                Console.WriteLine("\n*************************************************************************");
                                string stacklength = Console.ReadLine();
                                int stackLength = 0;

                                if (!int.TryParse(stacklength, out stackLength))
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n*************************************************************************");
                                    AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                    goto pop;
                                }
                                else if (stackS.pushCount < stackLength)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n*************************************************************************");
                                    AddFun.CustomMessage("\nEww!!! you can't pop more than you Pushed.", false);
                                    goto pop;

                                }
                                for (int i = 1; i <= stackLength; i++)
                                {
                                    Console.Clear();
                                    stackS.Pop();
                                    stackS.Length = stackLength;
                                    stackS.pushCount--;
                                }
                                stackS.printItems();
                                Console.WriteLine("\n*************************************************************************");
                                Console.WriteLine($"\nSuccessfully Popped!");
                                Console.WriteLine("\n*************************************************************************");
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Stack is empty!!! Kindly Push some item(s) and try again...", false);
                                Console.WriteLine("\n*************************************************************************");
                            }
                            break;

                        case 4:
                            if (stackS.pushCount > 0)
                            {
                                Console.Clear();
                                stackS.Peek();
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Stack is empty!!! Kindly Push some item(s) and try again...", false);
                                Console.WriteLine("\n*************************************************************************");
                            }
                            break;

                        case 5:
                            if (stackS.pushCount > 0)
                            {
                                Console.Clear();

                                stackS.printItems();
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Stack is empty!!! Kindly Push some item(s) and try again...", false);
                                Console.WriteLine("\n*************************************************************************");
                            }
                            break;

                        case 6:
                            StartApp.Play();
                            break;
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
