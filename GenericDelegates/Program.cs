namespace GenericDelegates
{

    internal class Program
    {
        public delegate bool Filter<in T>(T input);
        static void Main(string[] args)
        {
         IEnumerable<int> l1 = new int[] {1,2,3,4};
            PrintNumbers(l1, x => x <= 2);
            IEnumerable<decimal> l2 = new decimal[] {1,2,3,4};
            PrintNumbers(l2, x => x <= 2);
        }
        static void PrintNumbers<T>(IEnumerable<T> numbers , Filter<T> filter)
        {
            foreach (var i in numbers)
            {
                if (filter(i))
                Console.WriteLine(i);
            }
        }
    }
}
