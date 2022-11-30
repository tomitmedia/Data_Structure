using System;
namespace Data_Structure
{

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next = null;

        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
