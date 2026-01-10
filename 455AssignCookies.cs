namespace LeetCode
{
    internal class _455AssignCookies
    {
        public void Run()
        {
            int[] g = [1, 2];
            int[] s = [1, 2, 3];

            var sol = FindContentChildren(g, s);

            Console.WriteLine(sol);
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            Sort(g);
            Sort(s);

            var cookiesAvailabe = s.Length;
            var kidIndex = g.Length - 1;

            while (cookiesAvailabe > 0 && kidIndex >= 0)
            {
                if (g[kidIndex] <= s[cookiesAvailabe - 1])
                {
                    cookiesAvailabe--;
                }

                kidIndex--;
            }


            return s.Length - cookiesAvailabe;
        }

        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }
        }
    }
}
