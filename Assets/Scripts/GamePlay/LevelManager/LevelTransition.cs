using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    [SerializeField] private GameData gameData;

    private void Awake()
    {
        levelGenerator = GetComponent<LevelGenerator>();
    }

    public void StartLevelSwitch()
    {
        StartCoroutine(SwitchingLevel());
    }
    private IEnumerator SwitchingLevel()
    {
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.ShowPanel(PanelName.loadingPanel);

        foreach (GameElement gameElement in gameData.inGameElements)
        {
            if (gameElement.elementType != GameElementType.PowerSource)
            {
                gameElement.HasPower = false;
            }
            ObjectPoolManager.Instance.ReturnObject(gameElement);
        }
    }
}
