namespace LeetCode
{
    internal class _451SortCharactersByFrequency
    {
        private Dictionary<char, int> _frequencies = [];
        private Dictionary<int, HashSet<char>> _frequencyPerCharacters = [];

        public void Run()
        {
            string s = "Aabb";

            var sol = FrequencySort(s);

            Console.WriteLine(sol);
        }

        public string FrequencySort(string s)
        {
            foreach (var character in s)
            {
                if (!_frequencies.Keys.Contains(character))
                {
                    _frequencies[character] = 1;
                    if (!_frequencyPerCharacters.Keys.Contains(1)) _frequencyPerCharacters[1] = [];
                    _frequencyPerCharacters[1].Add(character);
                    continue;
                }

                _frequencies[character] += 1;
                if (!_frequencyPerCharacters.Keys.Contains(_frequencies[character])) _frequencyPerCharacters[_frequencies[character]] = [];
                _frequencyPerCharacters[_frequencies[character]].Add(character);
                _frequencyPerCharacters[_frequencies[character] - 1].Remove(character);
            }

            string frequencyString = "";

            var frequencies = _frequencyPerCharacters.Keys.ToArray();

            for (int i = frequencies.Length - 1; i >= 0; i--)
            {
                var charactersSet = _frequencyPerCharacters[frequencies[i]];

                char[] characters = [];
                foreach (var character in charactersSet)
                {
                    characters = [.. characters, character];
                }

                for (int j = characters.Length - 1; j >= 0; j--)
                {
                    frequencyString += CharTimesFrequency(characters[j], frequencies[i]);
                }
            }

            return frequencyString;
        }

        private string CharTimesFrequency(char character, int frequency)
        {
            string toReturn = "";

            for (int i = 1; i <= frequency; i++)
            {
                toReturn += character;
            }

            return toReturn;
        }
    }
}
