using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Struct
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; internal set; }

    }
    public class linkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        public linkedList()
        {
            Head = null;
            Tail = null;
        }

        public int AddFirst(T newNode)
        {
            var NewNode = new Node<T> { Data = newNode };
            if (Head == null)
            {
                Head = NewNode;
                Tail = NewNode;
            }
            else
            {
                NewNode.Next = Head;
                Head = NewNode;
            }
            Count++;

            return Count;
        }
        public void Add(T newNode)
        {
            Node<T> NewNode = new Node<T> { Data = newNode };
            if (Tail == null)
            {
                Head = NewNode;
                Tail = NewNode;
            }
            else
            {
                Tail.Next = NewNode;
                Tail = NewNode;
            }
            Count++;
        }

        public bool Checks(T target)
        {
            Node<T> CurrentNode = Head;

            while (CurrentNode != null && !CurrentNode.Data.Equals(target))
            {
                CurrentNode = CurrentNode.Next;
            }
            if (CurrentNode != null && CurrentNode.Data.Equals(target))
            {
                return true;
            }
            return false;
        }

        public int Indexer(T target)
        {
            int Index = 1;

            Node<T> CurrentNode = Head;
            while (CurrentNode != null && !CurrentNode.Data.Equals(target))
            {
                CurrentNode = CurrentNode.Next;
                Index++;
            }
            if (CurrentNode == null)
            {
                return -1;
            }
            return Index;
        }
        public T LastItem()
        {
            Node<T> Previous = Head;
            Node<T> Current = Tail;

            return Previous.Data;
        }

        public T RemoveFirst()
        {
            Node<T> reviewe = Head;
            if (Head == null)
            {
                throw new InvalidOperationException("Item is empty");
            }
            else
            {
                Head = Head.Next;
                Count--;
            }
            return reviewe.Data;
        }

        public T RemoveFirstInStack()
        {
            Node<T> reviewe = Head;

            if (Head == null || Count == 0)
            {
                throw new InvalidOperationException("Item is empty");
            }
            else
            {
                Head = Head.Next;
                Count--;
            }
            return reviewe.Data;
        }
        public T RemoveLast()
        {

            Node<T> CurrentNode = Head;
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {

                    while (CurrentNode.Next != Tail)
                    {
                        CurrentNode = CurrentNode.Next;
                    }
                    CurrentNode.Next = null;
                    Tail = CurrentNode;

                }
                Count--;
            }
            return CurrentNode.Data;
        }

        public T PeekStack()
        {
            Node<T> CurrentNode = Tail;
            return CurrentNode.Data;
        }

        public T ShowLast()
        {
            Node<T> CurrentNode = Head;

            while (CurrentNode.Next != Tail)
            {
                CurrentNode = CurrentNode.Next;
            }
            CurrentNode.Next = null;
            Tail = CurrentNode;
            Console.WriteLine(CurrentNode.Data);
            return CurrentNode.Data;
        }

        public bool Remove(T target)
        {
            Node<T> previous = null;
            Node<T> CurrentNode = Head;

            while (CurrentNode != null)
            {
                if (CurrentNode.Data.Equals(target))
                {
                    if (previous != null)
                    {
                        previous.Next = CurrentNode.Next;

                        if (CurrentNode.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirstInStack();
                    }
                    return true;
                }

                previous = CurrentNode;
                CurrentNode = CurrentNode.Next;

            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                yield return current.Data;
                current = current.Next;
            }
            yield return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public static void LaunchLinkedList()
        {
            linkedList<string> items = new linkedList<string>();

            Console.Clear();
        maxSize:

            Console.Clear();
            bool loopBreak = true;
            while (loopBreak == true)
            {
                Console.WriteLine("*************************************************************************");
                AddFun.CustomMessage("\nLINKEDLIST MENU!!!", true);
            mainMenu:
                Console.WriteLine("\n*************************************************************************");
                Console.WriteLine("\n1. Add(T item)? ");
                Console.WriteLine("2. Remove(T item)? ");
                Console.WriteLine("3. Print? ");
                Console.WriteLine("4. Check(T item)? ");
                Console.WriteLine("5. Index(T item)? ");
                Console.WriteLine("6. Main Menu? ");

                string Linkmenu = Console.ReadLine();
                int LinkMenu = 0;

                if (int.TryParse(Linkmenu, out LinkMenu))
                {
                    switch (LinkMenu)
                    {

                        case 1:
                            Console.Clear();

                            Console.WriteLine("\n*************************************************************************");
                            Console.WriteLine("\nHow many Items would you like to Add up? ");
                            string Maxsize = Console.ReadLine();
                            int maxSize = 0;
                            if (!int.TryParse(Maxsize, out maxSize))
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                goto maxSize;
                            }

                            for (int i = 0; i < maxSize; i++)
                            {
                                Console.Clear();
                            AddItem:
                                var number = AddFun.AddOrdinal(i + 1);
                                Console.WriteLine("\n*************************************************************************");

                                Console.WriteLine($"Enter your {number} item ");
                                Console.WriteLine("\n*************************************************************************");

                                string Additem = Console.ReadLine();

                                items.Add(Additem);
                                Console.Write("Adding item"); AddFun.PrintDotAnimation();

                                Console.WriteLine($"My Linked List Size is {items.Count}");
                            }
                            break;

                        case 2:
                            Console.Clear();
                        Remove:
                            Console.WriteLine("\n*************************************************************************");
                            Console.WriteLine("\nHow many Items would you like to Remove? ");
                            string Remove = Console.ReadLine();
                            int remove = 0;
                            if (!int.TryParse(Remove, out remove))
                            {
                                Console.Clear();
                                Console.WriteLine("\n*************************************************************************");
                                AddFun.CustomMessage("\nInvalid entry! Please enter a valid Number!!!", false);
                                goto Remove;
                            }

                            for (int i = 0; i < remove; i++)
                            {
                                Console.Clear();
                            remove:
                                var number = AddFun.AddOrdinal(i + 1);
                                Console.WriteLine("\n*************************************************************************");

                                Console.WriteLine($"Enter your {number} item ");
                                Console.WriteLine("\n*************************************************************************");

                                string removee = Console.ReadLine();
                                Console.Write("Removing item"); AddFun.PrintDotAnimation();


                                if (items.Checks(removee))
                                {
                                    items.Remove(removee);
                                    AddFun.CustomMessage($"true, {removee} has been removed!!!", true);
                                }
                                else { AddFun.CustomMessage($"false, {removee} is not found!!!", false); }
                            }
                            break;

                        case 3:
                            Console.Clear();

                            if (items.Count > 0)
                            {
                                Console.Clear();

                                Console.Write("Loading Linked List"); AddFun.PrintDotAnimation();
                                Console.Clear();

                                Console.WriteLine("\n*************************************************************************");
                                AddFun.CustomMessage("My Linked List...", true);
                                Console.WriteLine("*************************************************************************");

                                foreach (var i in items)
                                {
                                    Console.WriteLine(i);
                                }
                                Console.WriteLine("*************************************************************************");
                            }
                            else
                            {
                                Console.Clear();
                                AddFun.CustomMessage("Linked List is Empty!!!", false);
                                Console.WriteLine("*************************************************************************");
                            }
                            break;
                        case 4:
                            Console.Clear();

                            Console.WriteLine("\n*************************************************************************");
                            Console.WriteLine("What Item are you checking on the LinkedList? ");
                            Console.WriteLine("*************************************************************************");
                            string check = Console.ReadLine();
                            Console.Clear();
                            bool color = items.Checks(check);


                            Console.WriteLine("\n*************************************************************************");
                            AddFun.CustomMessage($"Is {check} on my list? : {items.Checks(check)}", color);
                            Console.WriteLine("*************************************************************************");
                            break;
                        case 5:
                            Console.Clear();

                            Console.WriteLine("What Item's index are you fetching? ");
                            string item = Console.ReadLine();
                            Console.Clear();
                            bool Color = items.Indexer(item) > 0;
                            Console.WriteLine("\n*************************************************************************");
                            AddFun.CustomMessage($"{item} is at index: {items.Indexer(item)}", Color);
                            Console.WriteLine("*************************************************************************");
                            break;

                        case 6:
                            Console.Clear();
                            StartApp.Play();
                            break;
                    }
                }
            }
        }

    }
}



