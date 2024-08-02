using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private int[,] adjacencyMatrix;
    private List<Node> nodes;

    public Graph(int size)
    {
        adjacencyMatrix = new int[size, size];
        nodes = new List<Node>();
    }

    public void AddNode(Node node)
    {
        if (!nodes.Exists(n => n.Id == node.Id))
        {
            nodes.Add(node);
        }
    }

    public void AddEdge(int fromNodeId, int toNodeId)
    {
        if (fromNodeId < nodes.Count && toNodeId < nodes.Count)
        {
            adjacencyMatrix[fromNodeId, toNodeId] = 1;
            adjacencyMatrix[toNodeId, fromNodeId] = 1; // Assuming undirected graph
            PropagatePower();
        }
    }

    public void RemoveEdge(int fromNodeId, int toNodeId)
    {
        if (fromNodeId < nodes.Count && toNodeId < nodes.Count)
        {
            adjacencyMatrix[fromNodeId, toNodeId] = 0;
            adjacencyMatrix[toNodeId, fromNodeId] = 0; // Assuming undirected graph
            PropagatePower();
        }
    }

    public void DisconnectAllNodesFrom(int nodeId)
    {
        if (nodeId < nodes.Count)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                adjacencyMatrix[nodeId, i] = 0;
                adjacencyMatrix[i, nodeId] = 0;
            }
            PropagatePower();
        }
    }

    public void PropagatePower()
    {
        // Reset all nodes to not powered except power nodes
        foreach (var node in nodes)
        {
            if (!node.IsPowerNode)
            {
                node.IsPowered = false;
            }
        }

        // BFS or DFS to propagate power from power nodes
        foreach (var node in nodes)
        {
            if (node.IsPowerNode)
            {
                PropagatePowerFrom(node);
            }
        }
    }

    private void PropagatePowerFrom(Node node)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            current.IsPowered = true;

            for (int i = 0; i < nodes.Count; i++)
            {
                if (adjacencyMatrix[current.Id, i] == 1 && !nodes[i].IsPowered)
                {
                    queue.Enqueue(nodes[i]);
                }
            }
        }
    }

    public void DisplayConnections()
    {
        string matrixString = "Adjacency Matrix:\n";
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < nodes.Count; j++)
            {
                matrixString += adjacencyMatrix[i, j] + " ";
            }
            matrixString += "\n";
        }
        Debug.Log(matrixString);

        string powerStatus = "Power Status:\n";
        foreach (var node in nodes)
        {
            powerStatus += $"Node {node.Id} (Power Node: {node.IsPowerNode}) - Powered: {node.IsPowered}\n";
        }
        Debug.Log(powerStatus);
    }
}
