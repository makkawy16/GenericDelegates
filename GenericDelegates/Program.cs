namespace GenericDelegates
{

    internal class Program
    {
        public delegate bool Filter<in T>(T input);
        static void Main(string[] args)
        {
            IEnumerable<int> l1 = new int[] { 1, 2, 3, 4 };
            PrintNumbers(l1, x => x <= 2);

            IEnumerable<decimal> l2 = new decimal[] { 1, 2, 3, 4 };
            PrintNumbers(l2, x => x <= 2);

            PrintNumbers3(l2 , x=> x *2); // apply transfomation
            PrintNumbers3(l2 , x=> x<2); // this apply condtion

            PrintNumbersWithAction(l2, x => x < 2, () => Console.WriteLine("This Action") ); // add action

            Action<string> action = Print;
            action("Makkawy");
            PrintNumbersWithAction(l2, x => x < 2, () => action("Makkawy")); // add action

            Func<int , int , int> func = Sum;
            Console.WriteLine(func(1, 2));

            Predicate<int> predicate = IsEven;
            Console.WriteLine(predicate(3));
        }
        static void PrintNumbers<T>(IEnumerable<T> numbers, Filter<T> filter)
        {
            foreach (var i in numbers)
            {
                if (filter(i))
                    Console.WriteLine(i);
            }
        }
        static void PrintNumbers2<T>(IEnumerable<T> numbers, Predicate<T> filter)
        {
            foreach (var i in numbers)
            {
                if (filter(i))
                    Console.WriteLine(i);
            }
        }
        static void PrintNumbers3<T>(IEnumerable<T> numbers, Func<T, T> filter)
        {
            foreach (var i in numbers)
            {
                
                    Console.WriteLine(filter(i));
            }
        }
        static void PrintNumbers3<T>(IEnumerable<T> numbers, Func<T, bool> filter)
        {
            foreach (var i in numbers)
            {
                if (filter(i))
                    Console.WriteLine(i);
            }
        }
        static void PrintNumbersWithAction<T>(IEnumerable<T> numbers, Func<T, bool> filter , Action action)
        {
            action();
            foreach (var i in numbers)
            {
                if (filter(i))
                    Console.WriteLine(i);
            }
        }

        static void Print(string name) => Console.WriteLine(name);
        static int Sum(int n1, int n2) => n1 + n2;
        static bool IsEven(int n) => n % 2 == 0;
    }
}
