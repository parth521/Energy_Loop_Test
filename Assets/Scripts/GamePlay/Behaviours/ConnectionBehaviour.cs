using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class ConnectionBehaviour : MonoBehaviour
{
    public List<GameElement> gameElements = new List<GameElement>();
    [SerializeField] private Transform elementsParent;
    [SerializeField] private GamePlayActions gamePlayActions;
    [SerializeField] private LevelActions levelActions;
    private Graph graph;

    private void OnEnable()
    {

        gamePlayActions.onConnectionMade += OnConnectionMade;

        gamePlayActions.onConnectionLost += OnConnectionLost;
        gamePlayActions.onLevelStart += OnLevelStart;
        levelActions.onLevelGenerated += OnLevelGenerated;
        levelActions.onLevelClear += OnLevelClear;
    }
    private void OnDisable()
    {
        gamePlayActions.onConnectionLost -= OnConnectionLost;
        gamePlayActions.onConnectionMade -= OnConnectionMade;
        gamePlayActions.onLevelStart -= OnLevelStart;
        levelActions.onLevelGenerated -= OnLevelGenerated;
        levelActions.onLevelClear -= OnLevelClear;

    }
    private void OnLevelStart()
    {
       // need to check if it's connected on start
    }
    private void OnLevelClear()
    {
        graph.TurnOnNode -= TurnOnPower;
        graph.TurnOffNode -= TurnOffPower;
    }
    private void OnLevelGenerated()
    {
        gameElements.Clear();
        foreach (GameElement gameElement in elementsParent.GetComponentsInChildren<GameElement>())
        {
            gameElements.Add(gameElement);
        }
        SetGraph();
        graph.TurnOnNode += TurnOnPower;
        graph.TurnOffNode += TurnOffPower;
    }
    private void SetGraph()
    {
        graph = new Graph(gameElements.Count);
        for (int elementIndex = 0; elementIndex < gameElements.Count; elementIndex++)
        {
            bool isPowerNode = gameElements[elementIndex].IsPowerSource;
            Node node = new Node(elementIndex, isPowerNode);
            graph.AddNode(node);
        }
    }
    private void TurnOnPower(int elementId)
    {
        GetElementById(elementId).TurnPowerOn();
    }
    private void TurnOffPower(int elementId)
    {
        GetElementById(elementId).TurnPowerOff();
    }
    private GameElement GetElementById(int id)
    {
        return gameElements.Find(x => x.ElementId == id);
    }
    private void OnConnectionLost(int from,int to)
    {
           graph.RemoveEdge(from, to);
    }
    private void OnConnectionMade(int from, int to)
    {
           graph.AddEdge(from, to);
    }

}
