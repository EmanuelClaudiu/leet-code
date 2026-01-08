namespace LeetCode
{
    internal class _22GenerateParantheses
    {
        public void Run()
        {
            int n = 1;

            var sol = GenerateParenthesis(n);

            foreach (var combo in sol)
            {
                Console.WriteLine(combo);
            }
        }

        public IList<string> GenerateParenthesis(int n)
        {
            return [.. Generate((n * 2) - 1, "("), .. Generate((n * 2) - 1, ")")];
        }

        public IList<string> Generate(int charsLeft, string sequence)
        {
            if (charsLeft == 0)
            {
                if (IsWellFormed(sequence)) return [sequence];
                return [];
            }

            if (SequenceCadence(sequence) < 0) return [];

            return [.. Generate(charsLeft - 1, $"{sequence}("), .. Generate(charsLeft - 1, $"{sequence})")];
        }

        public bool IsWellFormed(string sequence)
        {
            int cnt = 0;

            foreach (var character in sequence)
            {
                if (character == '(') cnt++;
                if (character == ')') cnt--;

                if (cnt < 0) return false;
            }

            return cnt == 0;
        }

        public int SequenceCadence(string sequence)
        {
            int cnt = 0;

            foreach (var character in sequence)
            {
                if (character == '(') cnt++;
                if (character == ')') cnt--;
            }

            return cnt;
        }
    }
}
