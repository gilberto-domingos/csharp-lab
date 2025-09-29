/*Lê uma lista de números, monta uma árvore binária de busca com eles, e imprime a travessia em ordem por nível (da raiz para baixo, esquerda para direita). O resultado aparece como uma sequência de números separados por espaço.*/
using System;
using System.Collections.Generic;

class Node {
    public int data;
    public Node left;
    public Node right;
    public Node(int d) { data = d; left = right = null; }
}

class Solution {
    static void levelOrder(Node root) {
        if (root == null) return;          

        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);

        while (q.Count > 0) {
            Node current = q.Dequeue();
            Console.Write(current.data + " ");

            if (current.left != null) q.Enqueue(current.left);
            if (current.right != null) q.Enqueue(current.right);
        }
    }

    static Node insert(Node root, int data) {
        if (root == null) return new Node(data);
        if (data <= root.data)
            root.left = insert(root.left, data);
        else
            root.right = insert(root.right, data);
        return root;
    }

    static void Main(string[] args) {
        Console.WriteLine("Informa a quantidade de números inteiros que você irá digitar :");
        int T = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º valor inteiro");
            
            Node root = null;
            while (T-- > 0) {
                int data = Convert.ToInt32(Console.ReadLine());
                root = insert(root, data);
            }
            levelOrder(root);
        }   
    }
}