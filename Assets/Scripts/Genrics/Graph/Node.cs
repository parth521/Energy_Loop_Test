using System.Collections.Generic;

public class Node
{
    public int Id { get; private set; }
    public bool HasPower { get; set; }
    public List<int> AdjacentNodes { get; private set; }

    public Node(int id)
    {
        Id = id;
        HasPower = false;
        AdjacentNodes = new List<int>();
    }
}
