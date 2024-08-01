using System;
using System.Collections.Generic;

public class Graph
{
    private Dictionary<int, Node> nodes;

    public Graph()
    {
        nodes = new Dictionary<int, Node>();
    }

    public void AddNode(int id)
    {
        if (!nodes.ContainsKey(id))
        {
            nodes[id] = new Node(id);
        }
    }

    public void AddEdge(int fromNode, int toNode)
    {
        if (nodes.ContainsKey(fromNode) && nodes.ContainsKey(toNode))
        {
            nodes[fromNode].AdjacentNodes.Add(toNode);
            nodes[toNode].AdjacentNodes.Add(fromNode); // For undirected graph
        }
    }

    public void RemoveEdge(int fromNode, int toNode)
    {
        if (nodes.ContainsKey(fromNode) && nodes.ContainsKey(toNode))
        {
            nodes[fromNode].AdjacentNodes.Remove(toNode);
            nodes[toNode].AdjacentNodes.Remove(fromNode);
            UpdatePowerConnectivity();
        }
    }

    public void SetPowerSource(int nodeId)
    {
        if (nodes.ContainsKey(nodeId))
        {
            ResetPowerStatus();
            nodes[nodeId].HasPower = true;
            PropagatePower(nodeId);
        }
    }

    private void ResetPowerStatus()
    {
        foreach (var node in nodes.Values)
        {
            node.HasPower = false;
        }
    }

    private void PropagatePower(int nodeId)
    {
        if (!nodes.ContainsKey(nodeId)) return;

        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue(nodeId);
        visited.Add(nodeId);

        while (queue.Count > 0)
        {
            int currentNodeId = queue.Dequeue();
            Node currentNode = nodes[currentNodeId];
            currentNode.HasPower = true;

            foreach (int adjacentNodeId in currentNode.AdjacentNodes)
            {
                if (!visited.Contains(adjacentNodeId))
                {
                    visited.Add(adjacentNodeId);
                    queue.Enqueue(adjacentNodeId);
                }
            }
        }
    }

    private void UpdatePowerConnectivity()
    {
        // Assume node 0 is always the power source
        SetPowerSource(0);
    }

    public void PrintNodePowerStatus()
    {
        foreach (var node in nodes.Values)
        {
            UnityEngine.Debug.LogError("Node " + node.Id + (node.HasPower ? " has power" : " does not have power"));
        }
    }
}
