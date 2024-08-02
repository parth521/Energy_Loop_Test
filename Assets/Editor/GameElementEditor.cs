using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameElementEditor : EditorWindow
{
    private LevelData levelData;

    [MenuItem("Tools/Game Element Reader")]
    public static void ShowWindow()
    {
        GetWindow<GameElementEditor>("Game Element Reader");
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Element Reader", EditorStyles.boldLabel);
        levelData = (LevelData)EditorGUILayout.ObjectField("Level Data", levelData, typeof(LevelData), false);

        if (GUILayout.Button("Save Elements"))
        {
            SaveElements();
        }

        if (GUILayout.Button("Delete Last Level"))
        {
            DeleteLastLevel();
        }
    }

    private void SaveElements()
    {
        if (levelData == null)
        {
            Debug.LogError("Level Data ScriptableObject is not assigned.");
            return;
        }

        GameElement[] gameElements = GameObject.FindObjectsOfType<GameElement>();

        Dictionary<ConnectorType, Elements> elementsDict = new Dictionary<ConnectorType, Elements>();
        List<Vector3> solutionsRotation = new List<Vector3>();

        foreach (GameElement gameElement in gameElements)
        {
            RectTransform rectTransform = gameElement.GetComponent<RectTransform>();
            Vector2 anchoredPosition = rectTransform != null ? rectTransform.anchoredPosition : Vector2.zero;
            Vector3 localEulerAngles = gameElement.transform.localEulerAngles;

            if (!elementsDict.ContainsKey(gameElement.connectorType))
            {
                elementsDict[gameElement.connectorType] = new Elements
                {
                    gameElement = gameElement.ElementType,
                    connectorType = gameElement.connectorType,
                    elementCount = 0,
                    position = new List<Vector2>()
                };
            }

            elementsDict[gameElement.connectorType].elementCount++;
            elementsDict[gameElement.connectorType].position.Add(anchoredPosition);
            solutionsRotation.Add(localEulerAngles);
        }

        Level newLevel = new Level
        {
            elements = new List<Elements>(elementsDict.Values),
            solutinsRotation = solutionsRotation
        };

        levelData.levels.Add(newLevel);

        Debug.Log("New level data added.");
        EditorUtility.SetDirty(levelData); // Mark the ScriptableObject as dirty to save changes
    }

    private void DeleteLastLevel()
    {
        if (levelData == null)
        {
            Debug.LogError("Level Data ScriptableObject is not assigned.");
            return;
        }

        if (levelData.levels.Count > 0)
        {
            levelData.levels.RemoveAt(levelData.levels.Count - 1);
            Debug.Log("Last level data deleted.");
            EditorUtility.SetDirty(levelData); // Mark the ScriptableObject as dirty to save changes
        }
        else
        {
            Debug.LogWarning("No levels to delete.");
        }
    }
}
