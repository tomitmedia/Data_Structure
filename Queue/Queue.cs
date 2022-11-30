using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Struct
{
    public class Queue<T> : IEnumerable<T>
    {
        linkedList<T> queue = new linkedList<T>();
        public int count { get; private set; }

        public int MaxSize { get; set; }
        public int Front = 0;
        public int Rear = 0;
        public int NItem { get; set; }
        public int Length = 0;
        public int enqueueCount = 0;

        public bool isEmpty() => queue.Count == 0 ? true : false;

        public int size()
        {
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T Item in queue)
            {
                yield return Item;

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enqueue(T item)
        {
            queue.Add(item);
            Rear++;
            //QueueArray[Rear] = item;
            NItem++;
        }

        public void Dequeue()
        {

            count--;
            //queue.RemoveFirst();
            T temp = queue.RemoveFirst();
            Front++;
            if (Front == MaxSize)
            {
                Front = 0;
            }
            NItem--;
            //return temp;
            Console.Clear();
            //Console.WriteLine("\n*************************************************************************");
            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine($"\n{temp} Dequeued!");
            Console.WriteLine("\n*************************************************************************");
        }

        public void Peek()
        {
            Console.Clear();
            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine($"\n{queue.LastItem()} Peeked!");
            Console.WriteLine("\n*************************************************************************");
        }

        public bool isFull()
        {
            return (MaxSize - 1 == Front);
        }

        public void printItems()
        {
            Console.Clear();

            Console.Write("Loading Queue"); AddFun.PrintDotAnimation();
            Console.Clear();

            Console.WriteLine("\n*************************************************************************");
            Console.WriteLine("Your Queue...");
            Console.WriteLine("*************************************************************************");
            if (isEmpty() == false)
            {
                foreach (var item in queue)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("\n*************************************************************************");
            }
            else
            {
                Console.WriteLine("\nQueue is Empty!!!");
                Console.WriteLine("\n*************************************************************************");
            }
        }



        public static void LaunchQueue()
        {
            Queue<string> queueS = new Queue<string>();


            Console.Clear();
            bool loopBreak = true;
            while (loopBreak == true)
            {
                Console.WriteLine("*************************************************************************");
                AddFun.CustomMessage("\nQUEUE MENU!!!", true);
            mainMenu:
                Console.WriteLine("\n*************************************************************************");
                Console.WriteLine("\n1. IsEmpty? ");
                Console.WriteLine("2. Enqueue? ");
                Console.WriteLine("3. Dequeue? ");
                Console.WriteLine("4. Peek? ");
                Console.WriteLine("5. Print Queue? ");
                Console.WriteLine("6. Main Menu? ");

                string queuemenu = Console.ReadLine();
                int queueMenu = 0;

                if (int.TryParse(queuemenu, out queueMenu))
                {
                    switch (queueMenu)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("\n*************************************************************************");
                            if (queueS.isEmpty())
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
                            Console.WriteLine("\nHow many Items would you like to queue up? ");
                            string Maxsize = Console.ReadLine();
                            int maxSize = 0;
                            if (!int.TryParse(Maxsize, out maxSize))
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                goto maxSize;
                            }
                            queueS.MaxSize = maxSize;
                            queueS.Length = queueS.MaxSize;

                            //if (queueS.enqueueCount != queueS.MaxSize)
                            //{
                            for (int i = 0; i < queueS.Length; i++)
                            {
                                Console.Clear();
                            Enqueue:
                                var number = AddFun.AddOrdinal(i + 1);
                                Console.WriteLine("\n*************************************************************************");

                                Console.WriteLine($"Enter your {number} item ");
                                Console.WriteLine("\n*************************************************************************");

                                string Enqueue = Console.ReadLine();
                                //int EnQueue = 0;

                                //if (int.TryParse(Enqueue, out EnQueue))
                                //{
                                queueS.Enqueue(Enqueue);
                                queueS.enqueueCount++;
                                //}
                                //else
                                //  {
                                //  Console.Clear();
                                //  Console.WriteLine("\n*************************************************************************");
                                //  AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                //  goto Enqueue;
                                //  }
                            }
                            queueS.printItems();
                            //}
                            //else
                            //{
                            //    Console.Clear();

                            //    AddFun.CustomMessage("Queue is full!!! Kindly Dequeue some item(s) and try again...",false);
                            //    Console.WriteLine("\n*************************************************************************");
                            //}

                            break;

                        case 3:
                            if (queueS.enqueueCount > 0)
                            {
                                Console.Clear();
                            pop:
                                Console.WriteLine("\n*************************************************************************");
                                Console.WriteLine("\nHow many Item(s) do you wanna Dequeue? ");
                                Console.WriteLine("\n*************************************************************************");
                                string queuelength = Console.ReadLine();
                                int queueLength = 0;

                                if (!int.TryParse(queuelength, out queueLength))
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n*************************************************************************");
                                    AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                    goto pop;
                                }
                                else if (queueS.enqueueCount < queueLength)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n*************************************************************************");
                                    AddFun.CustomMessage("\nEww!!! you can't dequeue more than you Enqueued.", false);
                                    goto pop;

                                }
                                for (int i = 1; i <= queueLength; i++)
                                {
                                    Console.Clear();
                                    queueS.Dequeue();
                                    queueS.Length = queueLength;
                                    queueS.enqueueCount--;
                                }
                                //queueS.printItems();
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Queue is empty!!! Kindly Enqueue some item(s) and try again...", false);
                                Console.WriteLine("\n*************************************************************************");
                            }
                            break;

                        case 4:
                            if (queueS.enqueueCount > 0)
                            {
                                Console.Clear();
                                queueS.Peek();
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Queue is empty!!! Kindly Enqueue some item(s) and try again...", false);
                                Console.WriteLine("\n*************************************************************************");
                            }
                            break;

                        case 5:
                            if (queueS.enqueueCount > 0)
                            {
                                Console.Clear();

                                queueS.printItems();
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Queue is empty!!! Kindly Enqueue some item(s) and try again...", false);
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
