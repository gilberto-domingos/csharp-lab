using System;

class Node {
    public int data;
    public Node left;
    public Node right;
    public Node(int d) { data = d; left = right = null; }
}

class Solution {
    static Node Insert(Node root, int data) {
        if (root == null) return new Node(data);
        if (data <= root.data) root.left = Insert(root.left, data);
        else root.right = Insert(root.right, data);
        return root;
    }

    static int getHeight(Node root) {
        if (root == null) return -1;                
        int leftHeight  = getHeight(root.left);      
        int rightHeight = getHeight(root.right);     
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    static void Main(string[] args) {
        Console.WriteLine("Informe quantos números você vai informar para montar uma árvore binária ordenada e saber a altura da árvore");
        int T = int.Parse(Console.ReadLine());
        Node root = null;
        while (T-- > 0) {
            int data = int.Parse(Console.ReadLine());
            root = Insert(root, data);
        }
        Console.WriteLine(getHeight(root));
    }
}