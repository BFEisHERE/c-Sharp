using System;
/*
 * FIFO (First in First out) ilk giren ilk çıkar
 * Bankamatik kuyruğu gibidir
 */
namespace Queue_Kuyruk_Yapısı
{
    class Queue_Kuyruk_Yapısı
    {
        static void Main(string[] args)
        {
            KuyrukYapısı ky = new KuyrukYapısı();

            ky.enQueue(10); // 1. eleman eklendi. Front = rear 
            ky.enQueue(20); // 2. eleman eklendi. front = 10 , rear = 20
            ky.enQueue(30); // 3. eleman eklendi. front = 10, rear = 30
            ky.enQueue(40); // 4. eleman eklendi. front = 10, rear = 40

            ky.print(); // Çıktı = 10 <- 20 <- 30 <- 40

            int sayı = ky.deQueue(); // 10 çıktı. front = 20, rear = 40
            ky.deQueue(); // 20 çıktı. front = 30 , rear = 40
            ky.deQueue(); // 30 çıktı. front = rear = 40

            ky.print();
        }
        
        class Node
        {
            public int data;
            public Node next;

            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }
        }

        class KuyrukYapısı
        {
            Node front; // kuyruğun başı
            Node rear; // kuyruğun sonu

            public KuyrukYapısı()
            {
                this.front = null;
                this.rear = null;
            }

            public void enQueue(int data)  // kuyruğa eleman ekleme
            {
                Node eleman = new Node(data);
                if (front ==null)
                {
                    front = rear = eleman;
                    Console.WriteLine("Kuyruk Oluşturuldu, ilk eleman eklend");
                }
                else
                {
                    rear.next = eleman;
                    rear = eleman;
                    Console.WriteLine("Ekleme yapıldı");
                }
            }


            public int deQueue()  // kuyruktan eleman ekleme
            {
                
                if (front == null)
                {
                    Console.WriteLine("Kuyruk boştur");
                    return -1;
                }
                else
                {
                    int data = front.data;
                    front = front.next;
                    Console.WriteLine("Kuyrultan eleman çıkarıldı");return data;
                }
            }

            public void print()
            {
                if (front == null)
                {
                    Console.WriteLine("Kuyruk Boştur!!");
                }
                else
                {
                    Node temp = front;
                    Console.Write("Başı <-");
                    while (temp != null)
                    {
                        Console.Write(temp.data + " <-");
                        temp = temp.next;
                    }
                    Console.WriteLine("Sonu");
                }
            }


        }
    }
}
