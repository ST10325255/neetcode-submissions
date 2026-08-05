
public class Solution
{
    public List<List<string>> GroupAnagrams(string[] strs)
{
    var groups = new Dictionary<string, List<string>>();

    foreach (var s in strs)
    {
        int[] counts = new int[26];
        foreach (char c in s)
            counts[c - 'a']++;

        string key = string.Join(",", counts);

        if (!groups.TryGetValue(key, out var group))
        {
            group = new List<string>();
            groups[key] = group;
        }

        group.Add(s);
    }

    return groups.Values.ToList();
}
}