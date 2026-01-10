namespace LeetCode
{
    internal class _412FizzBuzz
    {
        public void Run()
        {
            int n = 15;

            foreach (var sol in FizzBuzz(n))
            {
                Console.WriteLine(sol.ToString());
            }
        }

        public IList<string> FizzBuzz(int n)
        {
            string[] toReturn = [];

            for (int i = 1; i <= n; i++)
            {
                var divisibleByThree = i % 3 == 0;
                var divisibleByFive = i % 5 == 0;

                if (!divisibleByThree && !divisibleByFive)
                {
                    toReturn = [.. toReturn, i.ToString()];
                    continue;
                }
                
                var fizzString = divisibleByThree ? "Fizz" : string.Empty;
                var buzzString = divisibleByFive ? "Buzz" : string.Empty;

                toReturn = [.. toReturn, $"{fizzString}{buzzString}"];
            }

            return toReturn;
        }
    }
}
