using System;

namespace AVL_TREE2
{
    class Node
    {
        public int key, height;
        public Node left, right;

        public Node(int d)
        {
            key = d;
            height = 1;
        }
    }

    public class AVLTree
    {

        Node root;

        // Ağacın yüksekliğini elde etmek için yardımcı fonksiyon
        int height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }
        
        //Kıyaslama yapılır
        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        //  Sağa bir yardımcı fonksiyon
        // y ile köklenmiş alt ağacı döndür
        Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Döndürme Yapılır
            x.right = y;
            y.left = T2;

            // Yükseklikleri güncelle
            y.height = max(height(y.left),
                        height(y.right)) + 1;
            x.height = max(height(x.left),
                        height(x.right)) + 1;

            return x;
        }

        // Sola bir yardımcı fonksiyon
        // x ile köklenmiş alt ağacı döndür
        Node leftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Döndürme Yapılır
            y.left = x;
            x.right = T2;

            // Yükseklikleri güncelle
            x.height = max(height(x.left),
                        height(x.right)) + 1;
            y.height = max(height(y.left),
                        height(y.right)) + 1;

            return y;
        }

        // N düğümünün Denge faktörünü alın
        int getBalance(Node N)
        {
            if (N == null)
                return 0;

            return height(N.left) - height(N.right);
        }

        Node insert(Node node, int key)
        {

            /* 1. Normal BST yerleştirme işlemini gerçekleştirin */
            if (node == null)
                return (new Node(key));

            if (key < node.key)
                node.left = insert(node.left, key);
            else if (key > node.key)
                node.right = insert(node.right, key);
            else
                return node;

            /* Ata düğümün yükseliği güncellenir */
            node.height = 1 + max(height(node.left),
                                height(node.right));

            /* Atanın denge faktörüne bakar.
             * Dengede olup olmadığına  */
            int balance = getBalance(node);

            if (balance > 1 && key < node.left.key)
                return rightRotate(node);

            // Sağın Sağı
            if (balance < -1 && key > node.right.key)
                return leftRotate(node);

            // Solun Sağı
            if (balance > 1 && key > node.left.key)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            // Sağın Solu
            if (balance < -1 && key < node.right.key)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            /* (değişmemiş) düğüm işaretçisini döndür */
            return node;
        }

        // İlk geçişi yazdırmak için yardımcı işlev
        // ve her düğümün yüksekliğini yazdırır
        void preOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + " ");
                preOrder(node.left);
                preOrder(node.right);
            }
        }

        public static void Main(String[] args)
        {
            AVLTree tree = new AVLTree();

            /* Ağacı oluşturma */
            tree.root = tree.insert(tree.root, 10);
            tree.root = tree.insert(tree.root, 20);
            tree.root = tree.insert(tree.root, 30);
            tree.root = tree.insert(tree.root, 40);
            tree.root = tree.insert(tree.root, 50);
            tree.root = tree.insert(tree.root, 25);

            /* ağacın görüntüsü
              30
              / \
             20 40
             / \ \
            10 25 50     */

            Console.WriteLine("İlk Geçiş");
            tree.preOrder(tree.root);

            Console.ReadKey();
        }
    }
}

