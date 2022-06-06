using System;

namespace Ağaç__Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ağaçlar ");

            Tree bt = new Tree();

            //bt.root = bt.insert(bt.root, 10); // kök olarak atandı
            //bt.root = bt.insert(bt.root, 15); // kökten büyük olduğu için sağa eklendi
            //bt.root = bt.insert(bt.root, 5); // kökten küçük olduğu için sola eklendi
            //bt.root = bt.insert(bt.root, 3); // kökün sol alt ağacındaki değerden küçük olduğu için onun soluna eklendi
            //bt.root = bt.insert(bt.root, 6); // kökün sol alt ağacındaki değerden küçük olduğu için onun soluna eklendi

            //Console.WriteLine("root      : "+ bt.root.data);
            //Console.WriteLine("root.right: "+ bt.root.right.data); 
            //Console.WriteLine("root.left : "+ bt.root.left.data); 
            //Console.WriteLine("root.left.left : "+ bt.root.left.left.data); 
            //Console.WriteLine("root.left.right : "+ bt.root.left.right.data);

            /*      10
             *     /  \
             *     5  15
             *    /\
             *   3  6
             *   şeklinde ağaç oluşturuldu.
             */

            /* GEZİNME İÇİN preOrder(önce kök) -ab 
             * inOrder(ortada kök) a-b 
             * postOrder(sonda kök)  ab-
             */
            bt.root = bt.insert(bt.root, 10);
            bt.root = bt.insert(bt.root, 5);
            bt.root = bt.insert(bt.root, 15);
            bt.root = bt.insert(bt.root, 20);
            bt.root = bt.insert(bt.root, 3);
            bt.root = bt.insert(bt.root, 12);
            bt.root = bt.insert(bt.root, 9);

            Console.WriteLine("Root (Kök): " + bt.root.data);
            Console.Write("preorder : ");
            bt.preOrder(bt.root);

            Console.WriteLine("\n");
            
            Console.Write("inOrder : ");
            bt.inOrder(bt.root); 
           
            Console.WriteLine("\n");

            Console.Write("postOrder : ");
            bt.postOrder(bt.root); 
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine("Eleman Sayısı : " + bt.size(bt.root));
            Console.WriteLine("\nYükseklik : " + bt.height(bt.root));
            Console.ReadKey();
        }
        
        class Node
        {
            public int data;
            public Node left;  // Sol düğüm
            public Node right; // Sağ Düğüm
            public Node(int data) // veri girileceği zaman değer girmek zorunlu
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        class Tree
        {
            public Node root; // 1. Düğüm - Kök 
            public Tree()
            {
                root = null;
            }

            public Node newNode(int data)
            {
                root = new Node(data);
                return root;
            }

            public Node insert(Node root,int data) // Düğüm ekleme
            {
                Node eleman = new Node(data);

                if (root != null) // Kökün altına düğüm oluşturuldu
                {
                    if (data < root.data)
                    {
                        root.left = insert(root.left, data);
                    }
                    else
                    {
                        root.right = insert(root.right, data);
                    }
                }
                else
                    root = newNode(data); // Kök düğüm oluşturuldu

                return root;
            }

            //DÜĞÜMLERDE GEZİNME


            public void preOrder(Node root) // ilk kök 
            {
                if (root != null)
                {
                    Console.Write(root.data + " ");
                    preOrder(root.left);
                    preOrder(root.right);
                }
            }

            public void inOrder(Node root) // ortada kök 
            {
                if (root != null)
                {
                    inOrder(root.left);
                    Console.Write(root.data + " ");
                    inOrder(root.right);
                }
            }
            public void postOrder(Node root) // sonda kök 
            {
                if (root != null)
                {
                    postOrder(root.left);
                    postOrder(root.right);
                    Console.Write(root.data + " ");
                }
            }


            //AĞACIN ELEMAN SAYISI - YÜKSKELİĞİ

            public int size(Node root)  // toplam eleman sayısı
            {
                if (root ==null)
                {
                    return 0;
                }
                else
                {
                    return size(root.left) + 1 + size(root.right);
                }
            }

            public int height(Node root) // Yükseklik
            { 
                if (root == null)
                {
                    return -1;
                }
                else
                {
                    int l, r;
                    l = height(root.left);
                    r = height(root.right);

                    if (l > r)
                    {
                        return l + 1;
                    }
                    else
                        return r + 1;

                }
            }




        }
    }
}
