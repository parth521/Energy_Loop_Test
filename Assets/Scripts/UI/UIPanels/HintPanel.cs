using UnityEngine;

public class HintPanel : BasePanel
{
    public GamePlayActions gamePlayActions;
    public LevelData levelData;
    public GameData gameData;
    public override void Show()
    {
        base.Show();
        gamePlayActions.OnHitClick += OnHitClick;
    }
    public override void Hide()
    {
        base.Hide();
        gamePlayActions.OnHitClick -= OnHitClick;
    }
    private void OnHitClick()
    {
        for(int elementIndex=0;elementIndex< gameData.inGameElements.Count;elementIndex++)
        {
            gameData.inGameElements[elementIndex].transform.rotation = Quaternion.Euler(levelData.levels[levelData.currentLevel].elements[elementIndex].solutionsRotation);
        }
    }
}
