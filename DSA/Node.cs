public class Node
{
    public Node(int value)
    {
        Value = value;
    }
    public Node Parent { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Value { get; private set; }
}