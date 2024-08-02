using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class ConnectionBehaviour : MonoBehaviour
{
    public List<GameElement> gameElements = new List<GameElement>();
    [SerializeField]private Transform elementsParent;
    [SerializeField] private GamePlayActions gamePlayActions;
    private Graph graph;
    private void Awake()
    {
        foreach (GameElement gameElement in elementsParent.GetComponentsInChildren<GameElement>())
        {
            gameElements.Add(gameElement);
        }
        SetGraph();
        
    }
    private void OnEnable()
    {
       
        gamePlayActions.onConnectionMade += OnConnectionMade;
        gamePlayActions.onLevelStart += OnLevelStart;
    }
    private void OnDisable()
    {
        gamePlayActions.onConnectionMade -= OnConnectionMade;
        gamePlayActions.onLevelStart -= OnLevelStart;
    }
    private void OnLevelStart()
    {
        gameElements.ForEach(item => item.CheckConnection());
    }
    
    private void SetGraph()
    {
        graph = new Graph(gameElements.Count);
        for (int elementIndex = 0; elementIndex < gameElements.Count; elementIndex++)
        {
            gameElements[elementIndex].elemetId = elementIndex;
            bool isPowerNode = gameElements[elementIndex].isPowerSource; // Assuming GameElement has a bool isPowerNode
            Node node = new Node(elementIndex, isPowerNode);
            graph.AddNode(node);
        }
    }
    private void OnConnectionMade(int from, List<int> connectedNodes)
    {
        
        graph.DisconnectAllNodesFrom(from);
        for (int connectedNodeIndex = 0; connectedNodeIndex < connectedNodes.Count; connectedNodeIndex++)
        {
            graph.AddEdge(from, connectedNodes[connectedNodeIndex]);
        }
        graph.DisplayConnections();
    }

}
