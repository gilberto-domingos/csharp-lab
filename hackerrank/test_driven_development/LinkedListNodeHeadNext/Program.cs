using System;

namespace HackerRank.LinkedList
{
    public class Node
    {
        public int Data { get; }
        public Node? Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public static class LinkedListHelper
    {
        public static Node Insert(Node? head, int data)
        {
            var newNode = new Node(data);

            if (head is null)
            {
                return newNode;
            }

            var currentPointer = head;
            
            while (currentPointer.Next is not null)
            {
                currentPointer = currentPointer.Next;
            }

            currentPointer.Next = newNode;
            return head;
        }

        public static void Display(Node? head)
        {
            var currentPointer = head;
            
            while (currentPointer is not null)
            {
                Console.Write(currentPointer.Data + " ");
                currentPointer = currentPointer.Next;
            }
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Digite a quantidade de elementos a inserir na lista:");

            if (!int.TryParse(Console.ReadLine(), out int totalElements) || totalElements <= 0)
            {
                Console.WriteLine("Entrada inválida.");
                return;
            }

            Node? head = null;
            
            for (int i = 0; i < totalElements; i++)
            {
                Console.WriteLine($"Digite o {i + 1}º valor inteiro:");
                
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    head = LinkedListHelper.Insert(head, value);
                }
                else
                {
                    Console.WriteLine($"Valor inválido na linha {i + 2}.");
                    return;
                }
            }

            LinkedListHelper.Display(head);
        }
    }
}
