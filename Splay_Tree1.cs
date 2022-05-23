using System;

namespace Splay_Tree
{
    class Program
    {
         public class node
        {
            public int key;
            public node left, right;
        }
        /* Tahsis eden yardımcı fonksiyon
        verilen anahtarla yeni bir düğüm ve
        boş sol ve sağ işaretçiler. */
        static node newNode(int key)
        {
            node Node = new node();
            Node.key = key;
            Node.left = Node.right = null;
            return (Node);
        }
        //Kökü y olan alt ağacı sağa döndürmek için bir yardımcı fonksiyon
        static node rightRotate(node x)
        {
            node y = x.left;
            x.left = y.right;
            y.right = x;
            return y;
        }
        //Alt ağacı sola döndürmek için bir yardımcı işlev,
        static node leftRotate(node x)
        {
            node y = x.right;
            x.right = y.left;
            y.left = x;
            return y;
        }
        /*Bu işlev, ağaçta anahtar varsa, anahtarı köke getirir.
         * Anahtar yoksa, son erişilen öğeyi köke getirir. 
         * Bu işlev ağacı değiştirir ve yeni kökü döndürür */
        static node splay(node root, int key)
        {
            // Temel durumlar: kök boş veya kökte anahtar var
            if (root == null || root.key == key)
                return root;

            //Anahtar sol alt ağacta
            if (root.key > key)
            {
                // KEY ağaçta değil
                if (root.left == null) return root;

                //zig-zig (LEFT - LEFT)
                if (root.left.key > key)
                {
                    root.left.left = splay(root.left.left, key);
                    // Kök için ilk döndürmeyi yapın, aksi halde ikinci döndürme yapılır
                    root = rightRotate(root);
                }
                else if (root.left.key < key) //Zig - Zag (Left Right)
                {
                    root.left.right = splay(root.left.right, key);
                    if (root.left.right != null)
                        root.left = leftRotate(root.left);
                }
                return (root.left == null) ? root : rightRotate(root);
            }
            else // anahtar sağ alt ağaçta
            {
                if (root.right == null) return root;
                // Zag-Zig (Right Left)
                if (root.right.key >key)
                {
                    root.right.left = splay(root.right.left, key);

                    if (root.right.left != null)
                        root.right = rightRotate(root.right);
                }
                else if (root.right.key < key)//Zag-Zag (right right)
                {
                    root.right.right = splay(root.right.right, key);
                    root = leftRotate(root);
                }
                return (root.right == null) ? root : leftRotate(root);
            }
        }

        //SPLAY ağacı için arama işkevidir.
        //Splay ağacı yeni kökü döndürdürür. Ağaçta Key varsa köke taşınır.
        static node search(node root, int key)
        {
            return splay(root, key);
        }

        // Ağacın Preorder formatını yazdırmak için bir yardımcı fonksiyondur.
        // Ağacın yüksekliğini de yazdırır.
        static void preOrder(node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.key + " ");
                preOrder(root.left);
                preOrder(root.right);
            }
        }
        public static void Main(String[] args)
        {
            node root = newNode(100);
            root.left = newNode(50);
            root.right = newNode(200);
            root.left.left = newNode(40);
            root.left.left.left = newNode(30);
            root.left.left.left.left = newNode(20);

            root = search(root, 20);
            Console.WriteLine("Ağaçtaki Geçişler \n");
            preOrder(root);
            Console.ReadKey();
        }
    }
}
