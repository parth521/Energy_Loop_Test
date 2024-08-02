
public class Node
{
    public int Id { get; private set; }
    public bool IsPowerNode { get; private set; }
    public bool IsPowered { get; set; }

    public Node(int id,bool isPowerNode)
    {
        Id = id;
        IsPowerNode = isPowerNode;
    }
}
