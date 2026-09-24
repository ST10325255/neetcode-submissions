public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // Step 1: count how many times each number appears
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (count.ContainsKey(num))
                count[num] = count[num] + 1;
            else
                count[num] = 1;
        }

        // Step 2: make one empty box for every possible count, 0 up to nums.Length
        List<int>[] buckets = new List<int>[nums.Length + 1];
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new List<int>();
        }

        // Step 3: drop each number into the box labelled with its count
        foreach (var pair in count)
        {
            buckets[pair.Value].Add(pair.Key);
        }

        // Step 4: walk from the highest box down, collect until we have k
        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i > 0; i--)
        {
            foreach (int num in buckets[i])
            {
                result.Add(num);
                if (result.Count == k)
                    return result.ToArray();
            }
        }

        return result.ToArray();
    }
}