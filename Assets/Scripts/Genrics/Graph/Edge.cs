public class Edge
{
    public Node From { get; private set; }
    public Node To { get; private set; }
    public float Weight { get; private set; }

    public Edge(Node from, Node to, float weight = 1.0f)
    {
        From = from;
        To = to;
        Weight = weight;
    }
}