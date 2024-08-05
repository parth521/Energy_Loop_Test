using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    private Image buttonImage;
    private bool isSprite1 = true;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        if (buttonImage == null)
        {
            Debug.LogError("Button does not have an Image component!");
        }
        else
        {
            LoadSpriteState();
        }
    }

    public void Toggle()
    {
        if (buttonImage == null) return;

        isSprite1 = !isSprite1;
        buttonImage.sprite = isSprite1 ? sprite1 : sprite2;
        SaveSpriteState();
    }

    private void SaveSpriteState()
    {
        PlayerPrefs.SetInt("SpriteState", isSprite1 ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadSpriteState()
    {
        isSprite1 = PlayerPrefs.GetInt("SpriteState", 1) == 1; // Default to sprite1 if key doesn't exist
        buttonImage.sprite = isSprite1 ? sprite1 : sprite2;
    }
}
