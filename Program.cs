internal class Program
{
    private static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Item(2),
            new Item(1),
            null,
            null
        };

        ItemComparer comparer = new ItemComparer();
        items.Sort(comparer);
        foreach (Item item in items)
        {
            if (item == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(item.Number);
            }
        }
    }
}

public class Item : IComparable<Item>
{
    public int Number;

    public Item(int number)
    {
        this.Number = number;
    }

    // Number昇順ソート
    public int CompareTo(Item? item)
    {
        // nullを最小値として扱う
        if (item == null) 
        {
            return 1;
        }
        return this.Number.CompareTo(item.Number);
    }
}

// Number降順ソート
public class ItemComparer : IComparer<Item>
{
    public int Compare(Item? x, Item? y)
    {
        // nullを最小値として扱う
        if (x == null) 
        {
            return y == null ? 0 : 1;
        }
        if (y == null)
        {
            return -1;
        } 
        
        return -x.Number.CompareTo(y.Number);
    }
}