public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
            Dictionary<int, int> count = new Dictionary<int, int>();

    foreach (int num in nums)
    {
        if (count.ContainsKey(num))
            count[num] = count[num] + 1;
        else
            count[num] = 1;
    }

    return count
        .OrderByDescending(pair => pair.Value)
        .Take(k)
        .Select(pair => pair.Key)
        .ToArray();
    }
}
