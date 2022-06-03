using System;

namespace LinkedList1
{
    class Program
    {
       public class Node{
            public int data;
            public Node next;
            public Node(int data)
            {
                this.data = data;
                next = null;
            }
        }
        

        static void Main(string[] args)
        {

            Node n1 = new Node(10);
            Node n2 = new Node(11);
            Node n3 = new Node(12);
            Node n4 = new Node(13);
            Node n5 = new Node(14);
            Node n6 = new Node(15);
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            Console.WriteLine("n1 değeri: " + n1.data + " \nn1'in gösterdiği değer:"+ n1.next.data);
            
        }
    }
}
