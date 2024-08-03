using UnityEngine;

public class Connectors : MonoBehaviour
{
    private GameElement mygameElement;
    
    private void Awake()
    {
        mygameElement = transform.parent.GetComponent<GameElement>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameElement gameElement = other.transform.parent.GetComponent<GameElement>();
        gameElement.OnConnect(mygameElement, gameElement);


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameElement gameElement = other.transform.parent.GetComponent<GameElement>();
        gameElement.OnDisConnect(mygameElement, gameElement);
    }
}
