using System;

namespace Splay_Tree2
{
    class Program
    {
        public class node
        {
            public int key;
            public node left, right;
        }
        public class GFG
        {
            static node newNode(int key)
            {
                node Node = new node();
                Node.key = key;
                Node.left = Node.right = null;
                return (Node);
            }

            static node rightRotate(node x)
            {
                node y = x.left;
                x.left = y.right;
                y.right = x;
                return y;
            }
            static node leftRotate(node x)
            {
                node y = x.right;
                x.right = y.left;
                y.left = x;
                return y;
            }

            static node splay(node root, int key)
            {
                if (root == null || root.key == key) 
                    return root;

                if (root.key > key)
                {
                    if (root.left == null) return root;

                    if (root.left.key >key) //Zig-Zig (left left)
                    {
                        root.left.left = splay(root.left.left, key);
                        root = rightRotate(root);
                    }
                    else if (root.left.key < key)// Zig-Zag (Left Right)
                    {
                        root.left.right = splay(root.left.right, key);

                        if (root.left.right != null)
                            root.left = leftRotate(root.left);
                    }
                    return (root.left == null) ? root : rightRotate(root);
                }
                else
                {
                    if (root.right == null) return root;

                    // Zag-Zig (Right Legt)
                    if (root.right.key >key)
                    {
                        root.right.left = splay(root.right.left, key);

                        if (root.right.left != null)
                            root.right = rightRotate(root.right);
                    }
                    else if (root.right.key<key) //Zag-Zig (Right Right)
                    {
                        root.right.right = splay(root.right.right, key);
                        root = leftRotate(root);
                    }
                    return (root.right == null) ? root : leftRotate(root);
                }
            }


            static node insert(node root, int k)
            {
                if (root == null) return newNode(k);

                root = splay(root, k);

                if (root.key == k) return root;

                node newnode = newNode(k);
                if (root.key > k)
                {
                    newnode.right = root;
                    newnode.left = root.left;
                    root.left = null;
                }

                else
                {
                    newnode.left = root;
                    newnode.right = root.right;
                    root.right = null;
                }
                return newnode;
            }
            static void preOrder(node root)
            {
                if (root != null)
                {
                    Console.WriteLine(root.key);
                    preOrder(root.left);
                    preOrder(root.right);
                }
            }

            static public void Main()
            {
                node root = newNode(10);
                root.left = newNode(20);
                root.right = newNode(30);
                root.left.left = newNode(40);
                root.left.left.left = newNode(50);
                root.left.left.left.left = newNode(5);
                root = insert(root, 1);
                preOrder(root);
                /*1 5 20 50 40 10 30*/
            }
        }
    }
}
