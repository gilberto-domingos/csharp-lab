    namespace ExplicitInterfaces
{
    interface Intf1
    {
        void SomeMethod();
    }
    interface Intf2
    {
        void SomeMethod();
    }

    class InterfaceTest: Intf1, Intf2
    {

        void Intf1.SomeMethod()
        {
            Console.WriteLine("This in the Intf1 SomeMethod");
        }
        
        void Intf2.SomeMethod()
        {
            Console.WriteLine("This in the Intf2 SomeMethod");
        }
        public void SomeMethod() {
            Console.WriteLine("This is the class SomeMethod");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            InterfaceTest testclass = new InterfaceTest();
            testclass.SomeMethod();

            Intf1 i1 = testclass as Intf1;
            i1.SomeMethod();
            Intf2 i2 = testclass as Intf2;
            i2.SomeMethod();
        }
    }
}
