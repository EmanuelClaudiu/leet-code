namespace LeetCode
{
    internal class _11ContainerWithMostWater
    {
        public void Run()
        {
            int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];

            Solution(height);
        }
        
        private void Solution(int[] height)
        {
            // when computing container between two indexes of the list
            // area of container is area of rectangle 
            // 2 vertices: height and length
            // length is difference of indexes
            // height is min between the numbers at both indexes

            var maxVolume = 0;

            int i = 0, j = height.Length - 1;

            while (i < j)
            {
                var containerVolume = (j - i) * Math.Min(height[i], height[j]);
                if (containerVolume > maxVolume)
                {
                    maxVolume = containerVolume;
                }

                if (height[i] <= height[j])
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            Console.WriteLine($"{maxVolume}");
        }
    }
}
