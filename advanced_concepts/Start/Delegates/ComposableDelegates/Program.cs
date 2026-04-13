namespace Composable
{
    // declare the delegate type
    public delegate void MyDelegate(int arg1, ref int arg2);

    class Program
    {
        static void func1(int arg1, ref int arg2)
        {
            arg2 += 20;
            string result = (arg1 + arg2).ToString();
            Console.WriteLine("The number from func1 is: " + result);
        }

        static void func2(int arg1, ref int arg2)
        {
            string result = (arg1 * arg2).ToString();
            Console.WriteLine("The number from func2 is: " + result);
        }
        
        static void Main(string[] args)
        {
            MyDelegate f1 = func1;
            MyDelegate f2 = func2;

            MyDelegate f1f2 = f1 + f2;

            int a=10;
            int b=20;

            Console.WriteLine("Calling the first delegate");
            f1(a,ref b);
            Console.WriteLine("Calling the second delegate");
            f2(a, ref b);
            Console.WriteLine("\nCalling the chained delegates");
            f1f2(a,ref b);


            Console.WriteLine("\nCalling the unchained delegates");
            f1f2 -= f1;
            f1f2(a, ref b);

        }
    }
}
