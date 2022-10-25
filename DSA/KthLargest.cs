
public class KthLargest
{
    private List<int> list;

    public KthLargest(int[] array)
    {
        list = new List<int>(new HashSet<int>(array));
    }

    public int Get(int k)
    {
        if (k < 1 || k > list.Count) throw new ArgumentOutOfRangeException(nameof(k), "k is either less than 1 or greater than count of distinct elements");
        if (k == 1) return list.Max();
        if (k == list.Count) return list.Min();
        var first = list.First();
        List<int> greaterThanKList = new();
        List<int> smallerThanKList = new();
        for (var i = 1; i < list.Count; i++)
        {
            if (first < list[i]) greaterThanKList.Add(list[i]);
            else smallerThanKList.Add(list[i]);
        }
        if (greaterThanKList.Count == k - 1) return first;

        if (greaterThanKList.Count > k - 1)
        {
            list = greaterThanKList;
            return Get(k);
        }
        list = smallerThanKList;
        return Get(k - greaterThanKList.Count - 1);

    }  
}