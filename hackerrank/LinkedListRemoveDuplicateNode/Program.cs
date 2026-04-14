using System;

class Node {
    public int data;
    public Node next;
    public Node(int d) { data = d; next = null; }
}

class Program
{
    static Node removeDuplicates(Node head)
    {
        if (head == null) return null;
        Node current = head;
        while (current != null && current.next != null)
        {
            if (current.data == current.next.data)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }

    static Node insert(Node head, int data)
    {
        if (head == null) return new Node(data);
        Node curr = head;
        while (curr.next != null) curr = curr.next;
        curr.next = new Node(data);
        return head;
    }

    static void display(Node head)
    {
        Node start = head;
        while (start != null)
        {
            Console.Write(start.data + " ");
            start = start.next;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Digite a quantidade de elementos a inserir na lista:");
        string input = Console.ReadLine();

        bool validate = int.TryParse(input, out int number);

        if (!validate || number <= 0)
        {
            Console.WriteLine("Entrada inválida. A quantidade precisa ser um número inteiro positivo.");
            return;
        }

        Node head = null;

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º valor inteiro:");
            string valueInput = Console.ReadLine();

            try
            {
                int data = Convert.ToInt32(valueInput);
                head = insert(head, data);
            }
            catch
            {
                Console.WriteLine("Entrada inválida, precisa ser número inteiro.");
                i--; 
            }
        }

        head = removeDuplicates(head);
        display(head);
    }
} 