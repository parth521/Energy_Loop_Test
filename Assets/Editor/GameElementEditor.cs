using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameElementEditor : EditorWindow
{
    private LevelData levelData;
    private static readonly List<float> possibleZRotations = new List<float> { 0f, 90f, 180f, 270f };

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

        List<ElementData> elements = new List<ElementData>();
        int idCounter = 0;

        foreach (GameElement gameElement in gameElements)
        {
            RectTransform rectTransform = gameElement.GetComponent<RectTransform>();
            Vector2 anchoredPosition = rectTransform != null ? rectTransform.anchoredPosition : Vector2.zero;
            Vector3 solutionsRotation = gameElement.transform.localEulerAngles;

            string id = idCounter.ToString();
            idCounter++;

            Vector3 randomRotation = GenerateRandomRotation(solutionsRotation);

            ElementData elementData = new ElementData
            {
                id = id,
                gameElement = gameElement.ElementType,
                connectorType = gameElement.connectorType,
                position = anchoredPosition,
                rotation = randomRotation,
                solutionsRotation = solutionsRotation
            };

            elements.Add(elementData);
        }

        Level newLevel = new Level
        {
            elements = elements
        };

        levelData.levels.Add(newLevel);

        Debug.Log("New level data added.");
        EditorUtility.SetDirty(levelData); // Mark the ScriptableObject as dirty to save changes
    }

    private Vector3 GenerateRandomRotation(Vector3 solutionsRotation)
    {
        Vector3 randomRotation = new Vector3(0f, 0f, solutionsRotation.z);
        while (randomRotation.z == solutionsRotation.z)
        {
            randomRotation.z = possibleZRotations[UnityEngine.Random.Range(0, possibleZRotations.Count)];
        }
        return randomRotation;
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
